using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace lab4.ClassLibrary
{
    public static class Lab3
    {

        // Function to find the distance of
        // the node from the given source
        // vertex to the destination vertex
        static int[] dijkstraDist(List<Node> g, int s, int[] path)
        {
            // Stores distance of each
            // vertex from source vertex
            int[] dist = new int[g.Count];
          
            // bool array that shows
            // whether the vertex 'i'
            // is visited or not
            bool[] visited = new bool[g.Count];
            for(int i = 0; i < g.Count; i++)
            {
                visited[i] = false;
                path[i] = -1;
                dist[i] = Int32.MaxValue;
            }
            dist[s] = 0;
            path[s] = -1;
            int current = s;
          
            // Set of vertices that has
            // a parent (one or more)
            // marked as visited
            HashSet<int> sett = new HashSet<int>();
             
            while (true)
            {
                  
                // Mark current as visited
                visited[current] = true;
                for(int i = 0;
                        i < g[current].children.Count;
                        i++)
                {
                    int v = g[current].children[i].first;           
                    if (visited[v])
                        continue;
          
                    // Inserting into the
                    // visited vertex
                    sett.Add(v);
                    int alt = dist[current] +
                             g[current].children[i].second;
          
                    // Condition to check the distance
                    // is correct and update it
                    // if it is minimum from the previous
                    // computed distance
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        path[v] = current;
                    }
                }
                sett.Remove(current);
                  
                if (sett.Count == 0)
                    break;
          
                // The new current
                int minDist = Int32.MaxValue;
                int index = 0;
          
                // Loop to update the distance
                // of the vertices of the graph
                foreach(int a in sett)
                {
                    if (dist[a] < minDist)
                    {
                        minDist = dist[a];
                        index = a;
                    }
                }
                current = index;
            }
            return dist;
        }

        // Function to print the path
        // from the source vertex to
        // the destination vertex
        

        public static void Run(string input, string output)
        {

            string[] lines;
            string result = "";
            try
            {
                lines = File.ReadAllLines(input);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find file: " + e.FileName);
                return;
            }

            var nodesnum = Int32.Parse(lines[0].Split(" ")[0]);
            var edgesnum = Int32.Parse(lines[0].Split(" ")[1]);
            if (lines.Length != edgesnum + 1)
            {
                throw new ArgumentException($"You must have {edgesnum + 1} lines in input file");
            }

            if (nodesnum < 1 || nodesnum > 100)
            {
                throw new ArgumentException($"Number of nodes must be in range [1, 1000]");
            }

            if (edgesnum < 0 || edgesnum > 10000)
            {
                throw new ArgumentException($"Number of edges must be in range [1, 1000]");
            }


            
            List<Node> v = new List<Node>();
            int n = 4, s = 0;
  
            // Loop to create the nodes
            for(int i = 0; i < n; i++)
            {
                Node a = new Node(i);
                v.Add(a);
            }

            foreach (var edge in lines.Skip(1))
            {
                var temp = edge.Split(" ");
                if (temp.Length != 3)
                {
                    throw new ArgumentException($"You must have 3 numbers in each line");
                }
                var from = Int32.Parse(temp[0]);
                var to = Int32.Parse(temp[1]);
                var weight = Int32.Parse(temp[2]);
                if (weight < -100 || weight > 100)
                {
                    throw new ArgumentException($"Weight of edge must be in range [-100, 100]");
                }

                v[from-1].Add_child(to-1, weight);
            }

            int[] path = new int[v.Count];
            int[] dist = dijkstraDist(v, s, path);
  
            // Loop to print the distance of
            // every node from source vertex
            for(int i = 0; i < dist.Length; i++)
            {
                if (dist[i] == Int32.MaxValue)
                {
                    result += "30000" + " ";
                    continue;
                }
                result += dist[i] + " ";

            }
            
            
            try
            {
                File.WriteAllText(output, result);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not find file: " + e.FileName);
                return;
            }
            Console.WriteLine(result);
        }

    }
}