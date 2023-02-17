using System;
using System.Collections.Generic;
using System.Text;

namespace StreamRecords
{
    public class PushCategory
    {
        public string de { get; }
        public string en { get; }
        public int SelfID { get; }

        public PushCategory(string de, string en, int ID)
        {
            this.de = de;
            this.en = en;
            this.SelfID = ID;
        }
    }
}
