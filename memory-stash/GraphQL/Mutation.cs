using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using memory_stash.Data.Models;
using memory_stash.GraphQL.Inputs;
using memory_stash.GraphQL.Payloads;
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
                Mdate = input.mdate,
                Title = input.title,
                Description = input.description,
                GroupId = input.groupId
            };

            context.Memories.Add(memory);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnMemoryAdded), memory, cancellationToken);

            return new AddMemoryPayload(memory);
        }
    }
}
