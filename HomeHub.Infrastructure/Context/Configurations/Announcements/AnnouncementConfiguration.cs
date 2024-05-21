using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasKey(a => a.Id);
        builder.ToTable("Announcement");

        builder.Property(a => a.Area)
            .HasPrecision(18, 2);

        builder.Property(a => a.Title)
            .HasMaxLength(60);

        builder.HasOne<AdvertiserType>()
            .WithMany()
            .HasForeignKey(a => a.AdvertiserTypeId);

        builder.HasOne<AnnouncementType>()
            .WithMany()
            .HasForeignKey(a => a.TypeId);

        builder.HasOne<MarketType>()
            .WithMany()
            .HasForeignKey(a => a.MarketTypeId);

        builder.HasOne<SubjectType>()
            .WithMany()
            .HasForeignKey(a => a.SubjectTypeId);

        builder.HasOne<AnnouncementStatus>()
            .WithMany()
            .HasForeignKey(a => a.StatusId);

        builder.HasMany(a => a.Photos)
            .WithOne(p => p.Announcement)
            .HasForeignKey(p => p.AnnouncementId);

        builder.OwnsOne(a => a.Details, detail =>
        {
            detail.Property(d => d.Description)
                .HasColumnName("Description");

            detail.Property(d => d.BuildingFinishConditionId)
                .HasColumnName("BuildingFinishConditionId");

            detail.Property(d => d.BuildingMaterialId)
                .HasColumnName("BuildingMaterialId");

            detail.Property(d => d.DevelopmentTypeId)
                .HasColumnName("DevelopmentTypeId");

            detail.Property(d => d.FloorId)
                .HasColumnName("FloorId");

            detail.Property(d => d.HeatingTypeId)
                .HasColumnName("HeatingTypeId");

            detail.Property(d => d.OwnershipFormId)
                .HasColumnName("OwnershipFormId");

            detail.Property(d => d.WindowTypeId)
                .HasColumnName("WindowTypeId");

            detail.Property(d => d.AvailableFrom)
                .HasColumnName("AvailableFrom");

            detail.Property(d => d.BuildYear)
                .HasColumnName("BuildYear");

            detail.Property(d => d.NumberOfFloors)
                .HasColumnName("NumberOfFloors");

            detail.HasOne<BuildingFinishCondition>()
                .WithMany()
                .HasForeignKey(d => d.BuildingFinishConditionId);

            detail.HasOne<BuildingMaterial>()
                .WithMany()
                .HasForeignKey(d => d.BuildingMaterialId);

            detail.HasOne<DevelopmentType>()
                .WithMany()
                .HasForeignKey(d => d.DevelopmentTypeId);

            detail.HasOne<Floor>()
                .WithMany()
                .HasForeignKey(d => d.FloorId);

            detail.HasOne<HeatingType>()
                .WithMany()
                .HasForeignKey(d => d.HeatingTypeId);

            detail.HasOne<OwnershipForm>()
                .WithMany()
                .HasForeignKey(d => d.OwnershipFormId);

            detail.HasOne<WindowType>()
                .WithMany()
                .HasForeignKey(d => d.WindowTypeId);
        });

        builder.OwnsOne(a => a.Price, price =>
        {
            price.Property(p => p.Amount)
                .HasColumnName("PriceAmount")
                .HasPrecision(18, 2);

            price.Property(p => p.Currency)
                .HasColumnName("PriceCurrency")
                .HasConversion(new EnumToStringConverter<CurrencyEnum>());
        });

        builder.OwnsOne(a => a.ContactDetails, contactDetails =>
        {
            contactDetails.Property(c => c.AdvertiserName)
                .HasColumnName("AdvertiserName")
                .HasMaxLength(50)
                .IsRequired();

            contactDetails.Property(c => c.AdvertiserEmail)
                .HasColumnName("AdvertiserEmail")
                .HasMaxLength(50);

            contactDetails.Property(c => c.AdvertiserPhoneNumber)
                .HasColumnName("AdvertiserPhoneNumber")
                .HasMaxLength(15)
                .IsRequired();
        });

        builder.OwnsOne(a => a.Localization, localization =>
        {
            localization.Property(l => l.Address)
                .HasColumnName("Address")
                .HasMaxLength(255)
                .IsRequired();

            localization.Property(l => l.Latitude)
                .HasColumnName("Latitude")
                .HasPrecision(8, 6);

            localization.Property(l => l.Longitude)
                .HasColumnName("Longitude")
                .HasPrecision(9, 6);
        });

        builder.OwnsOne(a => a.Multimedia, multimedia =>
        {
            multimedia.Property(m => m.VideoUrl)
                .HasColumnName("VideoUrl");

            multimedia.Property(m => m.VirtualWalkUrl)
                .HasColumnName("VirtualWalkUrl");
        });
    }
}