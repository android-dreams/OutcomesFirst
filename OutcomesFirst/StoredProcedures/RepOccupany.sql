-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


ALTER PROCEDURE Rep_Occupancy
--exec Rep_Occupancy 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT o.PlacementFirstName,
	o.PlacementLastName,
	o.PlacementGenderId,
	o.PlacementType,
	o.PlacementDateStartedWithGroup,
	o.PlacementPlacementStartDate,
	o.PlacementDOB,
	o.PlacementLocalAuthorityId,
	o.PlacementFramework,
	o.PlacementLengthOfStayWithPlacement,
	o.PlacementNotes
	PlacementLengthOfStayWithGroup,
	serv.ServiceName,
	serv.ServicePlaces
	 from Placement o
	  inner join Service serv on o.PlacementServiceId = serv.ServiceId
	  inner join Gender g on o.PlacementGenderId = g.GenderId
	  inner join LocalAuthority LA on o.PlacementLocalAuthorityId = LA.LocalAuthorityId
	  left outer join LeavingReason LR on o.PlacementLeavingReasonId = LR.LeavingReasonId
	  where o.PlacementLeaveDate is null

END
GO
