USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[TrackDVDByMovieID]    Script Date: 11/13/2015 3:02:47 PM ******/
DROP PROCEDURE [dbo].[TrackDVDByMovieID]
GO

/****** Object:  StoredProcedure [dbo].[TrackDVDByMovieID]    Script Date: 11/13/2015 3:02:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[TrackDVDByMovieID] (
	@MovieID int 
)
as

Begin
	select m.MovieID, b.BorrowerID, b.FirstName as bFirstName, b.LastName as bLastName, mb.DateBorrowed,
	mb.DateReturned, mb.UserRating, mb.UserNotes, m.MovieTitle, m.ReleaseDate,
	mpaa.FilmRating, d.DirectorID, d.FirstName as dFirstName, d.LastName as dLastName, s.StudioName
		from MovieBorrower mb
		inner join Movies m
		on mb.MovieID = m.MovieID
		inner join Borrowers b
		on mb.BorrowerID = b.BorrowerID
		inner join MPAARatings mpaa
		on mpaa.MPAARatingID = m.MPAARatingID
		inner join Directors d
		on d.DirectorID = m.DirectorID
		inner join Studios s
		on s.StudioID = m.StudioID
		where m.MovieID = @MovieID

end


GO

