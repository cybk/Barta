CREATE TABLE Protect ( 
	ID int NOT NULL,
	SettingsID int NOT NULL,
	ContactsID int NOT NULL,
	EncKey nvarchar(50) NOT NULL,
	Salt nvarchar(20),
	Enable bit DEFAULT 1 NOT NULL,
	Added datetime NOT NULL,
	Modified datetime NOT NULL
)
;

CREATE TABLE HistoryConference ( 
	ID int NOT NULL,
	ConferenceID int NOT NULL,
	Sender int NOT NULL,
	Message nvarchar(1000) NOT NULL,
	Added datetime NOT NULL,
	Modified datetime NOT NULL
)
;

CREATE TABLE Conf_Participant ( 
	ID int NOT NULL,
	ConferenceID int NOT NULL,
	ContactsID int NOT NULL,
	Added datetime NOT NULL,
	Modified datetime NOT NULL
)
;

CREATE TABLE Conference ( 
	ID int NOT NULL,
	SettingsID int NOT NULL,
	Added datetime NOT NULL,
	Modified datetime NOT NULL
)
;

CREATE TABLE History ( 
	ID int NOT NULL,
	Sender int NOT NULL,
	SettingsID int NOT NULL,
	Message nvarchar(1000) NOT NULL,
	Added datetime NOT NULL,
	Modified datetime NOT NULL
)
;

CREATE TABLE Contacts ( 
	ID int NOT NULL,
	JID nvarchar(100) NOT NULL,
	SettingsID int NOT NULL,
	Deleted binary() DEFAULT 0 NOT NULL,
	Added datetime NOT NULL,
	Modified datetime NOT NULL
)
;

CREATE TABLE Settings ( 
	ID int NOT NULL,
	JID nvarchar(100),
	Server nvarchar(100) NOT NULL,
	UserName nvarchar(100) NOT NULL,
	Pass nvarchar(100) NOT NULL,
	Salt nvarchar(10),
	port int DEFAULT 5222 NOT NULL,
	UseSsl bit DEFAULT 0 NOT NULL,
	Added datetime NOT NULL,
	Modified datetime NOT NULL
)
;


ALTER TABLE Protect ADD CONSTRAINT PK_Protect 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE HistoryConference ADD CONSTRAINT PK_HistoryConference 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Conf_Participant ADD CONSTRAINT PK_Conf_Participant 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Conference ADD CONSTRAINT PK_Conference 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE History ADD CONSTRAINT PK_History 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Contacts ADD CONSTRAINT PK_Contacts 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Settings ADD CONSTRAINT PK_Settings 
	PRIMARY KEY CLUSTERED (ID)
;


ALTER TABLE HistoryConference
	ADD CONSTRAINT UQ_HistoryConference_ID UNIQUE (ID)
;

ALTER TABLE Conf_Participant
	ADD CONSTRAINT UQ_Conf_Participant_ID UNIQUE (ID)
;

ALTER TABLE Conference
	ADD CONSTRAINT UQ_Conference_ID UNIQUE (ID)
;

ALTER TABLE History
	ADD CONSTRAINT UQ_History_ID UNIQUE (ID)
;

ALTER TABLE Contacts
	ADD CONSTRAINT UQ_Contacts_ID UNIQUE (ID)
;

ALTER TABLE Settings
	ADD CONSTRAINT UQ_Settings_ID UNIQUE (ID)
;

ALTER TABLE Settings
	ADD CONSTRAINT UQ_Settings_JID UNIQUE (JID)
;


ALTER TABLE Protect ADD CONSTRAINT FK_Protect_Contacts 
	FOREIGN KEY (ContactsID) REFERENCES Contacts (ID)
;

ALTER TABLE Protect ADD CONSTRAINT FK_Protect_Settings 
	FOREIGN KEY (SettingsID) REFERENCES Settings (ID)
;

ALTER TABLE HistoryConference ADD CONSTRAINT FK_HistoryConference_Conference 
	FOREIGN KEY (ConferenceID) REFERENCES Conference (ID)
;

ALTER TABLE Conf_Participant ADD CONSTRAINT FK_Conf_Participant_Conference 
	FOREIGN KEY (ConferenceID) REFERENCES Conference (ID)
;

ALTER TABLE Conf_Participant ADD CONSTRAINT FK_Conf_Participant_Contacts 
	FOREIGN KEY (ContactsID) REFERENCES Contacts (ID)
;

ALTER TABLE Conference ADD CONSTRAINT FK_Conference_Settings 
	FOREIGN KEY (SettingsID) REFERENCES Settings (ID)
;

ALTER TABLE History ADD CONSTRAINT FK_History_Settings 
	FOREIGN KEY (SettingsID) REFERENCES Settings (ID)
;

ALTER TABLE Contacts ADD CONSTRAINT FK_Contacts_Settings 
	FOREIGN KEY (SettingsID) REFERENCES Settings (ID)
;
