using Newtonsoft.Json;

namespace StreamRecords
{
    public record Answer : IAnswer
    {
        // IVertx
        public VertexType VertexType { get; } = VertexType.Answer;

        // INode
        public int VertexID { get; set; }  = -1;
        public int SelfID   { get; set; }    = -1;
        public string de    { get; set;  }     = "";
        public string en    { get; set; }     = "";

        // ITime
        public string CTime { get; set; }  = "";
        public string UTime { get; set; }  = "";

        // IAnswer
        public Language language { get; set; } = Language.none;
        public string SessionID  { get; set; }  = "";
        public int[] categories  { get; set; }  = new int[0];
        public int[] questions   { get; set; }  = new int[0];
        public int[] keywords    { get; set; }  = new int[0];

        public Answer()
        {
        }
    }
}