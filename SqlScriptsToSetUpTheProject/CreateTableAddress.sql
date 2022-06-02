Create Table [dbo].[Address] (
  [Id] int identity not null,
  [StreetName] varchar(45) not null,
  [Neighborhood] varchar(45) not null,
  [City] varchar(45) not null,
  [PostalCode] varchar(45) not null

  Constraint [Pk_Address] Primary Key Clustered ([Id]ASC)
);