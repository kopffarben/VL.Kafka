using System;
using System.Collections.Generic;
using System.Text;

namespace StreamRecords
{
    public record Vertex : ImgVertex
    {
        public VertexType VertexType { get; } = VertexType.Keyword;
    }
}
