USE [OutcomesFirst]
GO
/****** Object:  StoredProcedure [dbo].[New_LapsedCustomers]    Script Date: 27/07/2019 19:29:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[New_LapsedCustomers]
--exec dbo.New_LapsedCustomers '08'
	-- Add the parameters for the stored procedure here
	@Month as int
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT LA.LocalAuthorityName, month(Ref.ReferralReceivedDate)
	--, reg.RegionName 
	 from LocalAuthority LA 
	LEFT OUTER JOIN Referral Ref on LA.LocalAuthorityId = ref.ReferralLocalAuthorityId
--/inner join Region reg on reg.RegionId = LA.LocalAuthorityRegionId
	where month(Ref.ReferralReceivedDate) = @Month
END
