using System;
using System.Net.Http.Headers;
namespace Avltree
{
    public class Avltree
    {
        private class Node
        {
           public int value;
           public Node left;
           public  Node right;
           public int hight;
            public int balance;
            public Node(int val)
            {
                this.value = val;
            }
            public Node()
            {
                
            }
        }
        Node root;
        public void insert(int val)
        {
         root=insert(root, val);
        }
        private Node insert(Node node,int val)
        {
            if(node==null)
            {
               return  new Node(val);
            }
            if(node.value<val)
            {
                node.left=insert(node.left,val);
            }
            else
            {
               node.right=insert(node.right,val);
            }
            sethight(node);
           return balance(node);
        }
        public void print()
        {
            print(root);
        }
        private void print(Node node)
        {
            if(node==null)
            {
                return;
            }
            Console.WriteLine(node.value);
            print(node.left);
            print(node.right);
        }
        public bool isbalance()
        {
            return isbalance(root);
        }
        private bool isbalance(Node node)
        {
            if(node==null)
            {
                return true;
            }
            if(isleaftheavy(node)||isrightheavy(node))
            {
                return false;
            }
            return isbalance(node.left)&&isbalance(node.right);
        }
        private Node balance(Node node)
        {
            if (isleaftheavy(node))
            { 
                if (balancefactor(node.left) < 0)
                {
                  node.left =rotateleft(node.left);
                }
                return rotateright(node);
            }
            else if(isrightheavy(node))
            {
                if (balancefactor(node.right) > 0)
                {
                  node.right= rotateright(node.right);
                }
                  return rotateleft(node);
            }
            return node;
        }
        private Node rotateleft(Node node)
        {
            var newnode = node.right;
            node.right=newnode.left;
            newnode.left = node;
            sethight(node);
            sethight(newnode);
            return newnode; 
        }
        private Node rotateright(Node node)
        {
            var newnode = node.left;
            node.left=newnode.right;
            newnode.right = node;
            sethight(node);
            sethight(newnode);
            return newnode;
        }
        private void sethight(Node node)
        {
            node.hight=Math.Max(Hight(node.left),Hight(node.right))+1;
        }
        private bool isleaftheavy(Node node)
        {
            return balancefactor(node)>1;
        }
        private bool isrightheavy(Node node)
        {
            return balancefactor(node) < -1;
        }
        private int balancefactor(Node node)
        {
            return (node == null) ? 0 : Hight(node.left) - Hight(node.right); 
        }
        private int Hight(Node node)
        {
            return (node == null) ? -1 : node.hight;
        }
    }
   public class Program
    {
        static void Main()
        {
            Avltree avltree = new Avltree();
             Console.WriteLine(avltree.isbalance());
            avltree.insert(30);
            avltree.insert(20);
            avltree.insert(10);
            avltree.print();
            Console.WriteLine(avltree.isbalance());
        }
    }
}