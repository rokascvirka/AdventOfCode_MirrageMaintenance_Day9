using AdventOfCode_MirrageMaintenance_Day9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_MirrageMaintenance_Day9
{
    public static class FileReader
    {
        public static List<History> ReadDataFromFile(string path)
        {
            List<History> history = new List<History>();
            using (StreamReader sr = new StreamReader(path))
            {
                var text = sr.ReadToEnd().Split(Environment.NewLine);
                foreach(var line in text)
                {
                    var data = line.Split("").ToList();
                    var numbers = line.Split(" ").Where(x => x != ""). Select(long.Parse).ToList();
                    history.Add(new History(numbers));
                }
            }

            return history;
        }
    }
}
