CREATE DATABASE draftP1
USE draftP1


DROP TABLE IF EXISTS [Instituti]

Create Table [Instituti](
InstitutiID int PRIMARY KEY,
Emri varchar(50) NOT NULL,
Lokacioni varchar(50) NOT NULL,
NrStudenteve int NOT NULL,
Nrtelefonit varchar(30) UNIQUE NOT NULL

);

DROP TABLE IF EXISTS [Fakulteti]

Create Table [Fakulteti](
FakultetiID int PRIMARY KEY,
Dega varchar(50) NOT NULL,
Email varchar(50) UNIQUE NOT NULL,
StatusiAkredititmit bit DEFAULT(0),
-- 0 --> jo e akredituar, 1--> i akredituar
VitiAkreditimit date NOT NULL 
);



DROP TABLE IF EXISTS [User]

Create Table [User](
ID_User int IDENTITY(1,1) PRIMARY KEY,
Emri varchar(50) NOT NULL,
Mbiemri varchar(50) NOT NULL,
Ditelindja date NOT NULL,
Gjinia char(1)
CHECK (Gjinia in ('F','M','N')) NOT NULL,
InstitutiID int NOT NULL FOREIGN KEY references [Instituti](InstitutiID) , 
Dega varchar(25) NOT NULL,
FakultetiID int NOT NULL,
Statusi bit DEFAULT(0),
-- 0 --> perfundoi studimet, 1--> ende studion
FillimiStudimeve date NOT NULL,
MesatarjaNotes DECIMAL(4,2) NOT NULL CHECK (MesatarjaNotes >= 6.00)
);

DROP TABLE IF EXISTS [UserAcc]

Create Table [UserAcc](
ID_User int NOT NULL FOREIGN KEY references [User](ID_User), 
Email varchar(50) UNIQUE NOT NULL,
[Password] varchar(32) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,-- method for encryption or .NET first
Primary Key(ID_User),
Roli char(8) NOT NULL
CHECK (Roli in ('Admin','Alumni','Student'))
);


--DROP TABLE IF EXISTS [IF]

/*Create Table [IF](
InstitutiID int NOT NULL FOREIGN KEY references [Instituti](InstitutiID),
FakultetiID int NOT NULL FOREIGN KEY references [Fakulteti](FakultetiID),
Primary Key(InstitutiID,FakultetiID)
);*/

DROP TABLE IF EXISTS [Feedback]

Create Table [Feedback](
IDFeedback int IDENTITY(1,1) PRIMARY KEY,
Permbajtja varchar(1000) NOT NULL,
Data date NOT NULL,
InstitutiID int NOT NULL FOREIGN KEY references [Instituti](InstitutiID) , 
FakultetiID int NOT NULL FOREIGN KEY references [Fakulteti](FakultetiID) , 
UserID int NOT NULL FOREIGN KEY references [User](ID_User) , 
);


