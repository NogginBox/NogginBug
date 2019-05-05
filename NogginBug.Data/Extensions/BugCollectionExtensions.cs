using NogginBug.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace NogginBug.Data.Extensions
{
    public static class BugCollectionExtensions
    {
        public static IEnumerable<Bug> DeleteAll(this IEnumerable<Bug> bugs)
        {
            foreach(var bug in bugs)
            {
                bug.Delete();
            }
            return bugs;
        }

        public static IQueryable<Bug> WhereOpen(this IQueryable<Bug> bugs)
        {
            return bugs.Where(b => b.Status == BugStatus.Open);
        }

        public static IQueryable<Bug> WhereVisible(this IQueryable<Bug> bugs)
        {
            return bugs.Where(b => b.Status != BugStatus.Deleted);
        }
    }
}
