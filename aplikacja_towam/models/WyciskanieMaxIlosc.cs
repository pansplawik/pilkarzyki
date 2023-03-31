using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace aplikacja_towam.models
{
    public class WyciskanieMaxIlosc
    {
        public WyciskanieMaxIlosc(int id, int wartosc, int ilosc,DateTime date)
        {
            this.id = id;
            this.wartosc = wartosc;
            this.ilosc = ilosc;
            this.data = date;
        }

        [DataMember(Name = "ID")]
        public int id { get; set; }
        [DataMember(Name = "wartosc")]
        public int wartosc { get; set; }
        [DataMember(Name="ile")]
        public int ilosc { get; set; }
        [DataMember(Name = "data")]
        public DateTime data { get; set; }
    }
}
