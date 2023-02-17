using System;
using System.Collections.Generic;
using System.Text;

namespace StreamRecords
{
    public class PushQuestion
    {
        public string de { get; }
        public string en { get; }
        public int SelfID { get; }

        public PushQuestion(string de, string en, int ID)
        {
            this.de = de;
            this.en = en;
            this.SelfID = ID;
        }
    }
}
