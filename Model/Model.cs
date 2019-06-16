using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Laureate
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string motivation { get; set; }
        public string share { get; set; }
    }

    public class Prize
    {
        public string year { get; set; }
        public string category { get; set; }
        public string overallMotivation { get; set; }
        public List<Laureate> laureates { get; set; }
    }

    public class RootObject
    {
        public List<Prize> prizes { get; set; }
    }
    public class LaureateSurname
    {
        public string Surname { get; }

        public LaureateSurname(string surname)
        {
            Surname = surname;
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
}