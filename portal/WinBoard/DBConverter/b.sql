if exists (select * from sysobjects where id = object_id(N'[dbo].[#b1#]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[#b1#]
GO

CREATE TABLE [dbo].[#b1#] (
	[PID] [int] NOT NULL ,
	[Subject] [nvarchar] (255) NOT NULL ,
	[Username] [varchar] (20) NULL ,
	[UEmail] [nvarchar] (255) NOT NULL ,
	[UNickname] [nvarchar] (255) NOT NULL ,
	[Root] [int] NOT NULL ,
	[Replies] [varchar] (6000) NOT NULL ,
	[RepliesCnt] [int] NOT NULL ,
	[PostDate] [datetime] NOT NULL ,
	[LastPostDate] [datetime] NOT NULL ,
	[LastUpdateDate] [datetime] NOT NULL ,
	[TotalModified] [int] NOT NULL ,
	[Host] [varchar] (50) NOT NULL ,
	[IP] [varchar] (15) NOT NULL ,
	[Notification] [bit] NOT NULL ,
	[Signature] [bit] NOT NULL ,
	[Symbol] [tinyint] NOT NULL ,
	[Approved] [bit] NOT NULL ,
	[ReadOnly] [bit] NOT NULL ,
	[Attachment] [bit] NOT NULL ,
	[Hits] [int] NOT NULL ,
	[BodySrc] [ntext] NOT NULL ,
	[BodyHTML] [ntext] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[#b1#] WITH NOCHECK ADD 
	CONSTRAINT [DF_#b1#_Root] DEFAULT (0) FOR [Root],
	CONSTRAINT [DF_#b1#_Replies] DEFAULT ('') FOR [Replies],
	CONSTRAINT [DF_#b1#_RepliesCnt] DEFAULT (0) FOR [RepliesCnt],
	CONSTRAINT [DF_#b1#_TotalModified] DEFAULT (0) FOR [TotalModified],
	CONSTRAINT [DF_#b1#_Notification] DEFAULT (0) FOR [Notification],
	CONSTRAINT [DF_#b1#_Symbol] DEFAULT (0) FOR [Symbol],
	CONSTRAINT [DF_#b1#_Approved] DEFAULT (1) FOR [Approved],
	CONSTRAINT [DF_#b1#_ReadOnly] DEFAULT (0) FOR [ReadOnly],
	CONSTRAINT [DF_#b1#_Attachment] DEFAULT (0) FOR [Attachment],
	CONSTRAINT [DF_#b1#_Hits] DEFAULT (0) FOR [Hits]
GO

