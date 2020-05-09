using System;

namespace GraphFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            char[][] friends = { "YYNN".ToCharArray(), "YYYN".ToCharArray(), "NYYN".ToCharArray(), "NNNY".ToCharArray() };
            Console.WriteLine(getFriendCircles(friends));
            Console.ReadLine();

        }

        public static int getFriendCircles(char[][] friends)
        {
            if (friends == null || friends.Length < 1)
                return 0;
            int numOfCircles = 0;
            bool[] visited = new bool[friends.Length];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            for(int i = 0; i <friends.Length;i++)
            {
                if (!visited[i])
                {
                    numOfCircles++;
                    visited[i] = true;
                    findFriends(friends, visited, i);
                   
                    
                }
            }
            return numOfCircles;
        }

        private static void findFriends(char[][] friends, bool[] visited, int ind)
        {
            for(int i=0; i<friends.Length;i++)
            {
                if (!visited[i] && i !=ind && friends[ind][i]=='Y')
                {
                    visited[i] = true;
                    findFriends(friends, visited, i);
                }
            }
        }
    }
}
