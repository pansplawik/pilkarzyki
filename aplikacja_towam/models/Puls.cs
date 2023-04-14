﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace aplikacja_towam.models
{
    public class Puls
    {
        public Puls(int id, string wartosc, DateTime date)
        {
            this.id = id;
            this.wartosc = wartosc;
            this.data = date;
        }

        [DataMember(Name = "ID")]
        public int id { get; set; }
        [DataMember(Name = "wartosc")]
        public string wartosc { get; set; }
        [DataMember(Name = "data")]
        public DateTime data { get; set; }
    }
}