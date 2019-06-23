using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SuperPrize
    {
        public string Year { get; set; }
        public string Category { get; set; }
        public string OverallMotivation { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Motivation { get; set; }
        public string Share { get; set; }

        public SuperPrize(string year, string category, string overallMotivation, int id, string firstName, string surName, string motivation, string share)
        {
            Year = year;
            Category = category;
            OverallMotivation = overallMotivation;
            Id = id;
            FirstName = firstName;
            SurName = surName;
            Motivation = motivation;
            Share = share;
        }
    }
    public class Laureate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Motivation { get; set; }
        public string Share { get; set; }

        public Laureate(int id,string firstName,string surName,string motivation,string share)
        {
            Id = id;
            FirstName = firstName;
            SurName = surName;
            Motivation = motivation;
            Share = share;
        }
    }

    public class Prize
    {
        public string Year { get; set; }
        public string Category { get; set; }
        public string OverallMotivation { get; set; }
        public List<Laureate> Laureates { get; set; }

        public Prize(string year,string category,string overallMotivation, List<Laureate> laureates)
        {
            Year = year;
            Category = category;
            OverallMotivation = overallMotivation;
            Laureates = laureates;
        }
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
