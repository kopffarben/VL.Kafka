using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StreamRecords
{
    [JsonConverter(typeof(VertexConverter))]
    public record Question : IQuestion
    {
        // IVertx
        public VertexType VertexType { get; } = VertexType.Answer;

        // INode
        public int VertexID { get; set; }
        public int SelfID { get; set; }
        public string de { get; set; }
        public string en { get; set; }

        // ITime
        public string CTime { get; set; }
        public string UTime { get; set; }

        // IQuestion
        public int[] answers { get; set; }
        public int[] categories { get; set; }
        public int[] keywords { get; set; }

        public Question()
        {

        }
    }
 }
