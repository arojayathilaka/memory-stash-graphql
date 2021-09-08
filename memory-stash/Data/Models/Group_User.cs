using System;
using System.Collections.Generic;

#nullable disable

namespace memory_stash.Data.Models
{
    public partial class Group_User
    {
        public int Id { get; set; }

        // Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
