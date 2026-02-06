if exists (select * from sysobjects where id = object_id(N'[dbo].[Categories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Categories]
GO

CREATE TABLE [dbo].[Categories] (
	[CID] [int] NOT NULL ,
	[Title] [nvarchar] (255) NOT NULL ,
	[Description] [nvarchar] (3000) NULL ,
	[TotalBoards] [int] NOT NULL ,
	[TotalPosts] [int] NOT NULL ,
	[TotalTopics] [int] NOT NULL ,
	[LastUpdateDate] [datetime] NULL ,
	[Position] [smallint] NULL ,
	[Status] [smallint] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Categories] WITH NOCHECK ADD 
	CONSTRAINT [PK_Categories] PRIMARY KEY  NONCLUSTERED 
	(
		[CID]
	)  ON [PRIMARY] 
GO

