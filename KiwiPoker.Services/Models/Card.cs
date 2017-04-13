using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiPoker.Services
{
  public  class Card
    {
        public SuiteType   Suite { get; set; }
        public RankType Rank { get; set; }
        public int Value { get; set; }
    }
}
