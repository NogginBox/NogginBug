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

        public DateTime OpenedDate { get; private set; }

        public BugStatus Status { get; private set; }

        /// <summary>
        /// Creates a new open bug with all required data
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
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

        public void Close()
        {
            Status = BugStatus.Closed;
        }

        /// <summary>
        /// Mark this bug as being deleted and no longer show in web interface
        /// </summary>
        public void Delete()
        {
            Status = BugStatus.Deleted;
        }
    }
}
