using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using RepositoryJSON;
using Newtonsoft.Json;
using RepositoryCsv;

namespace BusinessLogic
{
    public class Query
    {
        //thelei method
        public static async Task<int[]> CollectTheYears()
        {
            var list = CSV.readData();
            List<Task<int>> taskYears = new List<Task<int>>();
            List<int> years = new List<int>();
            foreach (var item in list)
            {
                years.Add(item.Year.Year);
            }
            var yearsGrouped = years.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
             

            foreach (var item in yearsGrouped)
            {
                taskYears.Add(Task.Run(() => item));
            }
            var resultsForYears = await Task.WhenAll(taskYears);

            return resultsForYears;

        }
        public static async Task<CsvData[]> DisplayAllTheData()
        {
            //ayto logika paei sto query.cs - Business logic
            var allTheData = CSV.readData();
            
            List<Task<CsvData>> allData = new List<Task<CsvData>>();
            
            foreach (var item in allTheData)
            {
                allData.Add(Task.Run(() => item));
            }

            var resultsForAllTheData = await Task.WhenAll(allData);

            return  resultsForAllTheData;  
        }

        public static List<CsvData> DisplaySpecificYears(int year)
        {
            
            var allTheData = CSV.readData();

            List<CsvData> allData = new List<CsvData>();

            foreach (var item in allTheData)
            {
                allData.Add(item);
            }

            var dataWithYears = (from y in allData
                where y.Year.Year == year
                select y).ToList();

            return dataWithYears;
        }
    }
}
