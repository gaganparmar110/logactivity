USE [FBDb]
GO

/****** Object:  StoredProcedure [dbo].[spShareLogActivities]    Script Date: 13-03-2020 11:52:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spShareLogActivities]
 @userid int , @postid int 


as

insert into PostShares values (@userid,@postid)
declare @User varchar(50)
declare @firstname varchar(50)
select PostId from UserPosts where UserId=@userId and PostId=@postId;
 
select @User= FirstName from FacebookUsers where UserId=@userId
select @firstName = UserName from vAllPosts where PostId = @postid
insert into LogActivities values (@userid,@postid,'you Share ' + @firstname +' Post');
GO

