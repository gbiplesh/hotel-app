CREATE TABLE [dbo].[Bookings] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [RoomId]     INT NULL,
    [FullName]     NVARCHAR (MAX) NULL,
    [RoomQuantity] INT            NOT NULL,
    [CheckIn]      DATETIME2 (7)  NOT NULL,
    [CheckOut]     DATETIME2 (7)  NOT NULL,
    [Price]        INT            NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

