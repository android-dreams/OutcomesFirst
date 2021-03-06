USE [OutcomesFirst]
GO
/****** Object:  StoredProcedure [dbo].[Rep_Leavers]    Script Date: 22/10/2019 16:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Rep_Leavers] 
--exec Rep_Leavers 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT o.PLacementFirstName,
	o.PLacementLastName,
	g.GenderName as PlacementGenderId,
	case when PlacementType = 1 then 'Education & Residential'
	        when PlacementType = 1 then 'Education only'
			when PlacementType = 1 then 'Residential only'
			else '' end as PlacementType,
	o.PLacementDateStartedWithGroup,
	o.PLacementPlacementStartDate,
	o.PLacementDOB,
	o.PLacementLocalAuthorityId,
	o.PLacementFramework,
	o.PLacementLengthOfStayWithPlacement,
	o.PLacementNotes
	PLacementLengthOfStayWithGroup,
	serv.ServiceName,
	serv.ServicePlaces,
	o.PlacementServiceTransition,
	o.PlacementWeeklyFee,
	o.PlacementNotes,
	o.PlacementLeaveDate,
	o.PlacementLeaverType,
	lr.LeavingReasonName
	 from PLacement o
	  left outer join Service serv on o.PLacementServiceId = serv.ServiceId
	  left outer join Gender g on o.PLacementGenderId = g.GenderId
	  left outer join LocalAuthority LA on o.PLacementLocalAuthorityId = LA.LocalAuthorityId
	  left outer join LeavingReason LR on o.PlacementLeavingReasonId = LR.LeavingReasonId
	  where o.PLacementLeaveDate is not null

END
