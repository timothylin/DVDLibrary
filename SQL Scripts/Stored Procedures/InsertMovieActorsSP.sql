USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[InsertMovieActors]    Script Date: 11/12/2015 2:49:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[InsertMovieActors] (
@ActorID int,
@MovieID int
)
as
begin
insert into MovieActors(ActorID, MovieID)
values (@ActorID, @MovieID)
end
GO

