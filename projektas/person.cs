using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrasAtsiskaitymas
{

    public class Person
    {
        protected string Name;
        protected string Surname;
       protected DateTime BirthDate;

        /* protected string address;


       //  public string Address
           //   {

           //  get
          //   {
          //       return address;
           //  }
           //  set
           //  {
           //      if (String.IsNullOrWhiteSpace(value))
           //          throw new Exception("Klaida");
           //      else
           //          address = value;
         //    }

              }
        */
        
        public Person(string name, string surname, DateTime birthDate)
        {

            if (name.Length > 0 && surname.Length > 0)
            {
                Name = name;
                Surname = surname;
            }
            
            else
                throw new Exception("Empty name or surname  value");

            if (birthDate <= DateTime.Now)
            {
                BirthDate = birthDate;
            }
            else

                throw new Exception("Try to pick your BirthdayDate again something is wrong");

            if (GetTestAge(birthDate) >= 14)
                BirthDate = birthDate;
            else
                throw new Exception("Must be 14 years old or older");

        }
        
        


        public int GetTestAge(DateTime date)
        {
            return (int)((DateTime.Now - BirthDate).TotalDays / 365.25);


        }

        public DateTime GetBirthDate()
        {
            return BirthDate;
        }

        public string GetName()
        {
            return Name;
        }
        public string GetSurname()
        {
            return Surname;
        }

        public int GetAge()
        {
           
                return (int)((DateTime.Now - BirthDate).TotalDays / 365.25);

            
        }
      
        public int DaysBefore()
        {


            DateTime today = DateTime.Today;
            DateTime next = BirthDate.AddYears(today.Year - BirthDate.Year);
            if (next < today)
                next = next.AddYears(1);

            int numDays = (next - today).Days;
            return numDays;


        }
      
    }
}