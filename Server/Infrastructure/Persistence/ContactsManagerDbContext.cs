namespace Infrastructure.Persistence
{
	using System.Collections.Generic;
	using System.Reflection;
	using Microsoft.EntityFrameworkCore;
	using Domain.Models;

	internal class ContactsManagerDbContext : DbContext,
		IContactsManagerDbContext
	{
		private readonly Stack<object> savesChangesTracker;

		public ContactsManagerDbContext(
			DbContextOptions<ContactsManagerDbContext> options)
			: base(options)
		{
			this.savesChangesTracker = new Stack<object>();
		}

		public DbSet<Contact> Contacts { get; set; } = default!;

		protected Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);
		}
	}
}
