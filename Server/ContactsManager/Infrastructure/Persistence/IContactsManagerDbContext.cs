namespace Infrastructure.Persistence
{
	using Microsoft.EntityFrameworkCore;

    internal interface IContactsManagerDbContext : IDbContext
    {
        //DbSet<Question> Questions { get; }
    }
}
