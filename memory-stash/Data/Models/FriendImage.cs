using System;
using System.Collections.Generic;

#nullable disable

namespace memory_stash.Data.Models
{
    public partial class FriendImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int FriendId { get; set; }

        // Navigation Properties
        public Friend Friend { get; set; }
    }
}
