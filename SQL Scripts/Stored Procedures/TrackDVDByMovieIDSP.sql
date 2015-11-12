USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[TrackDVDByMovieID]    Script Date: 11/12/2015 5:12:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[TrackDVDByMovieID] (
	@MovieID int 
)
as

Begin
	select m.MovieID, b.BorrowerID, b.FirstName, b.LastName, mb.DateBorrowed,
	mb.DateReturned, mb.UserRating, mb.UserNotes, m.MovieTitle, m.ReleaseDate,
	mpaa.FilmRating, d.FirstName, d.LastName, s.StudioName
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

