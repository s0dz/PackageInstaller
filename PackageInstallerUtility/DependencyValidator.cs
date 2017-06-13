using System;
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


                packageDependencyDictionary.Add(new KeyValuePair<string, string>(parts[0],parts[1]));
                keylist.Add(parts[0]);
            }

           

            var hi = FindPackage(packageDependencyDictionary.Count - 1, packageDependencyDictionary);

            var packageDependenciesString = string.Join(string.Empty, packageDependencies);
            return result;
        }

        public List<string> FindPackage(int count, List<KeyValuePair<string, string>> packageDependencyDictionary)
        {
            if (count == 0)
            {
                return stringList;
            }
            for (var i = 1; i < packageDependencyDictionary.Count; i++)
            {
                if (packageDependencyDictionary[count].Value.Equals(""))
                {
                    stringList.Add(packageDependencyDictionary[count].Key);
                    FindPackage(count - 1, packageDependencyDictionary);
                }
                else if (packageDependencyDictionary[i].Value == packageDependencyDictionary[count].Value)
                {
                    stringList.Add(packageDependencyDictionary[count].Key);
                    FindPackage(count - 1, packageDependencyDictionary);
                }
            }
            
            

            return stringList;
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