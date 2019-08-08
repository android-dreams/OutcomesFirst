SET IDENTITY_INSERT [dbo].[ArchiveReferral] OFF
INSERT INTO [dbo].[ArchiveReferral]
 ( [ArchiveReferralName], [ArchiveReferralGenderId],
  [ArchiveReferralLocalAuthorityId],  [ArchiveReferralReceivedDate],
   [ArchiveReferralAge], [ArchiveReferralComments], 
   [ArchiveReferralStatusId],  [ArchiveReferralSuitable],
    [ArchiveReferralArchiveReasonId], [ArchiveReferralType])
   VALUES (N'Tyler', 2,
    2,    N'1961-11-14 00:00:00',
	 10,'System Generated Comments',
	 8,0,
	 1, 2)

INSERT INTO [dbo].[ArchiveReferral]
 ( [ArchiveReferralName],  [ArchiveReferralGenderId], 
 [ArchiveReferralLocalAuthorityId],  [ArchiveReferralReceivedDate], 
 [ArchiveReferralAge],   [ArchiveReferralComments], 
    [ArchiveReferralStatusId],    [ArchiveReferralSuitable], 
	   [ArchiveReferralArchiveReasonId], [ArchiveReferralType])
 VALUES ( N'Liv',  2,
  2,   N'1961-11-14 00:00:00',
    4,'System Generated Comments',
     8,0
	 ,2,1)
INSERT INTO [dbo].[ArchiveReferral] 
([ArchiveReferralName], [ArchiveReferralGenderId],
 [ArchiveReferralLocalAuthorityId], [ArchiveReferralReceivedDate],
  [ArchiveReferralAge], [ArchiveReferralComments], 
  [ArchiveReferralStatusId], [ArchiveReferralSuitable], 
  [ArchiveReferralArchiveReasonId], [ArchiveReferralType])
 VALUES ( N'Paul',  1,
  3,   N'1961-11-14 00:00:00',
    6, 'System Generated Comments'
    	, 8,0,
		3,2)

INSERT INTO [dbo].[ArchiveReferral]
 ([ArchiveReferralName], [ArchiveReferralGenderId], 
 [ArchiveReferralLocalAuthorityId], [ArchiveReferralReceivedDate],
  [ArchiveReferralAge], [ArchiveReferralComments],
   [ArchiveReferralStatusId], [ArchiveReferralSuitable],
    [ArchiveReferralArchiveReasonId], [ArchiveReferralType])
 VALUES ( N'Tierey',  2,
  2,   N'1961-11-14 00:00:00',
    13, 'System Generated Comments',
	 8, 0,
	 4,3)

GO
