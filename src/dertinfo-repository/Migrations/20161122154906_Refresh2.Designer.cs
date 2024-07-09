﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DertInfo.Repository;

namespace DertInfo.Repository.Migrations
{
    [DbContext(typeof(DertInfoContext))]
    [Migration("20161122154906_Refresh2")]
    partial class Refresh2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DertInfo.Models.Database.AccessKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccessKeyRef")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("'00000000-0000-0000-0000-000000000000'");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("Id");

                    b.ToTable("AccessKeys");
                });

            modelBuilder.Entity("DertInfo.Models.Database.AccessKeyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessKeyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("DeletePermitted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<bool>("EditPermitted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Username");

                    b.Property<bool>("ViewPermitted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("AccessKeyId")
                        .HasName("IX_AccessKeyId");

                    b.ToTable("AccessKeyUsers");
                });

            modelBuilder.Entity("DertInfo.Models.Database.AttendanceClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("ClassificationName");

                    b.Property<decimal>("ClassificationPrice")
                        .HasColumnType("decimal");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.ToTable("AttendanceClassifications");
                });

            modelBuilder.Entity("DertInfo.Models.Database.BreadcrumbItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsTypeRoot")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("Label")
                        .HasColumnName("label");

                    b.Property<int>("LineageIndex")
                        .HasColumnName("lineageIndex");

                    b.Property<int>("ObjectId");

                    b.Property<string>("PageUri");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("BreadcrumbItems");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CompetitionDescription");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'2015-01-20T00:00:00.000'");

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'2015-01-20T00:00:00.000'");

                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("FlowState")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<int>("JudgeRequirementPerVenue")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<decimal>("TeamEntryFee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("DertInfo.Models.Database.CompetitionEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<int>("CompetitionId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'2015-02-18T00:00:00.000'");

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'2015-02-18T00:00:00.000'");

                    b.Property<int>("DertYear");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<bool>("IsDisabled");

                    b.Property<string>("ModifiedBy");

                    b.Property<int>("TeamAttendanceId");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId")
                        .HasName("IX_CompetitionId");

                    b.HasIndex("TeamAttendanceId")
                        .HasName("IX_TeamAttendanceId");

                    b.ToTable("CompetitionEntries");
                });

            modelBuilder.Entity("DertInfo.Models.Database.CompetitionEntryAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<int>("CompetitionAppliesToId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Tag");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionAppliesToId")
                        .HasName("IX_CompetitionAppliesToId");

                    b.ToTable("CompetitionEntryAttributes");
                });

            modelBuilder.Entity("DertInfo.Models.Database.CompetitionVenuesJoin", b =>
                {
                    b.Property<int>("CompetitionId")
                        .HasColumnName("Competition_Id");

                    b.Property<int>("VenueId")
                        .HasColumnName("Venue_Id");

                    b.HasKey("CompetitionId", "VenueId")
                        .HasName("PK_dbo.CompetitionVenuesJoin");

                    b.HasIndex("CompetitionId")
                        .HasName("IX_Competition_Id");

                    b.HasIndex("VenueId")
                        .HasName("IX_Venue_Id");

                    b.ToTable("CompetitionVenuesJoin");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Dance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<int>("CompetitionId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateScoresEntered")
                        .HasColumnType("datetime");

                    b.Property<int>("DertYear");

                    b.Property<bool>("HasScoresChecked");

                    b.Property<bool>("HasScoresEntered");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ScoresEnteredBy");

                    b.Property<int>("TeamAttendanceId");

                    b.Property<int>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId")
                        .HasName("IX_CompetitionId");

                    b.HasIndex("TeamAttendanceId")
                        .HasName("IX_TeamAttendanceId");

                    b.HasIndex("VenueId")
                        .HasName("IX_VenueId");

                    b.ToTable("Dances");
                });

            modelBuilder.Entity("DertInfo.Models.Database.DanceScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentGiven");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("DanceId");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("MarkGiven")
                        .HasColumnType("decimal");

                    b.Property<string>("ModifiedBy");

                    b.Property<int>("ScoreCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("DanceId")
                        .HasName("IX_DanceId");

                    b.HasIndex("ScoreCategoryId")
                        .HasName("IX_ScoreCategoryId");

                    b.ToTable("DanceScores");
                });

            modelBuilder.Entity("DertInfo.Models.Database.DertCompetitionEntryAttributeDertCompetitionEntry", b =>
                {
                    b.Property<int>("DertCompetitionEntryId")
                        .HasColumnName("DertCompetitionEntry_Id");

                    b.Property<int>("DertCompetitionEntryAttributeId")
                        .HasColumnName("DertCompetitionEntryAttribute_Id");

                    b.HasKey("DertCompetitionEntryId", "DertCompetitionEntryAttributeId")
                        .HasName("PK_dbo.DertCompetitionEntryAttributeDertCompetitionEntries");

                    b.HasIndex("DertCompetitionEntryAttributeId")
                        .HasName("IX_DertCompetitionEntryAttribute_Id");

                    b.HasIndex("DertCompetitionEntryId")
                        .HasName("IX_DertCompetitionEntry_Id");

                    b.ToTable("DertCompetitionEntryAttributeDertCompetitionEntries");
                });

            modelBuilder.Entity("DertInfo.Models.Database.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("Body");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Subject");

                    b.Property<string>("TemplateName");

                    b.Property<string>("TemplateRef");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.ToTable("EmailTemplates");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EventEndDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'2015-04-12T00:00:00.000'");

                    b.Property<DateTime>("EventStartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'2015-04-10T00:00:00.000'");

                    b.Property<string>("EventSynopsis");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<DateTime>("RegistrationCloseDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("RegistrationOpenDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DertInfo.Models.Database.EventImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<int>("ImageId");

                    b.Property<bool>("IsPrimary")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.HasIndex("ImageId")
                        .HasName("IX_ImageId");

                    b.ToTable("EventImages");
                });

            modelBuilder.Entity("DertInfo.Models.Database.EventJudge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("JudgeId");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.HasIndex("JudgeId")
                        .HasName("IX_JudgeId");

                    b.ToTable("EventJudges");
                });

            modelBuilder.Entity("DertInfo.Models.Database.EventSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Ref");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.ToTable("EventSettings");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("GroupBio");

                    b.Property<string>("GroupImageUrl");

                    b.Property<string>("GroupName");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("PrimaryContactEmail");

                    b.Property<string>("PrimaryContactName");

                    b.Property<string>("PrimaryContactNumber");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DertInfo.Models.Database.GroupImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<int>("ImageId");

                    b.Property<bool>("IsPrimary")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .HasName("IX_GroupId");

                    b.HasIndex("ImageId")
                        .HasName("IX_ImageId");

                    b.ToTable("GroupImages");
                });

            modelBuilder.Entity("DertInfo.Models.Database.GroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .HasName("IX_GroupId");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageAlt");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("HasPaid");

                    b.Property<string>("InvoiceCode");

                    b.Property<string>("InvoiceEntryNotes");

                    b.Property<string>("InvoiceLineItemNotes");

                    b.Property<string>("InvoiceToEmail");

                    b.Property<string>("InvoiceToName");

                    b.Property<string>("InvoiceToTeamName");

                    b.Property<decimal>("InvoiceTotal")
                        .HasColumnType("decimal");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<int>("RegistrationId");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId")
                        .HasName("IX_RegistrationId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Judge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Email");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("Judges");
                });

            modelBuilder.Entity("DertInfo.Models.Database.JudgeSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<int>("CompetitionId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("JudgeId");

                    b.Property<int>("MarkingSet");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int?>("ScoreSetId");

                    b.Property<int>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId")
                        .HasName("IX_CompetitionId");

                    b.HasIndex("JudgeId")
                        .HasName("IX_JudgeId");

                    b.HasIndex("ScoreSetId")
                        .HasName("IX_ScoreSetId");

                    b.HasIndex("VenueId")
                        .HasName("IX_VenueId");

                    b.ToTable("JudgeSlots");
                });

            modelBuilder.Entity("DertInfo.Models.Database.MarkingSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("DanceId");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("ScoreSheetImageUrl");

                    b.HasKey("Id");

                    b.HasIndex("DanceId")
                        .HasName("IX_DanceId");

                    b.ToTable("MarkingSheets");
                });

            modelBuilder.Entity("DertInfo.Models.Database.MarkingSheetImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("DanceId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                    b.Property<int>("ImageId");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("Id");

                    b.HasIndex("DanceId")
                        .HasName("IX_DanceId");

                    b.HasIndex("ImageId")
                        .HasName("IX_ImageId");

                    b.ToTable("MarkingSheetImages");
                });

            modelBuilder.Entity("DertInfo.Models.Database.MemberAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<int>("AttendanceClassificationId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("GroupMemberId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<int>("RegistrationId");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceClassificationId")
                        .HasName("IX_AttendanceClassificationId");

                    b.HasIndex("GroupMemberId")
                        .HasName("IX_GroupMemberId");

                    b.HasIndex("RegistrationId")
                        .HasName("IX_RegistrationId");

                    b.ToTable("MemberAttendances");
                });

            modelBuilder.Entity("DertInfo.Models.Database.NavigationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Link");

                    b.Property<string>("MinimumRequiredRole");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("NavigationItemSpecialRef");

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("NavigationItems");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Message");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Type");

                    b.Property<string>("UserAppliesTo");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DertYear");

                    b.Property<int>("EstimateAccomodation");

                    b.Property<int>("EstimateAttending");

                    b.Property<int>("EventId");

                    b.Property<int>("FlowState")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("SpecialRequirements");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.HasIndex("GroupId")
                        .HasName("IX_GroupId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("DertInfo.Models.Database.ScoreCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<int>("CompetitionAppliesToId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description");

                    b.Property<bool>("InScoreSet1");

                    b.Property<bool>("InScoreSet2");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MaxMarks");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("SortOrder");

                    b.Property<string>("Tag");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionAppliesToId")
                        .HasName("IX_CompetitionAppliesToId");

                    b.ToTable("ScoreCategories");
                });

            modelBuilder.Entity("DertInfo.Models.Database.ScoreSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<int>("CompetitionId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId")
                        .HasName("IX_CompetitionId");

                    b.ToTable("ScoreSets");
                });

            modelBuilder.Entity("DertInfo.Models.Database.ScoreSetScoreCategory", b =>
                {
                    b.Property<int>("ScoreSetId")
                        .HasColumnName("ScoreSet_Id");

                    b.Property<int>("ScoreCategoryId")
                        .HasColumnName("ScoreCategory_Id");

                    b.HasKey("ScoreSetId", "ScoreCategoryId")
                        .HasName("PK_dbo.ScoreSetScoreCategories");

                    b.HasIndex("ScoreCategoryId")
                        .HasName("IX_ScoreCategory_Id");

                    b.HasIndex("ScoreSetId")
                        .HasName("IX_ScoreSet_Id");

                    b.ToTable("ScoreSetScoreCategories");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Spectator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ContactNumber");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DertYear");

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<int>("NumberOfAdultConcessionTickets");

                    b.Property<int>("NumberOfAdultTickets");

                    b.Property<int>("NumberOfCampingTickets");

                    b.Property<int>("NumberOfJuniorTickets");

                    b.Property<int>("NumberOfYouthTickets");

                    b.HasKey("Id");

                    b.ToTable("Spectators");
                });

            modelBuilder.Entity("DertInfo.Models.Database.StaticResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId");

                    b.Property<string>("HtmlContent");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<int>("ResultType");

                    b.HasKey("Id");

                    b.ToTable("StaticResults");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Steward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactNumber");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DertYear");

                    b.Property<string>("EmailAddress");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.HasKey("Id");

                    b.ToTable("Stewards");
                });

            modelBuilder.Entity("DertInfo.Models.Database.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Ref");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("TeamBio");

                    b.Property<string>("TeamName");

                    b.HasKey("Id");

                    b.HasIndex("GroupId")
                        .HasName("IX_GroupId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DertInfo.Models.Database.TeamAggregateScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AggregateScore")
                        .HasColumnType("decimal");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DertTeamId");

                    b.Property<int>("DertYear");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<bool>("Organiser");

                    b.HasKey("Id");

                    b.HasIndex("DertTeamId")
                        .HasName("IX_DertTeamId");

                    b.ToTable("TeamAggregateScores");
                });

            modelBuilder.Entity("DertInfo.Models.Database.TeamAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<bool>("AttendanceConfirmed");

                    b.Property<string>("AttendanceNotes");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<int>("RegistrationId");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId")
                        .HasName("IX_RegistrationId");

                    b.HasIndex("TeamId")
                        .HasName("IX_TeamId");

                    b.ToTable("TeamAttendances");
                });

            modelBuilder.Entity("DertInfo.Models.Database.TeamImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ImageId");

                    b.Property<bool>("IsPrimary")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .HasName("IX_ImageId");

                    b.HasIndex("TeamId")
                        .HasName("IX_TeamId");

                    b.ToTable("TeamImages");
                });

            modelBuilder.Entity("DertInfo.Models.Database.UserProfile", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("'Should be your username.'");

                    b.Property<string>("YourName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("'Should be your name.'");

                    b.HasKey("UserId")
                        .HasName("PK_dbo.UserProfile");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("Auth0Username");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("JudgeMinderUsername");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .HasName("IX_EventId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("DertInfo.Models.Database.WebpagesMembership", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("ConfirmationToken")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("LastPasswordFailureDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime?>("PasswordChangedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PasswordFailuresSinceLastSuccess")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("PasswordVerificationToken")
                        .HasMaxLength(128);

                    b.Property<DateTime?>("PasswordVerificationTokenExpirationDate")
                        .HasColumnType("datetime");

                    b.HasKey("UserId")
                        .HasName("PK__webpages__1788CC4CE7FC2C39");

                    b.ToTable("webpages_Membership");
                });

            modelBuilder.Entity("DertInfo.Models.Database.WebpagesOauthMembership", b =>
                {
                    b.Property<string>("Provider")
                        .HasMaxLength(30);

                    b.Property<string>("ProviderUserId")
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Provider", "ProviderUserId")
                        .HasName("PK__webpages__F53FC0ED8537BC39");

                    b.ToTable("webpages_OAuthMembership");
                });

            modelBuilder.Entity("DertInfo.Models.Database.WebpagesRoles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("RoleId")
                        .HasName("PK__webpages__8AFACE1A5DFE3B86");

                    b.HasIndex("RoleName")
                        .IsUnique()
                        .HasName("UQ__webpages__8A2B6160B736E32A");

                    b.ToTable("webpages_Roles");
                });

            modelBuilder.Entity("DertInfo.Models.Database.WebpagesUsersInRoles", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK__webpages__AF2760ADE5219DA6");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("webpages_UsersInRoles");
                });

            modelBuilder.Entity("DertInfo.Models.Database.AccessKeyUser", b =>
                {
                    b.HasOne("DertInfo.Models.Database.AccessKey", "AccessKey")
                        .WithMany("AccessKeyUsers")
                        .HasForeignKey("AccessKeyId")
                        .HasConstraintName("FK_dbo.AccessKeyUsers_dbo.AccessKeys_AccessKeyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.AttendanceClassification", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("AttendanceClassifications")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.AttendanceClassifications_dbo.Events_EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.Competition", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("Competitions")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.Competitions_dbo.Events_EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.CompetitionEntry", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Competition", "Competition")
                        .WithMany("CompetitionEntries")
                        .HasForeignKey("CompetitionId")
                        .HasConstraintName("FK_dbo.CompetitionEntries_dbo.Competitions_CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.TeamAttendance", "TeamAttendance")
                        .WithMany("CompetitionEntries")
                        .HasForeignKey("TeamAttendanceId")
                        .HasConstraintName("FK_dbo.CompetitionEntries_dbo.TeamAttendances_TeamAttendanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.CompetitionEntryAttribute", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Competition", "CompetitionAppliesTo")
                        .WithMany("CompetitionEntryAttributes")
                        .HasForeignKey("CompetitionAppliesToId")
                        .HasConstraintName("FK_dbo.CompetitionEntryAttributes_dbo.Competitions_CompetitionAppliesToId");
                });

            modelBuilder.Entity("DertInfo.Models.Database.CompetitionVenuesJoin", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Competition", "Competition")
                        .WithMany("CompetitionVenuesJoin")
                        .HasForeignKey("CompetitionId")
                        .HasConstraintName("FK_dbo.CompetitionVenuesJoin_dbo.Competitions_Competition_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Venue", "Venue")
                        .WithMany("CompetitionVenuesJoin")
                        .HasForeignKey("VenueId")
                        .HasConstraintName("FK_dbo.CompetitionVenuesJoin_dbo.Venues_Venue_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.Dance", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Competition", "Competition")
                        .WithMany("Dances")
                        .HasForeignKey("CompetitionId")
                        .HasConstraintName("FK_dbo.Dances_dbo.Competitions_CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.TeamAttendance", "TeamAttendance")
                        .WithMany("Dances")
                        .HasForeignKey("TeamAttendanceId")
                        .HasConstraintName("FK_dbo.Dances_dbo.TeamAttendances_TeamAttendanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Venue", "Venue")
                        .WithMany("Dances")
                        .HasForeignKey("VenueId")
                        .HasConstraintName("FK_dbo.Dances_dbo.Venues_VenueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.DanceScore", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Dance", "Dance")
                        .WithMany("DanceScores")
                        .HasForeignKey("DanceId")
                        .HasConstraintName("FK_dbo.DanceScores_dbo.Dances_DanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.ScoreCategory", "ScoreCategory")
                        .WithMany("DanceScores")
                        .HasForeignKey("ScoreCategoryId")
                        .HasConstraintName("FK_dbo.DanceScores_dbo.ScoreCategories_ScoreCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.DertCompetitionEntryAttributeDertCompetitionEntry", b =>
                {
                    b.HasOne("DertInfo.Models.Database.CompetitionEntryAttribute", "DertCompetitionEntryAttribute")
                        .WithMany("DertCompetitionEntryAttributeDertCompetitionEntries")
                        .HasForeignKey("DertCompetitionEntryAttributeId")
                        .HasConstraintName("FK_dbo.DertCompetitionEntryAttributeDertCompetitionEntries_dbo.CompetitionEntryAttributes_DertCompetitionEntryAttribute_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.CompetitionEntry", "DertCompetitionEntry")
                        .WithMany("DertCompetitionEntryAttributeDertCompetitionEntries")
                        .HasForeignKey("DertCompetitionEntryId")
                        .HasConstraintName("FK_dbo.DertCompetitionEntryAttributeDertCompetitionEntries_dbo.CompetitionEntries_DertCompetitionEntry_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.EmailTemplate", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("EmailTemplates")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.EmailTemplates_dbo.Events_EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.EventImage", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("EventImages")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.EventImages_dbo.Events_EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Image", "Image")
                        .WithMany("EventImages")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_dbo.EventImages_dbo.Images_ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.EventJudge", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("EventJudges")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.EventJudges_dbo.Events_EventId");

                    b.HasOne("DertInfo.Models.Database.Judge", "Judge")
                        .WithMany("EventJudges")
                        .HasForeignKey("JudgeId")
                        .HasConstraintName("FK_dbo.EventJudges_dbo.Judges_JudgeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.EventSetting", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("EventSettings")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.EventSettings_dbo.Events_EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.GroupImage", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Group", "Group")
                        .WithMany("GroupImages")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_dbo.GroupImages_dbo.Groups_GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Image", "Image")
                        .WithMany("GroupImages")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_dbo.GroupImages_dbo.Images_ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.GroupMember", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_dbo.GroupMembers_dbo.Groups_GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.Invoice", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Registration", "Registration")
                        .WithMany("Invoices")
                        .HasForeignKey("RegistrationId")
                        .HasConstraintName("FK_dbo.Invoices_dbo.Registrations_GroupRegistrationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.JudgeSlot", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Competition", "Competition")
                        .WithMany("JudgeSlots")
                        .HasForeignKey("CompetitionId")
                        .HasConstraintName("FK_dbo.Judges_dbo.Competitions_CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Judge", "Judge")
                        .WithMany("JudgeSlots")
                        .HasForeignKey("JudgeId")
                        .HasConstraintName("FK_dbo.JudgeSlots_dbo.Judges_JudgeId");

                    b.HasOne("DertInfo.Models.Database.ScoreSet", "ScoreSet")
                        .WithMany("JudgeSlots")
                        .HasForeignKey("ScoreSetId")
                        .HasConstraintName("FK_dbo.JudgeSlots_dbo.ScoreSets_ScoreSetId");

                    b.HasOne("DertInfo.Models.Database.Venue", "Venue")
                        .WithMany("JudgeSlots")
                        .HasForeignKey("VenueId")
                        .HasConstraintName("FK_dbo.Judges_dbo.Venues_VenueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.MarkingSheet", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Dance", "Dance")
                        .WithMany("MarkingSheets")
                        .HasForeignKey("DanceId")
                        .HasConstraintName("FK_dbo.MarkingSheets_dbo.Dances_DanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.MarkingSheetImage", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Dance", "Dance")
                        .WithMany("MarkingSheetImages")
                        .HasForeignKey("DanceId")
                        .HasConstraintName("FK_dbo.MarkingSheetImages_dbo.Dances_DanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Image", "Image")
                        .WithMany("MarkingSheetImages")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_dbo.MarkingSheetImages_dbo.Images_ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.MemberAttendance", b =>
                {
                    b.HasOne("DertInfo.Models.Database.AttendanceClassification", "AttendanceClassification")
                        .WithMany("MemberAttendances")
                        .HasForeignKey("AttendanceClassificationId")
                        .HasConstraintName("FK_dbo.MemberAttendances_dbo.AttendanceClassifications_AttendanceClassificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.GroupMember", "GroupMember")
                        .WithMany("MemberAttendances")
                        .HasForeignKey("GroupMemberId")
                        .HasConstraintName("FK_dbo.MemberAttendances_dbo.GroupMembers_GroupMemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Registration", "Registration")
                        .WithMany("MemberAttendances")
                        .HasForeignKey("RegistrationId")
                        .HasConstraintName("FK_dbo.MemberAttendances_dbo.Registrations_RegistrationId");
                });

            modelBuilder.Entity("DertInfo.Models.Database.Registration", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("Registrations")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.Registrations_dbo.Events_EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Group", "Group")
                        .WithMany("Registrations")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_dbo.Registrations_dbo.Groups_GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.ScoreCategory", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Competition", "CompetitionAppliesTo")
                        .WithMany("ScoreCategories")
                        .HasForeignKey("CompetitionAppliesToId")
                        .HasConstraintName("FK_dbo.ScoreCategories_dbo.Competitions_CompetitionAppliesToId");
                });

            modelBuilder.Entity("DertInfo.Models.Database.ScoreSet", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Competition", "Competition")
                        .WithMany("ScoreSets")
                        .HasForeignKey("CompetitionId")
                        .HasConstraintName("FK_dbo.ScoreSets_dbo.Competitions_CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.ScoreSetScoreCategory", b =>
                {
                    b.HasOne("DertInfo.Models.Database.ScoreCategory", "ScoreCategory")
                        .WithMany("ScoreSetScoreCategories")
                        .HasForeignKey("ScoreCategoryId")
                        .HasConstraintName("FK_dbo.ScoreSetScoreCategories_dbo.ScoreCategories_ScoreCategory_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.ScoreSet", "ScoreSet")
                        .WithMany("ScoreSetScoreCategories")
                        .HasForeignKey("ScoreSetId")
                        .HasConstraintName("FK_dbo.ScoreSetScoreCategories_dbo.ScoreSets_ScoreSet_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.Team", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Group", "Group")
                        .WithMany("Teams")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_dbo.Teams_dbo.Groups_GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.TeamAggregateScore", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Team", "DertTeam")
                        .WithMany("TeamAggregateScores")
                        .HasForeignKey("DertTeamId")
                        .HasConstraintName("FK_dbo.TeamAggregateScores_dbo.Teams_DertTeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.TeamAttendance", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Registration", "Registration")
                        .WithMany("TeamAttendances")
                        .HasForeignKey("RegistrationId")
                        .HasConstraintName("FK_dbo.TeamAttendances_dbo.Registrations_RegistrationId");

                    b.HasOne("DertInfo.Models.Database.Team", "Team")
                        .WithMany("TeamAttendances")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK_dbo.TeamAttendances_dbo.Teams_TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.TeamImage", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Image", "Image")
                        .WithMany("TeamImages")
                        .HasForeignKey("ImageId")
                        .HasConstraintName("FK_dbo.TeamImages_dbo.Images_ImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DertInfo.Models.Database.Team", "Team")
                        .WithMany("TeamImages")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK_dbo.TeamImages_dbo.Teams_TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DertInfo.Models.Database.Venue", b =>
                {
                    b.HasOne("DertInfo.Models.Database.Event", "Event")
                        .WithMany("Venues")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_dbo.Venues_dbo.Events_EventId");
                });

            modelBuilder.Entity("DertInfo.Models.Database.WebpagesUsersInRoles", b =>
                {
                    b.HasOne("DertInfo.Models.Database.WebpagesRoles", "Role")
                        .WithMany("WebpagesUsersInRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_RoleId");

                    b.HasOne("DertInfo.Models.Database.UserProfile", "User")
                        .WithMany("WebpagesUsersInRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_UserId");
                });
        }
    }
}
