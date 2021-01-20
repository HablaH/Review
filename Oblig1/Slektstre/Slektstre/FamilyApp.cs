using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Slektstre
{
    public class FamilyApp
    {
        public Person[] _people;

        public FamilyApp(params Person[] people)
        {
            _people = people;
        }

        public string HandleCommand(string command)
        {
            var commands = command.Split(' ');

            return commands[0] switch
            {
                "hjelp" => HelpText,
                "liste" => ListAllPeople(),
                "vis" when int.TryParse(commands[1], out var id) => GetPerson(id) + GetChildren(id),
                _ => "noe er feil, skriv 'hjelp' for hjelpetekst"
            };
        }

        public string GetPerson(int id)
        {
            return _people.ToList().Find(p => p.Id == id)?.GetDescription();
        }

        public string GetChildren(int id)
        {
            StringBuilder str = new StringBuilder();
            foreach (var person in _people)
            {
                if (HasFamily(person, id)) str.Append($"    {person.GetPersonalDescription()}\n");
            }

            if (str.Length > 0) str.Insert(0, "\n  Barn:\n");

            return str.ToString();
        }

        public bool HasFamily(Person person, int id)
        {
            return person.Father != null && person.Father.Id == id || person.Mother != null && person.Mother.Id == id;
        }

        public string ListAllPeople()
        {
            return _people.Aggregate("", (seed, person) => seed + person.GetDescription() + "\n");
        }

        public string WelcomeMessage = "Velkommen til familie appen!";
        public string HelpText = "For å finne data sjekk først om det ligger i registeret ved å skrive \"liste\"";
        public string CommandPrompt =
            "\n" +
            "----------------------------------------------------------------------------------------- \n" +
            "hjelp   => viser en hjelpetekst som forklarer alle kommandoene \n" +
            "liste   => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. \n" +
            "vis<id> => viser en bestemt person med mor, far og barn(og id for disse, slik at man lett kan vise en av dem) \n" +
            "----------------------------------------------------------------------------------------- \n" +
            "\n\n";
    }
}
