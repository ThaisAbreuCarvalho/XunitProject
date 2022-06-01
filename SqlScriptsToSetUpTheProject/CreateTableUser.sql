Create  Database LifeBalance;

Drop Table IF Exists [dbo].[User];

Create Table [dbo].[User] (
  [Id] int identity not null,
  [Name] varchar(45) not null,
  [Surname] varchar(45) not null

  Constraint [Pk_User] Primary Key Clustered ([Id]ASC)
);

