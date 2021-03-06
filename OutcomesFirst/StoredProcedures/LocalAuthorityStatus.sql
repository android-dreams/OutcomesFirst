USE [OutcomesFirst]
GO
/****** Object:  StoredProcedure [dbo].[LocalAuthorityStatus]    Script Date: 26/08/2019 19:07:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	This procedure provides the data for the Local Authority Status Report
-- =============================================
CREATE PROCEDURE [dbo].[LocalAuthorityStatus]
-- exec  [dbo].[LocalAuthorityStatus] 08
	-- Add the parameters for the stored procedure here
	@Month  int
--	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  -- current LAs 
SELECT la.LocalAuthorityId, la.LocalAuthorityName, la.LocalAuthorityRegionId ,'Current' as lastatus from LocalAuthority la 
	left outer join	Referral r on r.ReferralLocalAuthorityId = la.LocalAuthorityId 
		where Year(r.ReferralReceivedDate) = YEAR(GETDATE()) and MONTH(r.ReferralReceivedDate) = @Month
			and  EXISTS (select * from LocalAuthority la1 inner join Referral r1 on la1.LocalAuthorityId = r1.ReferralLocalAuthorityId
		where MONTH(r1.ReferralReceivedDate) = @Month -1)

--UNION

--Lapsed LAs
SELECT la.LocalAuthorityId, la.LocalAuthorityName, la.LocalAuthorityRegionId, 'Lapsed' as lastatus from LocalAuthority la 
	left outer join	Referral r on r.ReferralLocalAuthorityId = la.LocalAuthorityId 
	
		where (Year(r.ReferralReceivedDate) = YEAR(GETDATE()) and MONTH(r.ReferralReceivedDate) = @Month)
		and NOT EXISTS (select * from LocalAuthority la1 inner join Referral r1 on la1.LocalAuthorityId = r1.ReferralLocalAuthorityId
		where MONTH(r1.ReferralReceivedDate) = @Month)

--New Las

SELECT la.LocalAuthorityId, la.LocalAuthorityName, la.LocalAuthorityRegionId, 'New' as lastatus from LocalAuthority la 
	left outer join	Referral r on r.ReferralLocalAuthorityId = la.LocalAuthorityId 
	
		where (Year(r.ReferralReceivedDate) = YEAR(GETDATE()) and MONTH(r.ReferralReceivedDate) = @Month)
		and NOT EXISTS (select * from LocalAuthority la1 inner join Referral r1 on la1.LocalAuthorityId = r1.ReferralLocalAuthorityId
		where MONTH(r1.ReferralReceivedDate) = @Month -1)



	END
