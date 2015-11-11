USE [DVDLibrary]
GO

/****** Object:  StoredProcedure [dbo].[InsertStudio]    Script Date: 11/11/2015 5:37:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[InsertStudio](
@StudioName nchar(50),
@StudioID int output
) as
begin

insert into Studios(StudioName)
values (@StudioName)

set @StudioID = SCOPE_IDENTITY();

End

GO

