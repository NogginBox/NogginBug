using System;

namespace NogginBug.Data.Model
{
    public class Bug
    {
        /// <summary>
        /// Database ID
        /// Should not be exposed externally
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// A unique identifier for this bug that can be exposed to the outside world
        /// </summary>
        public Guid IdExternal { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public NogginBugUser AssignedUser { get; private set; }

        public DateTime OpenedDate { get; private set; }

        public BugStatus Status { get; private set; }

        /// <summary>
        /// Assigns a user to this bug.
        /// If user is null, this bug will be assigned to no one
        /// Only open bugs can be assigned to a different user or unassigned
        /// </summary>
        public bool AssignUser(NogginBugUser user)
        {
            if (Status != BugStatus.Open)
            {
                return false;
            }

            AssignedUser = user;
            return true;
        }

        /// <summary>
        /// Creates a new open bug with all required data
        /// </summary>
        public static Bug CreateNewOpenBug(string title, string description, DateTime openedDate)
        {
            return new Bug
            {
                IdExternal = Guid.NewGuid(),
                Title = title,
                Description = description,
                OpenedDate = openedDate,
                Status = BugStatus.Open
            };
        }

        /// <summary>
        /// Mark this bug as closed.
        /// (In the future may also update other properties for audit and extra info)
        /// </summary>
        public void Close()
        {
            Status = BugStatus.Closed;
        }

        /// <summary>
        /// Mark this bug as being deleted.
        /// Deleted bugs do not show in web interface.
        /// </summary>
        public void Delete()
        {
            Status = BugStatus.Deleted;
        }
    }
}
