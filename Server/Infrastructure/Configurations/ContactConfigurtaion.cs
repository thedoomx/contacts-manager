namespace Infrastructure.Configurations
{
	using Domain.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	using static Domain.Models.ModelConstants.Contact;

	internal class ContactConfigurtaion : IEntityTypeConfiguration<Contact>
	{
		public void Configure(EntityTypeBuilder<Contact> builder)
		{
			builder
				.HasKey(c => c.Id);

			builder
				.Property(o => o.Id)
				.IsRequired();

			builder
				.Property(c => c.FirstName)
				.HasMaxLength(MaxFirstNameLength);

			builder
			   .Property(c => c.SurName)
			   .HasMaxLength(MaxSurNameLength)
			   .IsRequired();

			builder
			   .Property(c => c.Address)
			   .HasMaxLength(MaxAddressNameLength)
			   .IsRequired();

			builder
			   .Property(c => c.PhoneNumber)
			   .HasMaxLength(MaxPhoneNumberLength)
			   .IsRequired();

			builder
			   .Property(c => c.IBAN)
			   .IsRequired();

			builder
			   .Property(c => c.DateOfBirth)
			   .IsRequired();
		}
	}
}
