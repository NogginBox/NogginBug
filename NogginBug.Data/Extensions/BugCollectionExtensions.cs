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

        public static IEnumerable<Bug> WhereOpen(this IEnumerable<Bug> bugs)
        {
            return bugs.Where(b => b.Status == BugStatus.Open);
        }

        public static IEnumerable<Bug> WhereVisible(this IEnumerable<Bug> bugs)
        {
            return bugs.Where(b => b.Status != BugStatus.Deleted);
        }
    }
}
