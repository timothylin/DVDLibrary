USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[CheckInDVD]    Script Date: 11/10/2015 11:45:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[CheckInDVD] as

Begin
	select m.MovieID, b.BorrowerID, mb.DateBorrowed, mb.DateReturned, mb.UserRating, mb.UserNotes, m.MovieTitle, m.ReleaseDate,
	b.FirstName, b.LastName, mpaa.FilmRating, d.FirstName, d.LastName, s.StudioName
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
		where mb.DateReturned is null and mb.DateBorrowed is not null

end

GO

