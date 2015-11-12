USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[InsertMPAARatings]    Script Date: 11/11/2015 5:36:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[InsertMPAARatings](
@FilmRating nchar(50),
@MPAARatingID int output
) as
begin

insert into MPAARatings(FilmRating)
values (@FilmRating)

set @MPAARatingID = SCOPE_IDENTITY();

End

GO

