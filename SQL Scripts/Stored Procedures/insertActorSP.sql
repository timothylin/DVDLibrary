USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[InsertActor]    Script Date: 11/12/2015 2:50:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[InsertActor] (
@FirstName varchar(50),
@LastName varchar(50),
@ActorID int output
)
as
begin
insert into Actors(FirstName, LastName)
values (@FirstName, @LastName)

set @ActorID = SCOPE_IDENTITY();
end

GO

