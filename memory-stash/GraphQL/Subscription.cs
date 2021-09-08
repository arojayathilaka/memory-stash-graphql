using HotChocolate;
using HotChocolate.Types;
using memory_stash.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory_stash.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic] // type of subscription
        public Memory OnMemoryAdded([EventMessage] Memory memory) => memory; 
    }
}
