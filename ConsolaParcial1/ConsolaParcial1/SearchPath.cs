using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaParcial1
{
    class SearchPath
    {
        class Node 
        {
            public bool IsExplored = false;
            public Node isExploredFrom;
            public int X { get; set; }
            public int Y { get; set; }

            public Node(int x, int y) 
            {
                X = x;
                Y = y;
            }
        }
        struct Position 
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class searchPath
        {
            private static Node _startingPoint = new Node(0, 0);
            private static Node _endingPoint = new Node(6, -1);
            private static Node _searchingPoint;                          
            private static bool _isExploring = true;

            static int[][] directions = new int[4][];

            private static Dictionary<Position, Node> storage = new Dictionary<Position, Node>(); 
            private static List<Node> path = new List<Node>();                                 
            private static Queue<Node> tail = new Queue<Node>();


            public static void CreateNodes()
            {
                storage.Add(new Position(0, 0), _startingPoint); //*
                storage.Add(new Position(1, 0), new Node(1, 0));
                storage.Add(new Position(2, 0), new Node(2, 0));
                storage.Add(new Position(3, 0), new Node(3, 0));
                storage.Add(new Position(0, -1), new Node(0, -1));
                storage.Add(new Position(1, -1), new Node(1, -1));
                storage.Add(new Position(2, -1), new Node(2, -1));
                storage.Add(new Position(3, -1), new Node(3, -1));
                storage.Add(new Position(0, -2), new Node(0, -2));
                storage.Add(new Position(1, -2), new Node(1, -2));//*
                storage.Add(new Position(2, -2), new Node(2, -2));
                storage.Add(new Position(3, -2), new Node(3, -2));
                storage.Add(new Position(0, -3), new Node(0, -3));
                storage.Add(new Position(1, -3), new Node(1, -3));
                storage.Add(new Position(2, -3), new Node(2, -3));
                storage.Add(new Position(3, -3), _endingPoint); 



            }


            public static void BFS()
            {
                tail.Enqueue(_startingPoint);
                while (tail.Count > 0 && _isExploring)
                {
                    _searchingPoint = tail.Dequeue();
                    OnReachingEnd();
                    ExploreNeighbourNodes();
                }
            }
         
            private static void OnReachingEnd()
            {
                if (_searchingPoint == _endingPoint)
                {
                    _isExploring = false;
                }
                else
                {
                    _isExploring = true;
                }
            }
            private static void ExploreNeighbourNodes()
            {
                if (!_isExploring) { return; }

                directions[0] = new int[] { 0, -1 };
                directions[1] = new int[] { 0, 1 }; 
                directions[2] = new int[] { 1, 0 }; 
                directions[3] = new int[] { -1, 0 }; 

                for (int i = 0; i < 4; i++)
                {
                    int neighbourPosX = _searchingPoint.X + directions[i][0];
                    int neighbourPosY = _searchingPoint.Y + directions[i][1];
                    Position neighbourPos = new Position(neighbourPosX, neighbourPosY);
                    if (storage.ContainsKey(neighbourPos))
                    {
                        Node neighbor = storage[neighbourPos];
                        if (!neighbor.IsExplored)
                        {
                            tail.Enqueue(neighbor);
                            neighbor.IsExplored = true;
                            neighbor.isExploredFrom = _searchingPoint;
                        }
                    }

                }
            }
   
            private static void SetPath(Node node)
            {
                path.Add(node);
            }
            public static void CreatePath()
            {
                SetPath(_endingPoint);
                Node previousNode = _endingPoint.isExploredFrom;

                while (previousNode != _startingPoint)
                {
                    SetPath(previousNode);
                    previousNode = previousNode.isExploredFrom;
                }

                SetPath(_startingPoint);
                path.Reverse();

            }
            public static void PathFound()
            {
                Console.WriteLine("Path:");
                Console.WriteLine();
                foreach (var i in path)
                {
                    Console.WriteLine(i.X + "," + i.Y);

                }
                Console.WriteLine();

            }




        }
    }
}