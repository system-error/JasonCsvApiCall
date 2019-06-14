using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebConnect;
using Model;

namespace RepositoryJSON
{
    public class JSON
    {
        public static List<LaureateSurname> readData()
        {
           var Json =  Api.RequestJSON();
            // Here after the connection the database we manipulate the csv string
            var lista = JsonConvert.DeserializeObject<RootObject>(Json);
            List<LaureateSurname> Surnames = new List<LaureateSurname>();

            foreach (var item in lista.prizes)
            {
                Console.WriteLine(item.laureates[0].surname);
                LaureateSurname Ls = new LaureateSurname(item.laureates[0].surname);
                Surnames.Add(Ls);
            }

            return Surnames;
        }
    }
}
