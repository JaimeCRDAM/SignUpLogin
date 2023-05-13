using System;
using System.Collections.Generic;
using Cassandra.Mapping.Attributes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTools.Database
{
    public class BaseEntity
    {
        [Column("id")]
        [PartitionKey]
        public Guid id { get; set; }

    }
}
