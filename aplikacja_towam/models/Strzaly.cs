using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace aplikacja_towam.models
{
    [DataContract]
    public class Strzaly
    {
        public Strzaly(int id, int wartosc,DateTime date)
        {
            this.id = id;
            this.wartosc = wartosc;
            this.data = date;
        }
        [DataMember(Name = "ID")]
        public int id { get; set; }
        [DataMember(Name = "wartosc")]
        public int wartosc { get; set; }
        [DataMember(Name = "data")]
        public DateTime data { get; set; }
    }
}
