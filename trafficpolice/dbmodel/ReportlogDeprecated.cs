﻿using System;
using System.Collections.Generic;

namespace trafficpolice.dbmodel
{
    public partial class ReportlogDeprecated
    {
        public string Date { get; set; }
        public string Unitid { get; set; }
        public string Content { get; set; }
        public short Draft { get; set; }
        public DateTime Time { get; set; }
        public string Declinereason { get; set; }
        public DateTime? Submittime { get; set; }

        public Unit Unit { get; set; }
    }
}