using System;
using System.Collections.Generic;
using System.Text;

namespace StreamRecords
{
    public record Counter : ICounter
    {
        // IVertx
        public VertexType VertexType { get; } = VertexType.Counter;

        // ICounter
        public int nAID { get; set; }
        public int nEID { get; set; }
        public int nKID { get; set; }
        public int nVID { get; set; }
        
        public Counter()
        {

        }


    }
}
