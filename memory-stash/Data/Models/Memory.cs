using System;
using System.Collections.Generic;

#nullable disable

namespace memory_stash.Data.Models
{
    public partial class Memory
    {
        public int Id { get; set; }
        public DateTime? Mdate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        // Navigation Properties

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<MemoryImage> MemoryImages { get; set; }
    }
}
