using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.RandoStats
{
    public class RandoStat(List<ArchippelagoSlot> slots)
    {
        public List<ArchippelagoSlot> Slots { get; set; } = new List<ArchippelagoSlot>(slots);
    }
}
