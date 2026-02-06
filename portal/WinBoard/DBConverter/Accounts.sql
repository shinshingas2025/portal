if exists (select * from sysobjects where id = object_id(N'[dbo].[Accounts]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Accounts]
GO

CREATE TABLE [dbo].[Accounts] (
	[Username] [varchar] (20) NOT NULL ,
	[Password] [char] (13) NOT NULL ,
	[Status] [smallint] NOT NULL ,
	[Level] [smallint] NOT NULL ,
	[GID] [int] NOT NULL ,
	[LevelText] [nvarchar] (255) NULL ,
	[GroupText] [nvarchar] (255) NULL ,
	[Nickname] [nvarchar] (30) NOT NULL ,
	[Email] [varchar] (50) NOT NULL ,
	[TotalPosts] [int] NOT NULL ,
	[RegisteredDate] [datetime] NOT NULL ,
	[LastPostDate] [datetime] NULL ,
	[LastLoginDate] [datetime] NULL ,
	[Host] [varchar] (15) NULL ,
	[IP] [varchar] (15) NULL ,
	[HideEmail] [bit] NOT NULL ,
	[Approved] [bit] NOT NULL ,
	[ParentEmail] [varchar] (50) NULL ,
	[Homepage] [varchar] (300) NULL ,
	[Location] [nvarchar] (50) NULL ,
	[Occupation] [nvarchar] (30) NULL ,
	[Interest] [nvarchar] (50) NULL ,
	[ICQ] [int] NULL ,
	[Age] [tinyint] NULL ,
	[Comments] [nvarchar] (300) NULL ,
	[Signature] [nvarchar] (300) NULL ,
	[Photo] [varchar] (50) NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Accounts] WITH NOCHECK ADD 
	CONSTRAINT [PK_Accounts] PRIMARY KEY  NONCLUSTERED 
	(
		[Username]
	)  ON [PRIMARY] 
GO

