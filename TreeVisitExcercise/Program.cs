
// Non-recursive C# program for inorder traversal 
using System; 
using System.Collections.Generic; 


public class Node
{
    public int data;
    public Node left, right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

/* Class to print the inorder traversal */
public class BinaryTree
{
    public Node _root;
    public virtual void inorder()
    {
        if (_root == null)
        {
            return;
        }

        Stack<Node> s = new Stack<Node>();
        Node curr = _root;

        // traverse the tree 
        while (curr != null || s.Count > 0)
        {
            /* Reach the left most Node of the 
            curr Node */
            while (curr != null)
            {
                /* place pointer to a tree node on 
                the stack before traversing 
                the node's left subtree */
                s.Push(curr);
                curr = curr.left;
            }

            /* Current must be NULL at this point */
            curr = s.Pop();

            Console.Write(curr.data + " ");

            /* we have visited the node and its 
            left subtree. Now, it's right 
            subtree's turn */
            curr = curr.right;
        }
    }

    public void RecursiveInOrder(Node root)
    {
        if (root==null)
            return;
        RecursiveInOrder(root.left);
        Console.WriteLine(root.data);
        RecursiveInOrder(root.right);


    }
    public static void Main(string[] args)
    {

        /* creating a binary tree and entering 
        the nodes */
        BinaryTree tree = new BinaryTree();
        tree._root = new Node(1);
        tree._root.left = new Node(2);
        tree._root.right = new Node(3);
        tree._root.left.left = new Node(4);
        tree._root.left.right = new Node(5);

        Console.WriteLine("---------No Recursive ------");

        tree.inorder();

        Console.WriteLine("---------Recursive ------");
        tree.RecursiveInOrder(tree._root);
    }
}

