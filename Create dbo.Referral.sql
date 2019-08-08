USE [OutcomesFirst]
GO

/****** Object: Table [dbo].[Referral] Script Date: 22/05/2019 13:13:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Referral] (
    [ReferralId]               INT            IDENTITY (1, 1) NOT NULL,
    [ReferralName]             NVARCHAR (MAX) NULL,
    [ReferralGenderId]         INT            NOT NULL,
    [ReferralLocalAuthorityId] INT            NOT NULL,
    [ReferralDOB]              DATETIME2 (7)  NOT NULL,
    [ReferralReceivedDate]     DATETIME2 (7)  NOT NULL,
    [ReferralAge]              INT            NOT NULL,
    [ReferralComments]         NVARCHAR (MAX) NULL,
    [ReferralStatusId]         INT            NOT NULL,
    [ReferralSuitable]         BIT            NULL,
    [ReferralArchiveReasonId]  INT            NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_Referral_ReferralArchiveReasonId]
    ON [dbo].[Referral]([ReferralArchiveReasonId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Referral_ReferralGenderId]
    ON [dbo].[Referral]([ReferralGenderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Referral_ReferralLocalAuthorityId]
    ON [dbo].[Referral]([ReferralLocalAuthorityId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Referral_ReferralStatusId]
    ON [dbo].[Referral]([ReferralStatusId] ASC);


GO
ALTER TABLE [dbo].[Referral]
    ADD CONSTRAINT [PK_Referral] PRIMARY KEY CLUSTERED ([ReferralId] ASC);


GO
ALTER TABLE [dbo].[Referral]
    ADD CONSTRAINT [FK_Referral_ArchiveReason_ReferralArchiveReasonId] FOREIGN KEY ([ReferralArchiveReasonId]) REFERENCES [dbo].[ArchiveReason] ([ArchiveReasonId]);


GO
ALTER TABLE [dbo].[Referral]
    ADD CONSTRAINT [FK_Referral_Gender_ReferralGenderId] FOREIGN KEY ([ReferralGenderId]) REFERENCES [dbo].[Gender] ([GenderId]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[Referral]
    ADD CONSTRAINT [FK_Referral_LocalAuthority_ReferralLocalAuthorityId] FOREIGN KEY ([ReferralLocalAuthorityId]) REFERENCES [dbo].[LocalAuthority] ([LocalAuthorityId]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[Referral]
    ADD CONSTRAINT [FK_Referral_ReferralStatus_ReferralStatusId] FOREIGN KEY ([ReferralStatusId]) REFERENCES [dbo].[ReferralStatus] ([ReferralStatusId]) ON DELETE CASCADE;


USE [OutcomesFirst]


SET IDENTITY_INSERT [dbo].[Referral] ON
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (11, N'Jan', 2, 1, N'1961-11-14 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 1, NULL, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (12, N'Dave', 1, 2, N'1961-08-07 00:00:00', N'2019-05-21 00:00:00', 0, NULL, 2, 1, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (13, N'Lucy', 2, 3, N'2000-01-12 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 3, 0, 1)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (14, N'Matt', 1, 4, N'2003-01-13 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 1, NULL, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (15, N'Diane', 2, 5, N'1961-11-14 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 2, 1, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (16, N'Gordon', 1, 1, N'1961-08-04 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 3, 0, 1)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (17, N'Tom', 1, 2, N'1994-10-04 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 1, NULL, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (18, N'Carolyn', 2, 3, N'1993-01-11 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 2, 1, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (19, N'Amy', 2, 4, N'1996-02-01 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 3, 0, 2)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (20, N'Bigg Matt', 1, 5, N'1992-11-13 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 1, NULL, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (21, N'Defne', 2, 1, N'2003-01-15 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 2, 1, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (22, N'Joe', 1, 2, N'1996-04-13 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 3, 0, 5)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (23, N'Mary', 2, 3, N'1962-04-24 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 4, NULL, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (24, N'Julian', 1, 4, N'1961-08-15 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 2, 1, NULL)
INSERT INTO [dbo].[Referral] ([ReferralId], [ReferralName], [ReferralGenderId], [ReferralLocalAuthorityId], [ReferralDOB], [ReferralReceivedDate], [ReferralAge], [ReferralComments], [ReferralStatusId], [ReferralSuitable], [ReferralArchiveReasonId]) VALUES (25, N'Heather', 2, 5, N'1996-08-11 00:00:00', N'2019-05-21 00:00:00', 10, NULL, 3, 0, 4)
SET IDENTITY_INSERT [dbo].[Referral] OFF
