using System;
using System.Collections.Generic;
using System.Text;

namespace Slektstre
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public string GetPersonalDescription()
        {
            var firstName = FirstName != null ? FirstName + " " : string.Empty;
            var lastName = LastName != null ? LastName + " " : string.Empty;
            var birthYear = BirthYear != 0 ? " Født: " + BirthYear.ToString() : string.Empty;
            var deathYear = DeathYear != 0 ? " Død: " + DeathYear.ToString() : string.Empty;

            return $"{firstName}{lastName}(Id={Id}){birthYear}{deathYear}";
        }

        public string GetDescription()
        {
            var str = new StringBuilder();
            str.Append(GetPersonalDescription());

            if (Father != null)
            {
                var fatherName = Father.FirstName != null ? Father.FirstName + " " : string.Empty;
                str.Append($" Far: {fatherName}(Id={Father.Id.ToString()})");
            }
            if (Mother != null)
            {
                string motherName = Mother.FirstName != null ? Mother.FirstName + " " : string.Empty;
                str.Append($" Mor: {motherName}(Id={Mother.Id.ToString()})");
            }
            return str.ToString();
        }
    }
}
