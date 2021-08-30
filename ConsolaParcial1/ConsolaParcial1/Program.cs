using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsolaParcial1
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            SearchPath.searchPath.CreateNodes();
            SearchPath.searchPath.BFS();
            SearchPath.searchPath.CreatePath();
            SearchPath.searchPath.PathFound();
            Console.WriteLine("Time taken for reaching shortest path " + timer.ElapsedMilliseconds + "ms");
        }
    }
}