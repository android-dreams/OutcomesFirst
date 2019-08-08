USE [OutcomesFirst]
GO

--INSERT INTO [dbo].[Occupancy] 
--     ([OccupancyRefId],[OccupancyRefReceivedDate],[OccupancyFirstName],[OccupancyLastName] ,[OccupancyGenderId]
--           ,[OccupancyType],[OccupancyServiceTransition],[OccupancyServiceId] 
--           ,[OccupancyDateStartedWithGroup],[OccupancyPlacementStartDate],[OccupancyDOB],[OccupancyAgeAtLeaving]
--           ,[OccupancyLocalAuthorityId] ,[OccupancyFramework],[OccupancyWeeklyFee] ,[OccupancyLengthOfStayWithGroup]
--           ,[OccupancyLengthOfStayWithPlacement] ,[OccupancyNotes],[OccupancyLeaveDate],[OccupancyLeaverType]
--           ,[OccupancyReasonForLeavingID]
--		   )
--		   VALUES ('JP',N'2019-01-04 00:00:00','Jan','Bryan',2,	
--		   1,0,22,
--		   N'2019-01-04 00:00:00', N'2019-01-04 00:00:00', N'2012-03-14 00:00:00',NULL,
--		   8, 1,NULL,NULL,
--		   NULL,'System generated',NULL,NULL,NULL)

		   INSERT INTO [dbo].[Occupancy] 
		    ([OccupancyRefId],[OccupancyRefReceivedDate],[OccupancyFirstName],[OccupancyLastName] ,[OccupancyGenderId]
           ,[OccupancyType],[OccupancyServiceTransition],[OccupancyServiceId] 
           ,[OccupancyDateStartedWithGroup],[OccupancyPlacementStartDate],[OccupancyDOB],[OccupancyAgeAtLeaving]
           ,[OccupancyLocalAuthorityId] ,[OccupancyFramework],[OccupancyWeeklyFee] ,[OccupancyLengthOfStayWithGroup]
           ,[OccupancyLengthOfStayWithPlacement] ,[OccupancyNotes],[OccupancyLeaveDate],[OccupancyLeaverType]
           ,[OccupancyReasonForLeavingID])
		   VALUES ('Lucy',N'2019-01-04 00:00:00','Lucy','Bryan',2,
		   2,0,25,
		    N'2019-01-04 00:00:00', N'2019-01-04 00:00:00', N'2012-03-14 00:00:00',NULL,
		   4, 1,NULL,NULL,
		   NULL,'System generated',NULL,NULL,
		   NULL)

		   INSERT INTO [dbo].[Occupancy] 
		    ([OccupancyRefId],[OccupancyRefReceivedDate],[OccupancyFirstName],[OccupancyLastName] ,[OccupancyGenderId]
           ,[OccupancyType],[OccupancyServiceTransition],[OccupancyServiceId] 
           ,[OccupancyDateStartedWithGroup],[OccupancyPlacementStartDate],[OccupancyDOB],[OccupancyAgeAtLeaving]
           ,[OccupancyLocalAuthorityId] ,[OccupancyFramework],[OccupancyWeeklyFee] ,[OccupancyLengthOfStayWithGroup]
           ,[OccupancyLengthOfStayWithPlacement] ,[OccupancyNotes],[OccupancyLeaveDate],[OccupancyLeaverType]
           ,[OccupancyReasonForLeavingID])
		   VALUES ('Diane',N'2019-02-03 00:00:00','Diane','Fulford',2,
		   2,0,31,
		   N'2019-01-04 00:00:00',N'2019-01-04 00:00:00',N'2012-03-14 00:00:00',NULL,
		   1,NULL,NULL,NULL,
		   NULL,'System generated',NULL,NULL,
		   NULL)

		   INSERT INTO [dbo].[Occupancy] 
		    ([OccupancyRefId],[OccupancyRefReceivedDate],[OccupancyFirstName],[OccupancyLastName] ,[OccupancyGenderId]
           ,[OccupancyType],[OccupancyServiceTransition],[OccupancyServiceId] 
           ,[OccupancyDateStartedWithGroup],[OccupancyPlacementStartDate],[OccupancyDOB],[OccupancyAgeAtLeaving]
           ,[OccupancyLocalAuthorityId] ,[OccupancyFramework],[OccupancyWeeklyFee] ,[OccupancyLengthOfStayWithGroup]
           ,[OccupancyLengthOfStayWithPlacement] ,[OccupancyNotes],[OccupancyLeaveDate],[OccupancyLeaverType]
           ,[OccupancyReasonForLeavingID])
		   VALUES ('Mary',N'2019-01-04 00:00:00','Mary','Dobson',2,
		   1,0,24,
		   N'2019-01-04 00:00:00',N'2019-01-04 00:00:00',N'2009-05-1 00:00:00',NULL,
		   1,NULL,NULL,NULL,
		   NULL,'System generated',NULL,NULL,
		   NULL)

	
		  
GO


