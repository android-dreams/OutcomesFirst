USE [OutcomesFirst]
GO

INSERT INTO [dbo].[Placement] 
     ([PlacementRefId],[PlacementFirstName],[PlacementLastName] ,[PlacementGenderId]
           ,[PlacementType],[PlacementServiceTransition],[PlacementServiceId] 
           ,[PlacementDateStartedWithGroup],[PlacementPlacementStartDate],[PlacementDOB],[PlacementAgeAtLeaving]
           ,[PlacementLocalAuthorityId] ,[PlacementFramework],[PlacementWeeklyFee] ,[PlacementLengthOfStayWithGroup]
           ,[PlacementLengthOfStayWithPlacement] ,[PlacementNotes],[PlacementLeaveDate],[PlacementLeaverType]
           ,[PlacementLeavingReasonId]
		   )
		   VALUES ('JP','Jan','Bryan',2,	
		   1,0,22,
		   N'2019-01-04 00:00:00', N'2019-01-04 00:00:00', N'2012-03-14 00:00:00',NULL,
		   8, 1,NULL,NULL,
		   NULL,'System generated',NULL,NULL
		   ,NULL)

		   INSERT INTO [dbo].[Placement] 
		    ([PlacementRefId],[PlacementFirstName],[PlacementLastName] ,[PlacementGenderId]
           ,[PlacementType],[PlacementServiceTransition],[PlacementServiceId] 
           ,[PlacementDateStartedWithGroup],[PlacementPlacementStartDate],[PlacementDOB],[PlacementAgeAtLeaving]
           ,[PlacementLocalAuthorityId] ,[PlacementFramework],[PlacementWeeklyFee] ,[PlacementLengthOfStayWithGroup]
           ,[PlacementLengthOfStayWithPlacement] ,[PlacementNotes],[PlacementLeaveDate],[PlacementLeaverType]
           ,[PlacementLeavingReasonId])
		   VALUES ('Lucy','Lucy','Bryan',2,
		   2,0,25,
		    N'2019-01-04 00:00:00', N'2019-01-04 00:00:00', N'2012-03-14 00:00:00',NULL,
		   4, 1,NULL,NULL,
		   NULL,'System generated',NULL,NULL,
		   NULL)

		   INSERT INTO [dbo].[Placement] 
		    ([PlacementRefId],[PlacementFirstName],[PlacementLastName] ,[PlacementGenderId]
           ,[PlacementType],[PlacementServiceTransition],[PlacementServiceId] 
           ,[PlacementDateStartedWithGroup],[PlacementPlacementStartDate],[PlacementDOB],[PlacementAgeAtLeaving]
           ,[PlacementLocalAuthorityId] ,[PlacementFramework],[PlacementWeeklyFee] ,[PlacementLengthOfStayWithGroup]
           ,[PlacementLengthOfStayWithPlacement] ,[PlacementNotes],[PlacementLeaveDate],[PlacementLeaverType]
           ,[PlacementLeavingReasonId])
		   VALUES ('Diane','Diane','Fulford',2,
		   2,0,31,
		   N'2019-01-04 00:00:00',N'2019-01-04 00:00:00',N'2012-03-14 00:00:00',NULL,
		   1,NULL,NULL,NULL,
		   NULL,'System generated',NULL,NULL,
		   NULL)

		   INSERT INTO [dbo].[Placement] 
		    ([PlacementRefId],[PlacementFirstName],[PlacementLastName] ,[PlacementGenderId]
           ,[PlacementType],[PlacementServiceTransition],[PlacementServiceId] 
           ,[PlacementDateStartedWithGroup],[PlacementPlacementStartDate],[PlacementDOB],[PlacementAgeAtLeaving]
           ,[PlacementLocalAuthorityId] ,[PlacementFramework],[PlacementWeeklyFee] ,[PlacementLengthOfStayWithGroup]
           ,[PlacementLengthOfStayWithPlacement] ,[PlacementNotes],[PlacementLeaveDate],[PlacementLeaverType]
           ,[PlacementLeavingReasonId])
		   VALUES ('Mary','Mary','Dobson',2,
		   1,0,24,
		   N'2019-01-04 00:00:00',N'2019-01-04 00:00:00',N'2009-05-1 00:00:00',NULL,
		   1,NULL,NULL,NULL,
		   NULL,'System generated',NULL,NULL,
		   NULL)

	
		  
GO


