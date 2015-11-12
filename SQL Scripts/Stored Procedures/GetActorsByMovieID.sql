USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[GetActorsByMovieID]    Script Date: 11/12/2015 2:48:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetActorsByMovieID] (
@MovieID int
)
as
begin
select m.MovieID, m.MovieTitle, a.ActorID, a.FirstName, a.LastName
	from MovieActors ma
	inner join Actors a
	on ma.ActorID = a.ActorID
	inner join Movies m
	on ma.MovieID = m.MovieID
	where ma.MovieID = @MovieID
end

GO

