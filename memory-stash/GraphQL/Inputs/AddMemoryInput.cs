﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory_stash.GraphQL.Inputs
{
    public record AddMemoryInput(DateTime Mdate, string Title, string Description, int GroupId);
}
