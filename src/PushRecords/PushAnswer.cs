using VL.Core;
using VL.Lib.Collections;

namespace StreamRecords
{
    public record PushAnswer
    {
        public string de { get; set; }
        public string en { get; set; }
        public string SessionID { get; set; }
        public Language language { get; set; }
        public string Timestamp { get; set; }
        public int Question { get; set; }
        public lang[] Keywords { get; set; }
        public int[] Categories { get; set; }

        public PushAnswer()
        {

        }

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
        public PushAnswer(string de, string en, string language, string SessionID, Int64 timestamp, int Question, lang[] Keywords, int[] Categories)
        {
            this.de = de;
            this.en = en;
            switch (language)
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
            this.Keywords = Keywords;
            this.Categories = Categories;
        }
        public void Split(out string de, out string en, out string language, out string SessionID, out Int64 timestamp, out int Question, out Spread<lang> Keywords, out Spread<int> Categories)
        {
            de = this.de;
            en = this.en;
            language = this.language.ToString();
            SessionID = this.SessionID;
            timestamp = Convert.ToInt64(Timestamp);
            Question = this.Question;
            Keywords = Spread.Create(this.Keywords);
            Categories = Spread.Create(this.Categories);
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