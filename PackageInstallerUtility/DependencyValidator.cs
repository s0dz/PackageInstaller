using System;
using System.Text.RegularExpressions;

namespace PackageInstallerUtility
{
    public class DependencyValidator
    {
        public string Validate(string[] packageDependencies)
        {
            var packageDependenciesString = String.Join(String.Empty, packageDependencies);

            Regex.Replace(packageDependenciesString, @"\s+", "");

            return "";
        }
    }
}