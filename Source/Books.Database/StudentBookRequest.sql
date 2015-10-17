CREATE TABLE [DemandTrack].[StudentBookRequest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[StudentId] INT NOT NULL,
	[BookId] nvarchar(15) NOT NULL,
)
