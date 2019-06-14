using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebConnect;
using Model;

namespace RepositoryCsv
{
    public class CSV
    {
        public static List<string> requested = Api.RequestCsv();


        public static List<CsvData> readData()
        {
            // Here after the connection the database we manipulate the csv string
            
            List<CsvData> dataFromCsv = new List<CsvData>();
                for (int i = 1; i < requested.Count; i++)
                {
                    
                    
                    string[] p = requested[i].Split(',');
                    if (i == 56 || i == 57)
                    {
                        continue;
                    }
                    else
                    {
                        CsvData data = new CsvData(p[0], p[1], p[2], p[3], p[4], p[5], p[6], p[7]); //30

                        dataFromCsv.Add(data);
                    }

                }

                return dataFromCsv;
        }
    }
}
