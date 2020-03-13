USE [FBDb]
GO

/****** Object:  Table [dbo].[LogActivities]    Script Date: 13-03-2020 11:51:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogActivities](
	[LogActivityId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
	[Activity] [varchar](50) NOT NULL,
 CONSTRAINT [PK__LogActiv__029BCDD4980DDCE5] PRIMARY KEY CLUSTERED 
(
	[LogActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LogActivities]  WITH CHECK ADD  CONSTRAINT [FK_LogActivities_FacebookUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[FacebookUsers] ([UserID])
GO

ALTER TABLE [dbo].[LogActivities] CHECK CONSTRAINT [FK_LogActivities_FacebookUsers]
GO

ALTER TABLE [dbo].[LogActivities]  WITH CHECK ADD  CONSTRAINT [FK_LogActivities_UserPosts] FOREIGN KEY([PostId])
REFERENCES [dbo].[UserPosts] ([PostId])
GO

ALTER TABLE [dbo].[LogActivities] CHECK CONSTRAINT [FK_LogActivities_UserPosts]
GO

