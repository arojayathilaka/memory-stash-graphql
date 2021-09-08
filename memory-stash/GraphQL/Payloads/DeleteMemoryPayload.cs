using memory_stash.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory_stash.GraphQL.Payloads
{
    public record DeleteMemoryPayload(Memory Memory);
}
