if exists (select * from sysobjects where id = object_id(N'[dbo].[Groups]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Groups]
GO

CREATE TABLE [dbo].[Groups] (
	[GID] [int] NOT NULL ,
	[Title] [nvarchar] (255) NOT NULL ,
	[Description] [nvarchar] (3000) NULL ,
	[GroupIcon] [varchar] (500) NULL ,
	[MaxFileSize] [int] NOT NULL ,
	[TotalMembers] [int] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Groups] WITH NOCHECK ADD 
	CONSTRAINT [PK_Groups] PRIMARY KEY  NONCLUSTERED 
	(
		[GID]
	)  ON [PRIMARY] 
GO

