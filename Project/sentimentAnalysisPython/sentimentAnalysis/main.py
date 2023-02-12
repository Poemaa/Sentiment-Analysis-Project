import string
from collections import Counter
from nltk.tokenize import word_tokenize
from nltk.corpus import stopwords
from nltk.sentiment.vader import SentimentIntensityAnalyzer
import matplotlib.pyplot as plt

import pyodbc
import pandas as pd

# Connect to the database
cnxn_str = ("Driver={SQL Server Native Client 11.0};"
            "Server=localhost;"
            "Database=SentimentAnalysisDB;"
            "Trusted_Connection=yes;")
cnxn = pyodbc.connect(cnxn_str)

query='SELECT * FROM Feedbakcs'
df = pd.read_sql(query, cnxn)
print(df)


temp=[]
for index, row in df.iterrows():
    text=row['Permbajtja']

    #text = open('read.txt', encoding='utf-8').read()
    lower_case = text.lower()
    # str1 : the list of char that need to be replaced
    # str2 : me qka me replcae qat str1
    # str3 : chars qe duhen me u delete (neve sna duhen dy tparat thats why theyre empty)
    cleaned_text = lower_case.translate(str.maketrans('', '', string.punctuation))

    tokenized_words = word_tokenize(cleaned_text, "english")


    final_words = []

    for word in tokenized_words:
        if word not in stopwords.words ('english'):
            final_words.append(word)

    print(final_words)


    # NLP Emotion Algorithm
    # 1) check if the word in the final_word is present in the emotion.txt
    # -open the emotion file
    # -loop through each line and clear it
    # -extract the word and emotion using split

    # 2) if word is present -> add the emotion to emotion_list
    # 3) count each emotion in the emotion_list

    emotion_list = []
    with open('emotions.txt', 'r') as file:
        for line in file:
            clear_line = line.replace('\n', '').replace(',', '').replace("'", '').strip()
            word, emotion = clear_line.split(':')

            if word in final_words:
                emotion_list.append(emotion)

    print(emotion_list)
    w = Counter(emotion_list)
    print(w)

    def sentiment_analyse(sentiment_text):
        score = SentimentIntensityAnalyzer().polarity_scores(sentiment_text)
        neg = score['neg']
        pos = score['pos']
        if neg> pos:
            print("Negative Sentiment")
            output="Negative Sentiment"
        elif pos>neg:
            print("Positive Sentiment")
            output="Positive Sentiment"
        elif pos==neg:
            print("Neutral Vibe")
            output="Neutral Vibe"
        return output


    temp.append(sentiment_analyse(cleaned_text))


    fig, ax1 = plt.subplots()
    ax1.bar(w.keys(),w.values())
    fig.autofmt_xdate()
    plt.savefig('graph.png')
    plt.show()

df['analiza']=temp
print(df)

df.to_excel("analiza.xlsx")
df.to_excel('C:/Users/Lenovo/Desktop/analiza.xlsx')