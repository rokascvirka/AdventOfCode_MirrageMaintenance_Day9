using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_MirrageMaintenance_Day9.Model
{
    public class History
    {
        public List<long> Records { get; set; }

        public List<List<long>> Calculations { get; set; }

        public long SumOfLastRecords { get; set; }
        public History(List<long> records)
        {
            Records = records;
        }
    }
}
