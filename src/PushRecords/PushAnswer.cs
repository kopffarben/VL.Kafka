using VL.Lib.Collections;

namespace StreamRecords
{
    public record PushAnswer
    {
        public string de { get; }
        public string en { get; }
        public string SessionID { get; }
        public Language language { get; }
        public string Timestamp { get; }
        public int Question { get; }
        public lang[] Keywords { get; }
        public int[] Categories { get; }

        public  PushAnswer(string de, string en, string language, string SessionID, Int64 timestamp, int Question, Spread<lang> Keywords, Spread<int> Categories)
        {
            this.de = de;
            this.en = en;
            switch(language)
            {
                case "de":
                    this.language = Language.german;
                    break;
                case "en":
                    this.language = Language.english;
                    break;
                default:
                    this.language = Language.none;
                    break;
            }
            this.SessionID = SessionID;
            this.Timestamp = timestamp.ToString();
            this.Question = Question;
            this.Keywords = Keywords.GetInternalArray();
            this.Categories = Categories.GetInternalArray();
        }
    }

    public record lang
    {
        public string de { get; } = "de";
        public string en { get; } = "en";

        public lang(string de, string en)
        {
            this.de = de;
            this.en = en;
        }
    }
}