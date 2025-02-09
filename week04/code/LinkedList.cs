

public class LinkedList
{
    private class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node Head { get; set; }
    private Node Tail { get; set; }

    public void InsertHead(int value)
    {
        var newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
    }

    public void InsertTail(int value)
    {
        var newNode = new Node(value);
        if (Tail == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }
    }

    public void InsertAfter(int existingValue, int newValue)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Value == existingValue)
            {
                var newNode = new Node(newValue);
                newNode.Next = current.Next;
                current.Next = newNode;
                if (current == Tail)
                {
                    Tail = newNode;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveTail()
    {
        if (Head == null) return;

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            return;
        }

        var current = Head;
        while (current.Next != Tail)
        {
            current = current.Next;
        }
        current.Next = null;
        Tail = current;
    }

    public void Remove(int value)
    {
        if (Head == null) return;

        if (Head.Value == value)
        {
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            return;
        }

        var current = Head;
        while (current.Next != null)
        {
            if (current.Next.Value == value)
            {
                current.Next = current.Next.Next;
                if (current.Next == null)
                {
                    Tail = current;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        var current = Head;
        while (current != null)
        {
            if (current.Value == oldValue)
            {
                current.Value = newValue;
            }
            current = current.Next;
        }
    }

    public IEnumerable<int> Reverse()
    {
        var values = new List<int>();
        var current = Head;
        while (current != null)
        {
            values.Add(current.Value);
            current = current.Next;
        }
        values.Reverse();
        return values;
    }

    public bool HeadAndTailAreNull() => Head == null && Tail == null;
    public bool HeadAndTailAreNotNull() => Head != null && Tail != null;

    public override string ToString()
    {
        var values = new List<string>();
        var current = Head;
        while (current != null)
        {
            values.Add(current.Value.ToString());
            current = current.Next;
        }
        return $"<LinkedList>{{{string.Join(", ", values)}}}";
    }
}

public static class EnumerableExtensions
{
    public static string AsString(this IEnumerable<int> source)
    {
        return $"<IEnumerable>{{{string.Join(", ", source)}}}";
    }
}