using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList
{
    private class Node
    {
        public int Value { get; set; }
        public Node? Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }

    private Node? head;
    private Node? tail;

    /// <summary>
    /// Adds a new node at the beginning of the linked list.
    /// </summary>
    /// <param name="value">The value to add.</param>
    public void InsertHead(int value)
    {
        var newNode = new Node(value);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
    }

    /// <summary>
    /// Adds a new node at the end of the linked list.
    /// </summary>
    /// <param name="value">The value to add.</param>
    public void InsertTail(int value)
    {
        var newNode = new Node(value);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    /// <summary>
    /// Removes the first node from the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (head == null) return;
        head = head.Next;
        if (head == null) tail = null;
    }

    /// <summary>
    /// Removes the last node from the linked list.
    /// </summary>
    public void RemoveTail()
{
    if (tail == null) return;
    if (head == tail)
    {
        head = tail = null;
        return;
    }

    var current = head;
    while (current.Next != tail)
    {
        current = current.Next;
    }

    current.Next = null;
    tail = current;  

    if (head == tail) { 
        head = null;
    }
}
    /// <summary>
    /// Searches for the first node containing the specified value and removes it.
    /// </summary>
    /// <param name="value">The value to search for and remove.</param>
    public void Remove(int value)
{
    if (head == null) return;
    if (head.Value == value)
    {
        RemoveHead();
        return;
    }

    var current = head;
    while (current.Next != null) // Check only for null here
    {
        if (current.Next.Value == value)  // Value check is inside
        {
            if (current.Next == tail)
            {
                RemoveTail();
            }
            else
            {
                current.Next = current.Next.Next;
            }
            return; // Important: Exit after removing
        }
        current = current.Next;
    }
}

    /// <summary>
    /// Replaces all nodes with the specified old value with the new value.
    /// </summary>
    /// <param name="oldValue">The value to search for and replace.</param>
    /// <param name="newValue">The new value to set in matching nodes.</param>
    public void Replace(int oldValue, int newValue)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value == oldValue)
            {
                current.Value = newValue;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Provides an enumerator to iterate through the linked list in forward order.
    /// </summary>
    /// <returns>An enumerator for the linked list.</returns>
    public IEnumerable<int> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <summary>
    /// Provides an enumerator to iterate through the linked list in reverse order.
    /// </summary>
    /// <returns>An enumerator for the linked list in reverse order.</returns>
    public IEnumerable<int> Reverse()
    {
        var stack = new Stack<int>();
        var current = head;
        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Next;
        }
        while (stack.Count > 0)
        {
            yield return stack.Pop();
        }
    }

    /// <summary>
    /// Checks if both head and tail are null (i.e., the list is empty).
    /// </summary>
    /// <returns>True if both head and tail are null; otherwise, false.</returns>
    public bool HeadAndTailAreNull()
    {
        return head == null && tail == null;
    }

    /// <summary>
    /// Checks if both head and tail are not null (i.e., the list is not empty).
    /// </summary>
    /// <returns>True if both head and tail are not null; otherwise, false.</returns>
    public bool HeadAndTailAreNotNull()
    {
        return head != null && tail != null;
    }

    /// <summary>
    /// Inserts a new node with the specified value after the first node containing the target value.
    /// </summary>
    /// <param name="targetValue">The value to search for.</param>
    /// <param name="newValue">The value to insert.</param>
    public void InsertAfter(int targetValue, int newValue)
    {
        var current = head;
        while (current != null)
        {
            if (current.Value == targetValue)
            {
                var newNode = new Node(newValue);
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == tail)
                {
                    tail = newNode;
                }
                return;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// Converts the linked list to a string representation.
    /// </summary>
    /// <returns>A string representation of the linked list.</returns>
    public override string ToString()
    {
        return $"<LinkedList>{string.Join(", ", this.GetEnumerator())}"; // Corrected ToString format
    }
}

public static class IEnumerableExtensions
{
    /// <summary>
    /// Converts an IEnumerable<int> to a string representation.
    /// </summary>
    /// <param name="enumerable">The IEnumerable to convert.</param>
    /// <returns>A string representation of the IEnumerable.</returns>
    public static string AsString(this IEnumerable<int> enumerable)
    {
        return $"<IEnumerable>{string.Join(", ", enumerable)}"; // Corrected AsString format
    }
}