USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[InsertDirector]    Script Date: 11/11/2015 5:35:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[InsertDirector](
@FirstName nchar(50),
@LastName nchar (50),
@DirectorID int output
) as
begin
insert into Directors(FirstName, LastName)
values (@FirstName, @LastName)

set @DirectorID = SCOPE_IDENTITY();

End

GO

