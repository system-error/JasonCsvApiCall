using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebConnect;
using Model;

namespace RepositoryJSON
{
    public class JSON
    {
        public static RootObject list = JsonConvert.DeserializeObject<RootObject>(Api.RequestJSON());
        ////////////////////////////////////////////////////////////////
        public static List<SuperPrize> TakeAll()
        {
            List<SuperPrize> sp = new List<SuperPrize>();
            foreach (var item in list.prizes)
            {
                for (int i = 0; i < item.Laureates.Count; i++)
                {
                    SuperPrize t = new SuperPrize(item.Year, item.Category, item.OverallMotivation, Convert.ToInt32(item.Laureates[i].Id), item.Laureates[i].FirstName, item.Laureates[i].SurName, item.Laureates[i].Motivation, item.Laureates[i].Share);
                    sp.Add(t);
                }
            }
            return sp;
        }



        //public static List<Laureate> TakeTheLaureates()
        //{

        //    // Here after the connection the database we manipulate the json string

        //    List<Laureate> Laureates = new List<Laureate>();

        //    foreach (var item in list.prizes)
        //    {
        //        for (int i = 0; i < item.Laureates.Count; i++)
        //        {
        //            Laureate Ls = new Laureate(Convert.ToInt32(item.Laureates[i].Id),item.Laureates[i].FirstName,item.Laureates[i].SurName,item.Laureates[i].Motivation,item.Laureates[i].Share);
        //            Laureates.Add(Ls);
        //        }
        //    }

        //    return Laureates;
        //}

        //public static List<Prize> TakeThePrizes()
        //{

        //    // Here after the connection the database we manipulate the json string

        //    List<Prize> prizes = new List<Prize>();

        //    foreach (var item in list.prizes)
        //    {
        //        Prize pr = new Prize(item.Year,item.Category,item.OverallMotivation, TakeTheLaureates());
        //        prizes.Add(pr);

        //    }

        //    return prizes;
        //}

        //public static List<int> TakeTheYears()
        //{

        //    // Here after the connection the database we manipulate the json string

        //    List<int> Years = new List<int>();

        //    foreach (var item in list.prizes)
        //    {
        //        Console.WriteLine(item.year);


        //        Years.Add(Convert.ToInt32(item.year));
        //    }

        //    return Years;
        //}

        /////////////////////////////////////////////////////////////////////////////////

    }
}
