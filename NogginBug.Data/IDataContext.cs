using Microsoft.EntityFrameworkCore;
using NogginBug.Data.Model;
using System.Threading;
using System.Threading.Tasks;

namespace NogginBug.Data
{
    public interface IDataContext
    {
        DbSet<Bug> Bugs { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}