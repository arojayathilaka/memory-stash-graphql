using HotChocolate;
using HotChocolate.Types;
using memory_stash.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory_stash.GraphQL.Types
{
    public class MemoryType : ObjectType<Memory>
    {
        protected override void Configure(IObjectTypeDescriptor<Memory> descriptor)
        {
            descriptor.Description("Represents a memory");

            // To ignore a field
            //descriptor
            //    .Field(m => m.Mdate).Ignore();

            descriptor
                .Field(m => m.MemoryImages)
                .ResolveWith<Resolvers>(m => m.GetMemoryImages(default!, default!))
                .UseDbContext<MemoryStashDbContext>()
                .Description("Urls of the memory images");

            descriptor
                .Field(m => m.Group)
                .ResolveWith<Resolvers>(m => m.GetGroup(default!, default!))
                .UseDbContext<MemoryStashDbContext>()
                .Description("Group of the memory");
        }

        private class Resolvers
        {
            public IQueryable<MemoryImage> GetMemoryImages(
                Memory memory, 
                [ScopedService] MemoryStashDbContext context)
            {
                return context.MemoryImages.Where(mi => mi.MemoryId == memory.Id);
            }

            public Group GetGroup(
                Memory memory,
                [ScopedService] MemoryStashDbContext context)
            {
                return context.Groups.FirstOrDefault(g => g.Id == memory.GroupId);
            }
        }
    }
}
