using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PackageInstallerUtility
{
    public class DependencyValidator
    {
        List<string> stringList = new List<string>();

        public string Validate(string[] packageDependencies)
        {
            // private string[] _validInput1 = { "KittenService: CamelCaser", "CamelCaser: " };
            // private string _validOutput1 = "CamelCaser, KittenService";
            // var packageDependencyDictionary = new Dictionary<string, string>();
            var packageDependencyDictionary = new List<KeyValuePair<string, string>>();
            var keylist = new List<string>();
            var stringList = new List<string>();
            var result = "";

            foreach (var packageDependency in packageDependencies)
            {
                // Split input into two strings for each string array
                var parts = packageDependency.Split(':');

                // Remove whitespace after colon
                parts[0] = Regex.Replace(parts[0], @"\s+", "");
                parts[1] = Regex.Replace(parts[1], @"\s+", "");

                if(parts[1] == "") { stringList.Add(parts[0]);}

                packageDependencyDictionary.Add(new KeyValuePair<string, string>(parts[0],parts[1]));
                keylist.Add(parts[0]);
            }

            FindPackage(packageDependencyDictionary[0].Value, packageDependencyDictionary, keylist);

            var packageDependenciesString = string.Join(string.Empty, packageDependencies);
            return result;
        }

        public string FindPackage(string value, List<KeyValuePair<string, string>> packageDependencyDictionary, List<string> keylist)
        {
            for (int i = 0; i < keylist.Count; i++)
            {
                if (value.Equals(""))
                {
                    stringList.Add(keylist[i]);
                    FindPackage(packageDependencyDictionary[i+1].Value, packageDependencyDictionary, keylist);
                }
                else
                {
                    if (keylist.Contains(value))
                    {
                        stringList.Add(value);
                        FindPackage(packageDependencyDictionary[i].Key, packageDependencyDictionary, keylist);
                    }
                }
            }

            return "";
        }
    }


    
            // Go through each pair
            //var count = 0;
            /*while (count < packageDependencies.Length)
            {
                var key = packageDependencyDictionary[count].Key;
                var value = packageDependencyDictionary[count].Value;
                if (value.Equals(""))
                {
                    if (stringList.Count == 0)
                    {
                        stringList.Add(key);
                    }
                    else
                    {
                        stringList.Insert(0, key);
                    }
                }
                else
                {

                    if (stringList.Contains(value))
                    {
                        stringList.Insert(count + 1, value);
                    }
                    else
                    {
                        stringList.Insert(0, key);
                    }
                }
                count += 1;
            }*/
            
}