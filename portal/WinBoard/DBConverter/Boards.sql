if exists (select * from sysobjects where id = object_id(N'[dbo].[Boards]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Boards]
GO

CREATE TABLE [dbo].[Boards] (
	[BID] [int] NOT NULL ,
	[Title] [nvarchar] (30) NOT NULL ,
	[Description] [nvarchar] (255) NULL ,
	[Category] [int] NOT NULL ,
	[MajorModerator] [nvarchar] (255) NULL ,
	[MajorModeratorNicname] [nvarchar] (255) NULL ,
	[MajorModeratorEmail] [nvarchar] (255) NULL ,
	[MinorModerators] [nvarchar] (255) NULL ,
	[TotalPosts] [int] NOT NULL ,
	[TotalTopics] [int] NOT NULL ,
	[Status] [smallint] NOT NULL ,
	[WBCodes] [bit] NOT NULL ,
	[HTMLTags] [bit] NOT NULL ,
	[NeedApproved] [bit] NOT NULL ,
	[Subscription] [bit] NOT NULL ,
	[FileAttach] [bit] NOT NULL ,
	[Expire] [bit] NOT NULL ,
	[Redirect] [nvarchar] (255) NULL ,
	[Skin] [nvarchar] (30) NOT NULL ,
	[LastPostDate] [datetime] NOT NULL ,
	[LastUpdateDate] [datetime] NOT NULL ,
	[Position] [int] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Boards] WITH NOCHECK ADD 
	CONSTRAINT [PK_boards] PRIMARY KEY  NONCLUSTERED 
	(
		[BID]
	)  ON [PRIMARY] 
GO

