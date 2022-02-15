using System;
using System.Collections.Generic;
class Node<T>
{
    public T Value { get; set; }
    public Node<T> Prev { get; set; }
    public Node(T value, Node<T> node)
    {
        (Value, Prev) = (value, node);
    }
}
class MyStack<T>
{
    private Node<T> Tail { get; set; }
    private int Size { get; set; }
    public void Push(T value)
    {
        Node<T> node = new(value, Tail);
        Tail = node;
        Size++;
    }
    public T Pop()
    {
        var value = Tail.Value;
        Tail = Tail.Prev;
        Size--;
        return value;
    }
    public T Peek()
    {
        if(!IsEmpty())
        {
            return Tail.Value;
        }
        else
        {
            throw new Exception("Stack is empty!");
        }
    }
    public int StackSize()
    {
        return Size;
    }
    public bool IsEmpty()
    {
        return Size == 0;
    }
    public override string ToString()
    {
        return $"Stack size: {StackSize()}, last element = {Peek()}";
    }
}
class Program
{
    static void Main()
    {
        try
        {
            MyStack<int> stack = new();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack);
            stack.Pop();
            stack.Pop();
            Console.WriteLine(stack);
            stack.Pop();
            Console.WriteLine(stack);
            stack.Pop();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
