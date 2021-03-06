CREATE TABLE ConferenceContact ( 
	ConferenceID int NOT NULL,
	ContactID int NOT NULL
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

CREATE TABLE Contact ( 
	ID int NOT NULL,
	JID nvarchar(100) NOT NULL,
	SettingsID int NOT NULL,
	Deleted bit DEFAULT 0 NOT NULL,
	EncKey nvarchar(50),
	Salt nvarchar(20),
	EnableEnc bit DEFAULT 0 NOT NULL,
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
	Modified datetime NOT NULL,
	DownloadPath nvarchar(200)
)
;


ALTER TABLE HistoryConference ADD CONSTRAINT PK_HistoryConference 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Conference ADD CONSTRAINT PK_Conference 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE History ADD CONSTRAINT PK_History 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Contact ADD CONSTRAINT PK_Contacts 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Settings ADD CONSTRAINT PK_Settings 
	PRIMARY KEY CLUSTERED (ID)
;


ALTER TABLE HistoryConference
	ADD CONSTRAINT UQ_HistoryConference_ID UNIQUE (ID)
;

ALTER TABLE Conference
	ADD CONSTRAINT UQ_Conference_ID UNIQUE (ID)
;

ALTER TABLE History
	ADD CONSTRAINT UQ_History_ID UNIQUE (ID)
;

ALTER TABLE Contact
	ADD CONSTRAINT UQ_Contacts_ID UNIQUE (ID)
;

ALTER TABLE Settings
	ADD CONSTRAINT UQ_Settings_ID UNIQUE (ID)
;

ALTER TABLE Settings
	ADD CONSTRAINT UQ_Settings_JID UNIQUE (JID)
;


ALTER TABLE ConferenceContact ADD CONSTRAINT FK_ConferenceParticipant_Conference 
	FOREIGN KEY (ConferenceID) REFERENCES Conference (ID)
;

ALTER TABLE ConferenceContact ADD CONSTRAINT FK_ConferenceParticipant_Contact 
	FOREIGN KEY (ContactID) REFERENCES Contact (ID)
;

ALTER TABLE HistoryConference ADD CONSTRAINT FK_HistoryConference_Conference 
	FOREIGN KEY (ConferenceID) REFERENCES Conference (ID)
;

ALTER TABLE Conference ADD CONSTRAINT FK_Conference_Settings 
	FOREIGN KEY (SettingsID) REFERENCES Settings (ID)
;

ALTER TABLE History ADD CONSTRAINT FK_History_Settings 
	FOREIGN KEY (SettingsID) REFERENCES Settings (ID)
;

ALTER TABLE Contact ADD CONSTRAINT FK_Contacts_Settings 
	FOREIGN KEY (SettingsID) REFERENCES Settings (ID)
;
