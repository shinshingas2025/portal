if exists (select * from sysobjects where id = object_id(N'[dbo].[Session]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Session]
GO

CREATE TABLE [dbo].[Session] (
	[SID] [int] IDENTITY (1, 1) NOT NULL ,
	[Hash] [char] (32) NOT NULL ,
	[Username] [varchar] (20) NOT NULL ,
	[LoginDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Session] WITH NOCHECK ADD 
	CONSTRAINT [PK_Session] PRIMARY KEY  NONCLUSTERED 
	(
		[SID]
	)  ON [PRIMARY] 
GO

