using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using memory_stash.Data.Models;
using memory_stash.GraphQL.Inputs;
using memory_stash.GraphQL.Payloads;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace memory_stash.GraphQL
{
    public class Mutation
    {
        
        [UseDbContext(typeof(MemoryStashDbContext))] 
        public async Task<AddMemoryPayload> AddMemoryAsync(
            AddMemoryInput input, 
            [ScopedService] MemoryStashDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var memory = new Memory
            {
                Mdate = input.Mdate,
                Title = input.Title,
                Description = input.Description,
                GroupId = input.GroupId
            };

            context.Memories.Add(memory);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnMemoryAdded), memory, cancellationToken);

            return new AddMemoryPayload(memory);
        }


        [UseDbContext(typeof(MemoryStashDbContext))]
        public async Task<DeleteMemoryPayload> DeleteMemoryAsync(
            DeleteMemoryInput input,
            [ScopedService] MemoryStashDbContext context,
            CancellationToken cancellationToken)
        {

            var memory = await context.Memories.FindAsync(input.Id);
            context.Memories.Remove(memory);
            await context.SaveChangesAsync(cancellationToken);

            return new DeleteMemoryPayload(memory);
        }


        [UseDbContext(typeof(MemoryStashDbContext))]
        public async Task<UpdateMemoryPayload> UpdateMemoryAsync(
            UpdateMemoryInput input,
            [ScopedService] MemoryStashDbContext context,
            CancellationToken cancellationToken)
        {

            var memory = new Memory
            {
                Id = input.Id,
                Mdate = input.Mdate,
                Title = input.Title,
                Description = input.Description,
                GroupId = input.GroupId
            };

            context.Entry(memory).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);

            return new UpdateMemoryPayload(memory);
        }
    }
}
