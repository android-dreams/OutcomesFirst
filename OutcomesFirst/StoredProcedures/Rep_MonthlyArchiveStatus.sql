USE [OutcomesFirst]
GO
/****** Object:  StoredProcedure [dbo].[Rep_MonthlyArchiveStatus]    Script Date: 22/10/2019 16:12:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jan
-- Create date: 27/07/2019
-- Description: Stored procedure to provide dataset for Monthly Referral Status Report
-- =============================================
ALTER PROCEDURE [dbo].[Rep_MonthlyArchiveStatus]
-- exec [dbo].[Rep_MonthlyArchiveStatus]
AS 

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	with services_cte AS
	(
	Select ServiceId, ServiceName from Service
	),

	reasons_cte AS
	(
	select ArchiveReasonId as ID ,ArchiveReasonName as reasonName from ArchiveReason
	)

 
	Select cte.ServiceId,cte.ServiceName, ar.ArchiveReasonName, COUNT(sub.SubmissionId) as count from services_cte cte
	
	
	left outer join Submission sub on cte.ServiceId = sub.SubmissionServiceId
	--left outer join Referral ref on ref.ReferralId =  sub.SubmissionReferralId
	left outer join ArchiveReason ar on ar.ArchiveReasonId = sub.SubmissionStatusId  
	group by cte.ServiceId,cte.ServiceName, ar.ArchiveReasonName
	

	END
