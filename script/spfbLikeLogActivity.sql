USE [FBDb]
GO

/****** Object:  StoredProcedure [dbo].[spLikeLogActivities]    Script Date: 13-03-2020 11:52:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spLikeLogActivities]
 @userid int , @postid int 


as

insert into PostLikes values (@userid,@postid)
declare @User varchar(50)
declare @firstname varchar(50)
select PostId from UserPosts where UserId=@userId and PostId=@postId;
 
select @User= FirstName from FacebookUsers where UserId=@userId
select @firstName = UserName from vAllPosts where PostId = @postid
insert into LogActivities values (@userid,@postid,'you Like On' + @firstname +' Post');
GO

