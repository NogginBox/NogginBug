using Microsoft.EntityFrameworkCore;
using NogginBug.Data.Model;
using System.Threading;
using System.Threading.Tasks;

namespace NogginBug.Data
{
    public interface IDataContext
    {
        DbSet<Bug> Bugs { get; }

        DbSet<NogginBugUser> Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}