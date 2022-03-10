namespace Infrastructure.Persistence
{
	using Domain.Models;
	using Microsoft.EntityFrameworkCore;

    internal interface IContactsManagerDbContext : IDbContext
    {
        DbSet<Contact> Contacts { get; }
    }
}
