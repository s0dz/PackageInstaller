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
            var orderedDependencies = "";
            
            var dependencyGraph = new List<Tuple<string, string>>();

            foreach (var packageDependency in packageDependencies)
            {
                // Split input into two strings for each string array
                var parts = packageDependency.Split(':');

                // Remove whitespace after colon
                parts[0] = Regex.Replace(parts[0], @"\s+", "");
                parts[1] = Regex.Replace(parts[1], @"\s+", "");

                dependencyGraph.Add(Tuple.Create(parts[0], parts[1]));
            }

            // orderedDependencies = SortPackages(dependencyGraph);

            return orderedDependencies;
        }

        /// <summary>
        /// (https://en.wikipedia.org/wiki/Topological_sorting)
        /// Kahn's Algorithm for Topological Sorting:
        ///     L ← Empty list that will contain the sorted elements
        ///     S ← Set of all nodes with no incoming edge
        ///     while S is non-empty do
        ///         remove a node n from S
        ///         add n to tail of L
        ///         for each node m with an edge e from n to m do
        ///             remove edge e from the graph
        ///             if m has no other incoming edges then
        ///                 insert m into S
        ///     if graph has edges then
        ///         return error(graph has at least one cycle)
        ///     else 
        ///         return L(a topologically sorted order)
        /// </summary>
        /// <param name="dependencyGraph"></param>
        /// <returns></returns>
        public List<string> SortPackages(List<Tuple<string, string>> dependencyGraph)
        {
            throw new NotImplementedException();
        }
    }
}