using System;
using System.Collections.Generic;
using System.Linq;

namespace Execercies1
{
    class Program
    {
        static void Main(string[] args)
        {
          var board = new char[,]{{'o', 'a', 'a', 'n'}, {'e','t','a','e'}, {'i','h','k','r'}, {'i','f','l','v'}};

          var  words = new string[] {"oath","pea","eat","rain"};

       //   var cfg = new GFG(words, board);

   //       var result = cfg.findWords().ToArray();

      //    Console.WriteLine(String.Join("\n", result));

          char[] baData = new char[board.Length];

          baData = board.Cast<char>().ToArray();
		 // Buffer.BlockCopy(board, 0, baData, 0, board.Length);

			Trie.FindWords(words, baData);

          Console.ReadLine();

		}
	}



        class GFG
        {
            readonly string[] _dictionary;
            int M ,N = 3;
            readonly char[,] _chars;
            private List<string> results = new List<string>();

        public GFG(string[] dict, char[,] board)
            {
                _dictionary = dict;
                _chars = board;
                M = _chars.GetLength(0);
                N = _chars.GetLength(1);
            }

            // A given function to check if a given string 
            // is present in dictionary. The implementation is 
            // naive for simplicity. As per the question 
            // dictionary is given to us. 
            public bool isWord(String str)
            {
                // Linearly search all words 
                return _dictionary.Any(str.Equals);
            }

            // A recursive function to print all words present on boggle 
            public void findWordsUtil(char[,] boggle, bool[,] visited, int i, int j, string str)
            {
                // Mark current cell as visited and 
                // append current character to str 
                visited[i,j] = true;
                str = str + boggle[i,j];

                // If str is present in dictionary, 
                // then print it 
                if (isWord(str))
                    results.Add(str);

                // Traverse 8 adjacent cells of boggle[i,j] 
                for (int row = i - 1; row <= i + 1 && row < M; row++)
                    for (int col = j - 1; col <= j + 1 && col < N; col++)
                        if (row >= 0 && col >= 0 && !visited[row,col])
                             findWordsUtil(boggle, visited, row, col, str);

                // Erase current character from string and 
                // mark visited of current cell as false 
               // str = "" + str[str.Length - 1];
                visited[i,j] = false;
            }

            // Prints all words present in dictionary. 
            public List<string> findWords()
            {
                // Mark all characters as not visited 
                var visited = new bool[M,N];
                // Initialize current string 
                string str = "";

                // Consider every character and look for all words 
                // starting with this character 
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++)
                        findWordsUtil(_chars, visited, i, j, str);

                return results;
            }


        }

        class Trie
        {

		    // Alphabet size 
		    static readonly int SIZE = 26;

		    // trie Node 
		    public class TrieNode
		    {
			    public TrieNode[] Child = new TrieNode[SIZE];

			// isLeaf is true if the node represents 
			// end of a word 
			    public Boolean leaf;

			// Constructor 
			public TrieNode()
			{
				leaf = false;
				for (int i = 0; i < SIZE; i++)
					Child[i] = null;
			}
		}

		// If not present, inserts key into trie 
		// If the key is prefix of trie node, just 
		// marks leaf node 
		static void insert(TrieNode root, String Key)
		{
			int n = Key.Length;
			TrieNode pChild = root;

			for (int i = 0; i < n; i++)
			{
				int index = Key[i] - 'a';

				if (pChild.Child[index] == null)
					pChild.Child[index] = new TrieNode();

				pChild = pChild.Child[index];
			}

			// make last node as leaf node 
			pChild.leaf = true;
		}

		// A recursive function to print all possible valid 
		// words present in array 
		static void searchWord(TrieNode root, Boolean[] Hash, String str)
		{
			// if we found word in trie / dictionary 
			if (root.leaf == true)
				Console.WriteLine(str);

			// traverse all child's of current root 
			for (int K = 0; K < SIZE; K++)
			{
				if (Hash[K] == true && root.Child[K] != null)
				{
					// add current character 
					char c = (char)(K + 'a');

					// Recursively search reaming character 
					// of word in trie 
					searchWord(root.Child[K], Hash, str + c);
				}
			}
		}

		// Prints all words present in dictionary. 
		static void PrintAllWords(char[] Arr, TrieNode root, int n)
		{
			// create a 'has' array that will store all 
			// present character in Arr[] 
			Boolean[] Hash = new Boolean[SIZE];

			for (int i = 0; i < n; i++)
				Hash[Arr[i] - 'a'] = true;

			// tempary node 
			TrieNode pChild = root;

			// string to hold output words 
			String str = "";

			// Traverse all matrix elements. There are only 
			// 26 character possible in char array 
			for (int i = 0; i < SIZE; i++)
			{
				// we start searching for word in dictionary 
				// if we found a character which is child 
				// of Trie root 
				if (Hash[i] == true && pChild.Child[i] != null)
				{
					str = str + (char)(i + 'a');
					searchWord(pChild.Child[i], Hash, str);
					str = "";
				}
			}
		}

		// Driver code 
		public static void FindWords(String[] Dict, char[] arr)
		{
			// Root Node of Trie 
			TrieNode root = new TrieNode();

			// insert all words of dictionary into trie 
			int n = Dict.Length;
			for (int i = 0; i < n; i++)
				insert(root, Dict[i]);

			int N = arr.Length;

			PrintAllWords(arr, root, N);
		}
	}

	/* This code is contributed by PrinciRaj1992 */

}




        
