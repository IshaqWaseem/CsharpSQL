USE [SuperheroesDb]
GO

INSERT INTO [dbo].[Power]
           (Power_name
           ,Power_Description)
     VALUES
           ('Enhanced strength'
           ,'Stronger than a normal human')
INSERT INTO [dbo].[Power]
           (Power_name
           ,Power_Description)
     VALUES
           ('High intelligence'
           ,'Smarter than a normal human')
INSERT INTO [dbo].[Power]
           (Power_name
           ,Power_Description)
     VALUES
           ('Laser eyes'
           ,'Shoots laser beams out of eyes')
INSERT INTO [dbo].[Power]
           (Power_name
           ,Power_Description)
     VALUES
           ('Flight'
           ,'Can fly without equipment')


INSERT INTO [dbo].[superhero_power]
           (SuperheroId
           ,PowerId)
     VALUES
           (1
           ,2)
INSERT INTO [dbo].[superhero_power]
           (SuperheroId
           ,PowerId)
     VALUES
           (2
           ,3)
INSERT INTO [dbo].[superhero_power]
           (SuperheroId
           ,PowerId)
     VALUES
           (2
           ,4)
INSERT INTO [dbo].[superhero_power]
           (SuperheroId
           ,PowerId)
     VALUES
           (3
           ,1)
GO


