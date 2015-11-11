USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[InsertMovies]    Script Date: 11/11/2015 5:36:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[InsertMovies](
@MovieTitle varchar(50),
@MPAARatingID int,
@DirectorID int,
@StudioID int,
@ReleaseDate int,
@MovieID int output
) as
begin

insert into Movies(MovieTitle, MPAARatingID, DirectorID, StudioID, ReleaseDate )
values (@MovieTitle, @MPAARatingID, @DirectorID, @StudioID, @ReleaseDate)

set @MovieID = SCOPE_IDENTITY();

End

GO

