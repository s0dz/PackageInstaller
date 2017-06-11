using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PackageInstallerUtility
{
    public class DependencyValidator
    {
        public string Validate(string[] packageDependencies)
        {
            // private string[] _validInput1 = { "KittenService: CamelCaser", "CamelCaser: " };
            // private string _validOutput1 = "CamelCaser, KittenService";
            var dictionary = new Dictionary<string, string>();
            var stringList = new List<string>();
            var result = "";

            foreach (var packageDependency in packageDependencies)
            {
                // Split input into two strings for each string array
                var parts = packageDependency.Split(':');

                parts[0] = Regex.Replace(parts[0], @"\s+", "");
                parts[1] = Regex.Replace(parts[1], @"\s+", "");

                dictionary.Add(parts[0],parts[1]);
            }

            // Go through each pair
            var count = 0;
            foreach (var keyValuePair in dictionary)
            {

                if (keyValuePair.Value.Equals(""))
                {
                    if (stringList.Count == 0)
                    {
                        stringList.Add(keyValuePair.Value);
                    }
                    else
                    {
                        stringList.Insert(0, keyValuePair.Value);
                    }
                }

                if (stringList.Contains(keyValuePair.Key))
                {
                    stringList.Insert(count+1, keyValuePair.Value);
                }
                else
                {
                    stringList.Insert(0, keyValuePair.Value);
                }
            }

            var packageDependenciesString = string.Join(string.Empty, packageDependencies);

            count++;
            return "";
        }
    }
}