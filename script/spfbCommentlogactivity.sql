USE [FBDb]
GO

/****** Object:  StoredProcedure [dbo].[spLogActivities]    Script Date: 13-03-2020 11:52:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spLogActivities]
@Comment varchar(50) ,@userid int , @postid int 


as
if(@Comment!=null)

insert into PostComments values (@Comment,@userid,@postid)
declare @User varchar(50)
declare @firstname varchar(50)
select PostId from UserPosts where UserId=@userId and PostId=@postId;
 
select @User= FirstName from FacebookUsers where UserId=@userId
select @firstName = UserName from vAllPosts where PostId = @postid
insert into LogActivities values (@userid,@postid,'you Comment On' + @firstname +' Post');

GO

