using System;
using System.Collections.Generic;

class BinaryTree<T> where T : IComparable
{
    public BTnode<T> Root { get; set; }
    public bool IsEmpty
    {
        get
        {
            return Root == null;
        }
    }
    public void Insert(T value)
    {
        if(IsEmpty)
        {
            Root = new BTnode<T>(value);
        }
        else
        {
            Root.Insert(value);
        }
    }

    public void Preorder(BTnode<T> node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }
    }

    public void Inorder(BTnode<T> node)
    {
        if (node != null)
        {
            Inorder(node.Left);
            Console.Write(node.Value + " ");
            Inorder(node.Right);
        }
    }

    public void Postorder(BTnode<T> node)
    {
        if (node != null)
        {
            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Value + " ");
        }
    }

    public void Print()
    {
        if (!IsEmpty)
        {
            Inorder(Root);
        }
    }

    public void Find(T value)
    {
        if(IsEmpty)
        {
            Console.WriteLine("Дерево пусто!");
            return;
        }
        Console.Write("Путь до элемента: ");
        Root.Find(value);
    }

    public void Delete(T value)
    {
        if (IsEmpty)
        {
            Console.WriteLine("Дерево пусто!");
            return;
        }
        if(Root.Value.CompareTo(value) == 0)
        {
            Root = null;
            return;
        }
        Root.Delete(value);
    }

    public void Clear()
    {
        Console.WriteLine("Дерево очищено.");
        Root = null;
    }
}

class BTnode<T> where T : IComparable
{
    public BTnode<T> Left { get; set; }
    public BTnode<T> Right { get; set; }
    public T Value { get; set; }
    public int Counter { get; set; } = 1;

    public BTnode(T value)
    {
        Value = value;
    }

    internal void Insert(T value)
    {
        if (Value.CompareTo(value) < 0)
        {
            if (Right == null)
            {
                Right = new BTnode<T>(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
        else if (Value.CompareTo(value) > 0)
        {
            if (Left == null)
            {
                Left = new BTnode<T>(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else
        {
            Counter++;
        }
    }

    internal void Find(T value)
    {
        if(Value.CompareTo(value) == 0)
        {
            Console.WriteLine(Value);
        }
        else if(Value.CompareTo(value) < 0)
        {
            if (Right == null)
            {
                Console.WriteLine("Данного элемента нет в дереве!");
            }
            else
            {
                Console.Write(Value + " ");
                Right.Find(value);
            }
        }
        else if (Value.CompareTo(value) > 0)
        {
            if (Left == null)
            {
                Console.WriteLine("Данного элемента нет в дереве!");
            }
            else
            {
                Console.Write(Value + " ");
                Left.Find(value);
            }
        }
    }

    internal void Delete(T value)
    {
        if (Value.CompareTo(value) < 0)
        {
            if (Right == null)
            {
                Console.WriteLine("Данного элемента нет в дереве!");
            }
            else
            {
                if(Right.Value.CompareTo(value) == 0)
                {
                    Right = null;
                }
                else
                {
                    Right.Delete(value);
                }
            }
        }
        else if (Value.CompareTo(value) > 0)
        {
            if (Left == null)
            {
                Console.WriteLine("Данного элемента нет в дереве!");
            }
            else
            {
                if (Left.Value.CompareTo(value) == 0)
                {
                    Left = null;
                }
                else
                {
                    Left.Delete(value);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        BinaryTree<int> tree = new();
        tree.Insert(0);
        tree.Insert(-1);
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(5);
        tree.Insert(4);
        tree.Preorder(tree.Root);
        Console.WriteLine();
        tree.Inorder(tree.Root);
        Console.WriteLine();
        tree.Postorder(tree.Root);
        Console.WriteLine();
        tree.Print();
        Console.WriteLine();
        tree.Find(4);
        tree.Delete(5);
        tree.Find(5);
        tree.Find(4);
        tree.Clear();
        tree.Print();
    }
}
