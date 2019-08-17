using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutcomesFirst.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveReason",
                columns: table => new
                {
                    ArchiveReasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchiveReasonName = table.Column<string>(nullable: true),
                    ArchiveDecisionBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveReason", x => x.ArchiveReasonId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "LeavingReason",
                columns: table => new
                {
                    LeavingReasonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeavingReasonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavingReason", x => x.LeavingReasonId);
                });

            migrationBuilder.CreateTable(
                name: "RegionalManager",
                columns: table => new
                {
                    RegionalManagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionalManagerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalManager", x => x.RegionalManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(nullable: true),
                    StatusPriority = table.Column<int>(nullable: false),
                    StatusOffersActivityReportOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionName = table.Column<string>(nullable: true),
                    RegionRegionalManagerId = table.Column<int>(nullable: false),
                    RegionalManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_Region_RegionalManager_RegionalManagerId",
                        column: x => x.RegionalManagerId,
                        principalTable: "RegionalManager",
                        principalColumn: "RegionalManagerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalAuthority",
                columns: table => new
                {
                    LocalAuthorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocalAuthorityName = table.Column<string>(nullable: true),
                    LocalAuthorityRegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalAuthority", x => x.LocalAuthorityId);
                    table.ForeignKey(
                        name: "FK_LocalAuthority_Region_LocalAuthorityRegionId",
                        column: x => x.LocalAuthorityRegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceName = table.Column<string>(nullable: true),
                    ServiceAddress1 = table.Column<string>(nullable: true),
                    ServiceAddress2 = table.Column<string>(nullable: true),
                    ServiceAddress3 = table.Column<string>(nullable: true),
                    ServiceAddress4 = table.Column<string>(nullable: true),
                    ServicePostcode = table.Column<string>(nullable: true),
                    ServiceRegionId = table.Column<int>(nullable: true),
                    ServiceContact = table.Column<string>(nullable: true),
                    ServiceContactNumber = table.Column<string>(nullable: true),
                    ServicePlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_Region_ServiceRegionId",
                        column: x => x.ServiceRegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveReferral",
                columns: table => new
                {
                    ArchiveReferralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchiveReferralName = table.Column<string>(nullable: true),
                    ArchiveReferralGenderId = table.Column<int>(nullable: false),
                    ArchiveReferralType = table.Column<int>(nullable: false),
                    ArchiveReferralLocalAuthorityId = table.Column<int>(nullable: true),
                    ArchiveReferralReceivedDate = table.Column<DateTime>(nullable: false),
                    ArchiveReferralAge = table.Column<int>(nullable: false),
                    ArchiveReferralComments = table.Column<string>(nullable: true),
                    ArchiveReferralStatusId = table.Column<int>(nullable: false),
                    ArchiveReferralSuitableColor = table.Column<string>(nullable: true),
                    ArchiveReferralSuitable = table.Column<bool>(nullable: true),
                    ArchiveReferralArchiveReasonId = table.Column<int>(nullable: true),
                    ArchiveReferralSuitableComments = table.Column<string>(nullable: true),
                    ArchiveReferralNotSuitableComments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveReferral", x => x.ArchiveReferralId);
                    table.ForeignKey(
                        name: "FK_ArchiveReferral_ArchiveReason_ArchiveReferralArchiveReasonId",
                        column: x => x.ArchiveReferralArchiveReasonId,
                        principalTable: "ArchiveReason",
                        principalColumn: "ArchiveReasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveReferral_Gender_ArchiveReferralGenderId",
                        column: x => x.ArchiveReferralGenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchiveReferral_LocalAuthority_ArchiveReferralLocalAuthorityId",
                        column: x => x.ArchiveReferralLocalAuthorityId,
                        principalTable: "LocalAuthority",
                        principalColumn: "LocalAuthorityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchiveReferral_Status_ArchiveReferralStatusId",
                        column: x => x.ArchiveReferralStatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    ReferralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferralName = table.Column<string>(nullable: false),
                    ReferralGenderId = table.Column<int>(nullable: false),
                    ReferralLocalAuthorityId = table.Column<int>(nullable: false),
                    ReferralDOB = table.Column<DateTime>(nullable: false),
                    ReferralReceivedDate = table.Column<DateTime>(nullable: false),
                    ReferralAge = table.Column<int>(nullable: false),
                    ReferralComments = table.Column<string>(nullable: true),
                    ReferralStatusId = table.Column<int>(nullable: false),
                    ReferralPlacementStartDate = table.Column<DateTime>(nullable: true),
                    ReferralSuitableColor = table.Column<string>(nullable: true),
                    ReferralSuitable = table.Column<bool>(nullable: true),
                    ReferralArchiveReasonId = table.Column<int>(nullable: true),
                    ReferralSuitableComments = table.Column<string>(nullable: true),
                    ReferralNotSuitableComments = table.Column<string>(nullable: true),
                    ReferralType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.ReferralId);
                    table.ForeignKey(
                        name: "FK_Referral_ArchiveReason_ReferralArchiveReasonId",
                        column: x => x.ReferralArchiveReasonId,
                        principalTable: "ArchiveReason",
                        principalColumn: "ArchiveReasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Referral_Gender_ReferralGenderId",
                        column: x => x.ReferralGenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referral_LocalAuthority_ReferralLocalAuthorityId",
                        column: x => x.ReferralLocalAuthorityId,
                        principalTable: "LocalAuthority",
                        principalColumn: "LocalAuthorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referral_Status_ReferralStatusId",
                        column: x => x.ReferralStatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupancy",
                columns: table => new
                {
                    OccupancyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OccupancyRefId = table.Column<string>(nullable: true),
                    OccupancyFirstName = table.Column<string>(nullable: true),
                    OccupancyLastName = table.Column<string>(nullable: true),
                    OccupancyGenderId = table.Column<int>(nullable: false),
                    OccupancyType = table.Column<string>(nullable: false),
                    OccupancyServiceTransition = table.Column<bool>(nullable: true),
                    OccupancyServiceId = table.Column<int>(nullable: false),
                    OccupancyDateStartedWithGroup = table.Column<DateTime>(nullable: false),
                    OccupancyPlacementStartDate = table.Column<DateTime>(nullable: true),
                    OccupancyDOB = table.Column<DateTime>(nullable: false),
                    OccupancyAgeAtLeaving = table.Column<int>(nullable: true),
                    OccupancyLocalAuthorityId = table.Column<int>(nullable: false),
                    OccupancyFramework = table.Column<string>(nullable: true),
                    OccupancyWeeklyFee = table.Column<int>(nullable: true),
                    OccupancyLengthOfStayWithGroup = table.Column<int>(nullable: true),
                    OccupancyLengthOfStayWithPlacement = table.Column<int>(nullable: true),
                    OccupancyNotes = table.Column<string>(nullable: true),
                    OccupancyLeaveDate = table.Column<DateTime>(nullable: true),
                    OccupancyLeaverType = table.Column<string>(nullable: true),
                    OccupancyReasonForLeavingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupancy", x => x.OccupancyId);
                    table.ForeignKey(
                        name: "FK_Occupancy_Gender_OccupancyGenderId",
                        column: x => x.OccupancyGenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occupancy_LocalAuthority_OccupancyLocalAuthorityId",
                        column: x => x.OccupancyLocalAuthorityId,
                        principalTable: "LocalAuthority",
                        principalColumn: "LocalAuthorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occupancy_Service_OccupancyServiceId",
                        column: x => x.OccupancyServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placement",
                columns: table => new
                {
                    PlacementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlacementRefId = table.Column<string>(nullable: true),
                    PlacementFirstName = table.Column<string>(nullable: true),
                    PlacementLastName = table.Column<string>(nullable: true),
                    PlacementGenderId = table.Column<int>(nullable: false),
                    PlacementType = table.Column<string>(nullable: false),
                    PlacementServiceTransition = table.Column<bool>(nullable: true),
                    PlacementServiceId = table.Column<int>(nullable: false),
                    PlacementDateStartedWithGroup = table.Column<DateTime>(nullable: false),
                    PlacementPlacementStartDate = table.Column<DateTime>(nullable: true),
                    PlacementDOB = table.Column<DateTime>(nullable: false),
                    PlacementAgeAtLeaving = table.Column<int>(nullable: true),
                    PlacementLocalAuthorityId = table.Column<int>(nullable: false),
                    PlacementFramework = table.Column<string>(nullable: true),
                    PlacementWeeklyFee = table.Column<int>(nullable: true),
                    PlacementLengthOfStayWithGroup = table.Column<int>(nullable: true),
                    PlacementLengthOfStayWithPlacement = table.Column<int>(nullable: true),
                    PlacementNotes = table.Column<string>(nullable: true),
                    PlacementLeaveDate = table.Column<DateTime>(nullable: true),
                    PlacementLeaverType = table.Column<string>(nullable: true),
                    PlacementLeavingReasonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placement", x => x.PlacementId);
                    table.ForeignKey(
                        name: "FK_Placement_Gender_PlacementGenderId",
                        column: x => x.PlacementGenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placement_LeavingReason_PlacementLeavingReasonId",
                        column: x => x.PlacementLeavingReasonId,
                        principalTable: "LeavingReason",
                        principalColumn: "LeavingReasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Placement_LocalAuthority_PlacementLocalAuthorityId",
                        column: x => x.PlacementLocalAuthorityId,
                        principalTable: "LocalAuthority",
                        principalColumn: "LocalAuthorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placement_Service_PlacementServiceId",
                        column: x => x.PlacementServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    SubmissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubmissionReferralId = table.Column<int>(nullable: false),
                    SubmissionServiceId = table.Column<int>(nullable: false),
                    SubmissionStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.SubmissionId);
                    table.ForeignKey(
                        name: "FK_Submission_Referral_SubmissionReferralId",
                        column: x => x.SubmissionReferralId,
                        principalTable: "Referral",
                        principalColumn: "ReferralId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submission_Service_SubmissionServiceId",
                        column: x => x.SubmissionServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submission_Status_SubmissionStatusId",
                        column: x => x.SubmissionStatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveReferral_ArchiveReferralArchiveReasonId",
                table: "ArchiveReferral",
                column: "ArchiveReferralArchiveReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveReferral_ArchiveReferralGenderId",
                table: "ArchiveReferral",
                column: "ArchiveReferralGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveReferral_ArchiveReferralLocalAuthorityId",
                table: "ArchiveReferral",
                column: "ArchiveReferralLocalAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveReferral_ArchiveReferralStatusId",
                table: "ArchiveReferral",
                column: "ArchiveReferralStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LocalAuthority_LocalAuthorityRegionId",
                table: "LocalAuthority",
                column: "LocalAuthorityRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancy_OccupancyGenderId",
                table: "Occupancy",
                column: "OccupancyGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancy_OccupancyLocalAuthorityId",
                table: "Occupancy",
                column: "OccupancyLocalAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupancy_OccupancyServiceId",
                table: "Occupancy",
                column: "OccupancyServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_PlacementGenderId",
                table: "Placement",
                column: "PlacementGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_PlacementLeavingReasonId",
                table: "Placement",
                column: "PlacementLeavingReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_PlacementLocalAuthorityId",
                table: "Placement",
                column: "PlacementLocalAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Placement_PlacementServiceId",
                table: "Placement",
                column: "PlacementServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_ReferralArchiveReasonId",
                table: "Referral",
                column: "ReferralArchiveReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_ReferralGenderId",
                table: "Referral",
                column: "ReferralGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_ReferralLocalAuthorityId",
                table: "Referral",
                column: "ReferralLocalAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_ReferralStatusId",
                table: "Referral",
                column: "ReferralStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_RegionalManagerId",
                table: "Region",
                column: "RegionalManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceRegionId",
                table: "Service",
                column: "ServiceRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_SubmissionReferralId",
                table: "Submission",
                column: "SubmissionReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_SubmissionServiceId",
                table: "Submission",
                column: "SubmissionServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_SubmissionStatusId",
                table: "Submission",
                column: "SubmissionStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveReferral");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Occupancy");

            migrationBuilder.DropTable(
                name: "Placement");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LeavingReason");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ArchiveReason");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "LocalAuthority");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "RegionalManager");
        }
    }
}
