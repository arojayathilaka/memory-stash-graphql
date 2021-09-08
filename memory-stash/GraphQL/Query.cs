using HotChocolate;
using HotChocolate.Data;
using memory_stash.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory_stash.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(MemoryStashDbContext))] // For multi threading
        [UseFiltering]
        [UseSorting]
        public IQueryable<Memory> GetMemories([ScopedService] MemoryStashDbContext context)
        {
            return context.Memories;
        }


        [UseDbContext(typeof(MemoryStashDbContext))]
        public IQueryable<Group> GetGroups([ScopedService] MemoryStashDbContext context)
        {
            return context.Groups;
        }


        [UseDbContext(typeof(MemoryStashDbContext))]
        public IQueryable<MemoryImage> GetMemoryImages([ScopedService] MemoryStashDbContext context)
        {
            return context.MemoryImages;
        }


        [UseDbContext(typeof(MemoryStashDbContext))]
        public IQueryable<User> GetUsers([ScopedService] MemoryStashDbContext context)
        {
            return context.Users;
        }
    }
}
