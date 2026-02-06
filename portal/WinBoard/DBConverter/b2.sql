BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
COMMIT
BEGIN TRANSACTION
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_Root
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_Replies
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_RepliesCnt
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_TotalModified
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_Notification
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_Symbol
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_Approved
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_ReadOnly
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_Attachment
GO
ALTER TABLE dbo.#b1#
	DROP CONSTRAINT DF_#b1#_Hits
GO
CREATE TABLE dbo.Tmp_#b1#
	(
 	PID int NOT NULL IDENTITY (1, 1),
	Subject nvarchar(255) NOT NULL,
	Username varchar(20) NULL,
	UEmail nvarchar(255) NOT NULL,
	UNickname nvarchar(255) NOT NULL,
	Root int NOT NULL CONSTRAINT DF_#b1#_Root DEFAULT (0),
	Replies varchar(6000) NOT NULL CONSTRAINT DF_#b1#_Replies DEFAULT (''),
	RepliesCnt int NOT NULL CONSTRAINT DF_#b1#_RepliesCnt DEFAULT (0),
	PostDate datetime NOT NULL,
	LastPostDate datetime NOT NULL,
	LastUpdateDate datetime NOT NULL,
	TotalModified int NOT NULL CONSTRAINT DF_#b1#_TotalModified DEFAULT (0),
	Host varchar(50) NOT NULL,
	IP varchar(15) NOT NULL,
	Notification bit NOT NULL CONSTRAINT DF_#b1#_Notification DEFAULT (0),
	Signature bit NOT NULL,
	Symbol tinyint NOT NULL CONSTRAINT DF_#b1#_Symbol DEFAULT (0),
	Approved bit NOT NULL CONSTRAINT DF_#b1#_Approved DEFAULT (1),
	ReadOnly bit NOT NULL CONSTRAINT DF_#b1#_ReadOnly DEFAULT (0),
	Attachment bit NOT NULL CONSTRAINT DF_#b1#_Attachment DEFAULT (0),
	Hits int NOT NULL CONSTRAINT DF_#b1#_Hits DEFAULT (0),
	BodySrc ntext NOT NULL,
	BodyHTML ntext NOT NULL
	) ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_#b1# ON
GO
IF EXISTS(SELECT * FROM dbo.#b1#)
	 EXEC('INSERT INTO dbo.Tmp_#b1#(PID, Subject, Username, UEmail, UNickname, Root, Replies, RepliesCnt, PostDate, LastPostDate, LastUpdateDate, TotalModified, Host, IP, Notification, Signature, Symbol, Approved, ReadOnly, Attachment, Hits, BodySrc, BodyHTML)
		SELECT PID, Subject, Username, UEmail, UNickname, Root, Replies, RepliesCnt, PostDate, LastPostDate, LastUpdateDate, TotalModified, Host, IP, Notification, Signature, Symbol, Approved, ReadOnly, Attachment, Hits, BodySrc, BodyHTML FROM dbo.#b1# TABLOCKX')
GO
SET IDENTITY_INSERT dbo.Tmp_#b1# OFF
GO
DROP TABLE dbo.#b1#
GO
EXECUTE sp_rename 'dbo.Tmp_#b1#', '#b1#'
GO
ALTER TABLE dbo.#b1# ADD CONSTRAINT
	PK_#b1# PRIMARY KEY NONCLUSTERED 
	(
	PID
	) ON [PRIMARY]
GO
COMMIT
