using System.Text.RegularExpressions;

namespace PackageInstallerUtility
{
    public class DependencyValidator
    {
        public string Validate(string[] packageDependencies)
        {
            // private string[] _validInput1 = { "KittenService: CamelCaser", "CamelCaser: " };
            // private string _validOutput1 = "CamelCaser, KittenService";

            foreach (var packageDependency in packageDependencies)
            {
                var parts = packageDependency.Split(':');


            }

            var packageDependenciesString = string.Join(string.Empty, packageDependencies);

            Regex.Replace(packageDependenciesString, @"\s+", "");

            return "";
        }
    }
}