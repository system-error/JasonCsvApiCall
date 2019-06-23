using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace Experiments
{
    class Program
    {
       

        static void Main(string[] args)
        {
            string responseFromServer;
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
                "http://api.nobelprize.org/v1/prize.json?");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                responseFromServer = reader.ReadToEnd();
                // Display the content.  
                //Console.WriteLine(responseFromServer);
            }

            // Close the response.  
            response.Close();

            //-----------------------------------------------------------------------------
            //string str = "My name is, Christos,test";
            //string[] split = str.Split(',');

            //for (int i = 0; i < split.Length; i++)
            //{

            //}

            //foreach (var item in split)
            //{
            //    Console.WriteLine(item);
            //}
            //var lista = DeserializeCsv.Decerialize();
            //foreach (var item in lista)
            //{
            //    Console.WriteLine(item.Category);

            //}
            //CallTheCsv.RequestCsv();

            //List<string> splitted = new List<string>();
            //string[] tempStr;
            //string fileList = responseFromServer;
            //tempStr = fileList.Split(',');

            //foreach (string item in tempStr)
            //{
            //    if (!string.IsNullOrWhiteSpace(item))
            //    {
            //        splitted.Add(item);
            //    }
            //}

            var list = JsonConvert.DeserializeObject<RootObject>(responseFromServer);

            
            foreach (var item in list.prizes)
            {
                Console.Write(item.Year);
                Console.Write(item.Category);
                foreach (var itemLaureate in item.Laureates)
                {
                    Console.WriteLine(itemLaureate.FirstName);
                    Console.WriteLine(itemLaureate.SurName);
                    Console.WriteLine(itemLaureate.Id);
                }
                Console.Write(item.OverallMotivation);
            }

                

                


            




            //var lista = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
            //List<Laureate> general = new List<Laureate>();
            //List<string> Years = new List<string>();




            //    List<Prize> list = new List<Prize>();

            //    for (int i = 0; i < lista.prizes.Count; i++)
            //    {
            //        list.Add(lista.prizes[i]);

            //    }

            //    foreach (var item in list)
            //    {
            //        Console.WriteLine(item.Laureates);
            //        for (int i = 0; i < item.Laureates.Count; i++)
            //        {
            //            general.Add(item.Laureates[i]);
            //        }

            //    }





            //foreach (var item in lista.prizes)
            //{
            //    for (int i = 0; i < item.laureates.Count; i++)
            //    {
            //        Console.WriteLine(item.laureates[i].surname);
            //    }

            //    //LaureateSurname Ls = new LaureateSurname(item.laureates[0].surname);
            //    //Surnames.Add(Ls);
            //}

            //List<CsvData> dataFromCsv = new List<CsvData>();
            //for (int i = 1; i < requested.Count; i++)
            //{
            //    string[] p = requested[i].Split(',');
            //    if (i == 56 || i == 57)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        CsvData data = new CsvData(p[0], p[1], p[2], p[3], p[4], p[5], p[6], p[7]); //30

            //        dataFromCsv.Add(data);
            //    }
            //}




            //foreach (var item in lista.prizes)
            //{
            //    Console.WriteLine(item);


            //    Years.Add(item);
            //}

            //foreach (var item in Years)
            //{
            //    Console.WriteLine();
            //}


            //var yearsGrouped = Years. GroupBy(x => x)
            //    .Where(g => g.Count() > 1)
            //    .Select(y => y.Key)
            //    .ToList();

            //foreach (var item in yearsGrouped)
            //{
            //    Console.WriteLine(item);
            //}
        }

        class LaureateSurname
        {
            private string Surname { get; }

            public LaureateSurname(string surname)
            {
                Surname = surname;
            }
        }

        class PrizesYears
        {
            private string Year { get; }

            public PrizesYears(string year)
            {
                Year = year;
            }
        }

    }
    public class CsvData
    {
        public DateTime Year { get; }
        public string Category { get; }
        public string OverallMotivation { get; }
        public int Id { get; }
        public string Firstname { get; }
        public string Surname { get; }
        public string Motivation { get; }
        public string Share { get; }

        public CsvData(string year, string category, string overallMotivation,
            string id, string firstname, string surname, string motivation, string share)
        {
            //int _year = Convert.ToInt32(year);
            Year = DateTime.ParseExact(year, "yyyy", CultureInfo.InvariantCulture);
            Category = category;
            OverallMotivation = overallMotivation;
            Id = Convert.ToInt32(id);
            Firstname = firstname;
            Surname = surname;
            Motivation = motivation;
            Share = share;
        }

    }
    public class DeserializeCsv
    {
        public static List<string> requested = CallTheCsv.RequestCsv();



        public static List<CsvData> Decerialize()
        {

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

    class CallTheCsv
    {
        public static List<string> RequestCsv()
        {

            string responseFromServer;
            List<string> csvFile = new List<string>();

            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
                "http://api.nobelprize.org/v1/prize.csv?");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                while ((responseFromServer = reader.ReadLine()) != null)
                {
                    //string actualName = Regex.Replace(responseFromServer, @"[\r]+", " ");
                    string[] test = responseFromServer.Split('\n');

                    foreach (var item in test)
                    {
                        csvFile.Add(item);
                    }
                }
                // Display the content.  
                //Console.WriteLine(responseFromServer);
            }
            // Close the response.  
            response.Close();

            return csvFile;



        }

    }

}
