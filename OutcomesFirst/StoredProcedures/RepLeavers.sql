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
CREATE PROCEDURE Rep_OccupancyLeavers 
--exec Rep_OccupancyLeavers 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT o.OccupancyFirstName,
	o.OccupancyLastName,
	o.OccupancyGenderId,
	o.OccupancyType,
	o.OccupancyDateStartedWithGroup,
	o.OccupancyPlacementStartDate,
	o.OccupancyDOB,
	o.OccupancyLocalAuthorityId,
	o.OccupancyFramework,
	o.OccupancyLengthOfStayWithPlacement,
	o.OccupancyNotes
	OccupancyLengthOfStayWithGroup,
	serv.ServiceName,
	serv.ServicePlaces
	 from Occupancy o
	  inner join Service serv on o.OccupancyServiceId = serv.ServiceId
	  inner join Gender g on o.OccupancyGenderId = g.GenderId
	  inner join LocalAuthority LA on o.OccupancyLocalAuthorityId = LA.LocalAuthorityId
	  inner join LeavingReason LR on o.OccupancyReasonForLeavingID = LR.LeavingReasonId
	  where o.OccupancyLeaveDate != null

END
GO
