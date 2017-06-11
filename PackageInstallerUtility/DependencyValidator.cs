using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace PackageInstallerUtility
{
    public class DependencyValidator
    {
        public string Validate(string[] packageDependencies)
        {
            // private string[] _validInput1 = { "KittenService: CamelCaser", "CamelCaser: " };
            // private string _validOutput1 = "CamelCaser, KittenService";
            // var packageDependencyDictionary = new Dictionary<string, string>();
            var packageDependencyDictionary = new List<KeyValuePair<string, string>>();
            var stringList = new List<string>();
            var result = "";

            foreach (var packageDependency in packageDependencies)
            {
                // Split input into two strings for each string array
                var parts = packageDependency.Split(':');

                // Remove whitespace after colon
                parts[0] = Regex.Replace(parts[0], @"\s+", "");
                parts[1] = Regex.Replace(parts[1], @"\s+", "");

                packageDependencyDictionary.Add(new KeyValuePair<string, string>(parts[0],parts[1]));
            }

            // Go through each pair
            var count = packageDependencies.Length;
            while(count > 0)
            {
                count -= 1;
                if (packageDependencyDictionary[count].Value.Equals(""))
                {
                    if (stringList.Count == 0)
                    {
                        stringList.Add(packageDependencyDictionary[count].Key);
                    }
                    else
                    {
                        stringList.Insert(0, packageDependencyDictionary[count].Value);
                    }
                }

                if (stringList.Contains(packageDependencyDictionary[count].Key))
                {
                    stringList.Insert(packageDependencies.Length - count, packageDependencyDictionary[count].Value);
                }
                else
                {
                    stringList.Insert(0, packageDependencyDictionary[count].Value);
                }
            }

            var packageDependenciesString = string.Join(string.Empty, packageDependencies);

            count++;
            return result;
        }
    }
}