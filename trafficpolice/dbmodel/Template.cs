﻿using System;
using System.Collections.Generic;

namespace trafficpolice.dbmodel
{
    public partial class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string File { get; set; }
        public short Tabletype { get; set; }
        public DateTime Time { get; set; }
    }
}
