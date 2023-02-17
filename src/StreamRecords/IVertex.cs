using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StreamRecords
{
    [JsonConverter(typeof(VertexConverter))]
    public interface ImgVertex
    {
        public VertexType VertexType { get; }
    }

    public interface INode
    {
        public int VertexID { get; }
        public int SelfID { get; }
        public string de { get; }
        public string en { get; }
    }

    public interface ITime
    {
        public string CTime { get; }
        public string UTime { get; }
    }

    public interface IAnswer : ImgVertex, ITime, INode
    {
        public Language language { get; }
        public string SessionID { get; }
        public int[] categories { get; }
        public int[] questions { get; }
        public int[] keywords { get; }
    }

    public interface ICategory : ImgVertex, ITime, INode
    {
        public int[] answers { get; }
        public int[] questions { get; }
        public int[] keywords { get; }
    }

    public interface IQuestion : ImgVertex, ITime, INode
    {
        public int[] answers { get; }
        public int[] categories { get; }
        public int[] keywords { get; }
    }

    public interface IKeyword : ImgVertex, ITime, INode
    {
        public int[] answers { get; }
        public int[] categories { get; }
        public int[] questions { get; }
    }
    public interface ICounter : ImgVertex 
    {
        public int nAID { get; }
        public int nKID { get; }
        public int nVID { get; }
        public int nEID { get; }
    }


}
