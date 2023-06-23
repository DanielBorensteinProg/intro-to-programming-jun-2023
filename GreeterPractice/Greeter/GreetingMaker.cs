using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Greeter
{
    public class GreetingMaker
    {

        private readonly IFindBadNames _findBadNames;

        public GreetingMaker(IFindBadNames findBadNames)
        {
            _findBadNames = findBadNames;
        }



        public string Greet(string? name, params string[] moreNames)
        {
            if (name == null)
            {
                name = "Daniel";
            }
            bool upperHandler = false;
            bool commaFound = false;


            if (name != null && name.Contains(","))
            {
                commaFound = true;
            }
            foreach (string moreName in moreNames)
            {
                if (moreName != null && moreName.Contains(","))
                {
                    commaFound = true;
                }
            }
            if (commaFound)
            {
                return commaHandler(name, moreNames);
            }
            List<string> lowerNames = new();
            List<string> upperNames = new();

            List<string> names = new();
            names.Add(name);
            names.AddRange(moreNames);

            foreach (string n in names.ToArray())
            {
                if (n == n.ToUpper())
                {
                    upperNames.Add(n);
                }
                else
                {
                    lowerNames.Add(n);
                }
            }
            lowerNames.AddRange(upperNames);
            var namezarray = lowerNames.ToArray();
            name = namezarray[0];
            moreNames = namezarray.Skip(1).ToArray();
            name = MultipleUsersNameHandler(name, moreNames);
            //var cleanedNames = badNameFilter(name, moreNames);
            //namezarray = cleanedNames.ToArray();
            //name = namezarray[0];
            //moreNames = namezarray.Skip(1).ToArray();
            if (name == name.ToUpper()) { upperHandler = true; }
            if (upperHandler)
            {
                return "HELLO, " + name + "!";
            }
            return "Hello, " + name + "!";
        }

        private List<string> badNameFilter(string? name, params string[] moreNames)
        {
            var badNames = _findBadNames.GetBadNames();
            List<string> listOfNames = new List<string>();
            List<string> cleanedNames = new List<string>();
            listOfNames.Add(name);
            listOfNames.AddRange(moreNames);
            foreach (string n in listOfNames.ToArray())
            {

                foreach (string badName in badNames)
                {
                    string cleanedName;
                    if (n.ToLower().Equals(badName.ToLower()))
                    {
                        cleanedName = n[0] + new string('*', name.Length - 2) + name[name.Length - 1];
                    }
                    else
                    {
                        cleanedName = n;
                    }
                    cleanedNames.Add(cleanedName);

                }
            }

            return cleanedNames;
        }

        private string commaHandler(string? name, params string[] moreNames)
        {

            List<string> listToPutInArray = new();
            string[] firstNames = name.Split(',');
            foreach (string firstName in firstNames)
            {
                string trimmedFirstName = firstName.Trim();
                if (trimmedFirstName != null && trimmedFirstName.Length > 0)
                {
                    listToPutInArray.Add(trimmedFirstName);
                }
            }
            foreach (string moreName in moreNames)
            {
                string[] nextNames = moreName.Split(',');
                foreach (string nextName in nextNames)
                {
                    string trimmedNextName = nextName.Trim();
                    if (trimmedNextName != null && trimmedNextName.Length > 0)
                    {
                        listToPutInArray.Add(trimmedNextName);
                    }
                }
            }

            listToPutInArray.ToArray();
            name = listToPutInArray[0];
            moreNames = listToPutInArray.Skip(1).ToArray();
            return Greet(name, moreNames);


        }

        private static string MultipleUsersNameHandler(string? name, params string[] moreNames)
        {

            var wordAnd = "and";
            if (name != null && name == name.ToUpper())
            {
                wordAnd = "AND";
            }
            {

            }
            if (moreNames != null && moreNames.Length > 0)
            {
                for (int i = 0; i < moreNames.Length - 1; i++)
                {
                    string moreName = moreNames[i];
                    if (moreName != null && moreName == moreName.ToUpper())
                    {
                        wordAnd = "AND";
                    }
                    if (moreName != null)
                    {
                        name += ", " + moreName;
                    }

                }
                if (moreNames[moreNames.Length - 1] != null && moreNames[moreNames.Length - 1] == moreNames[moreNames.Length - 1].ToUpper())
                {
                    wordAnd = "AND";

                }
                if (moreNames.Length == 1)
                {
                    name += " " + wordAnd + " " + moreNames[moreNames.Length - 1]; //2 names
                }
                else
                {
                    name += ", " + wordAnd + " " + moreNames[moreNames.Length - 1]; //more than 2 names
                }



            }

            return name;
        }
    }



}


public interface IFindBadNames
{
    List<string> GetBadNames()
    {
        List<string> listOfBadNames = new List<string>() { "Jayden", "Buffy" };
        return listOfBadNames;
    }
}