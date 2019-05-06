using System;

namespace NogginBug.Data.Model
{
    public class NogginBugUser
    {
        /// <summary>
        /// Database ID.
        /// Should not be exposed externally
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// A unique identifier for this user that can be exposed to the outside world
        /// </summary>
        public Guid IdExternal { get; private set; }

        public string Name { get; set; }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public static NogginBugUser CreateNewUser(string name)
        {
            return new NogginBugUser
            {
                IdExternal = Guid.NewGuid(),
                Name = name
            };
        }
    }
}
