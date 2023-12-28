using AdventOfCode_MirrageMaintenance_Day9.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_MirrageMaintenance_Day9
{
    public static class Calculator
    {


        public static void AddCalculations(List<History> history)
        {
            foreach(var record in history)
            {
                var IsUpdateNeeded = true;
                var calculations = new List<List<long>>();
                var firstCalculation = SetFirstCalculation(record);
                calculations.Add(record.Records);
                calculations.Add(firstCalculation);
                record.Calculations = calculations;

                while (IsUpdateNeeded)
                {
                    var lastRecord = record.Calculations.LastOrDefault();
                    var newRecord = FillPlaceHolders(lastRecord);
                    calculations.Add(newRecord);
                    var number = calculations.LastOrDefault().LastOrDefault();
                    if (number == 0)
                    {
                        IsUpdateNeeded = false;
                    }
                }
                record.Calculations = calculations;
            }
        }
        public static List<long> FillPlaceHolders(List<long> records) 
        { 
            List<long> nextRecords = new List<long>();

            for (int i = 0; i < records.Count-1; i++)
            {
                var difference = records[i+1] - records[i];
                nextRecords.Add(difference);
            }

            return nextRecords;
        }

        public static List<long> SetFirstCalculation(History history)
        {
            var rec = history.Records;
            return FillPlaceHolders(rec);
        }

        public static void UpdateCalculations(List<History> data)
        {
            foreach (var rec in data)
            {
                var calculations = rec.Calculations;
                for (int i = calculations.Count - 1; i >= 1; i--)
                {
                    var currentCalculation = calculations[i];
                    var nextCalculation = calculations[i - 1];
                    var currentLastMember = currentCalculation.LastOrDefault();
                    var nextlastMember = nextCalculation.LastOrDefault();
                    if((calculations.Count - 1) == calculations.IndexOf(currentCalculation))
                    {
                        currentCalculation.Add(0);
                        nextCalculation.Add(currentLastMember + nextlastMember);
                    }
                    else
                    {
                        nextCalculation.Add(currentLastMember + nextlastMember);
                    }
                }
            }
        }

        public static void SetSum(List<History> data)
        {
            foreach(var rec in data)
            {
                var result = rec.Calculations.FirstOrDefault().LastOrDefault();
                rec.SumOfLastRecords = result;
            }
        }
        
    }
}
