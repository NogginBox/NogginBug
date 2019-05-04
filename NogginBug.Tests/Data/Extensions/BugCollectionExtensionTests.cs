using NogginBug.Data.Extensions;
using NogginBug.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NogginBug.Tests.Data.Extensions
{
    public class BugCollectionExtensionTests
    {

        [Fact]
        public void DeleteAllMarksAllBugsForDeletion()
        {
            // Arrange
            var bugs = CreateOpenBugs(3, new DateTime(2019, 05, 02));

            // Act
            bugs.DeleteAll();

            // Assert
            Assert.All(bugs, b => Assert.Equal(BugStatus.Deleted, b.Status));
        }

        [Fact]
        public void WhereOpenReturnsOpenBugs()
        {
            // Arrange
            var bugs = CreateOpenBugs(3, new DateTime(2019, 05, 02));
            bugs[1].Close();

            // Act
            var openBugs = bugs.WhereOpen().ToList();

            // Assert
            Assert.Equal(2, openBugs.Count);
        }


        private IList<Bug> CreateOpenBugs(int numBugs, DateTime openDate)
        {
            return Enumerable.Range(1, 3)
                .Select(i => Bug.CreateNewOpenBug($"Bug {i}", "Description {i}", openDate))
                .ToList();

        }
    }
}
