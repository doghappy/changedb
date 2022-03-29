﻿using System.Collections.Generic;

namespace ChangeDB
{
    public record DatabaseDescriptor
    {
        //public string Collation { get; set; }
        //public string DefaultSchema { get; set; }

        public string DatabaseType { get; set; }

        public List<TableDescriptor> Tables { get; set; } = new List<TableDescriptor>();

        public List<SequenceDescriptor> Sequences { get; set; } = new List<SequenceDescriptor>();


    }
}
