using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeList<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public void Add(T thing)
    {
        if (!Items.Contains(thing))
            Items.Add(thing);
    }

    public void Remove(T thing)
    {
        if (Items.Contains(thing))
            Items.Remove(thing);
    }

    public bool Contains(T thing)
    {
        return Items.Contains(thing);
    }

    public int Count { get { return Items.Count; } }

    public T GetLastElement()
    {
        return Items[Items.Count - 1];
    }

    public bool IsEmpty()
    {
        return Items.Count == 0;
    }

    public void Clear()
    {
        Items.Clear();
    }

    public void SetList(List<T> list)
    {
        Items.Clear();
        foreach(var e in list)
        {
            Items.Add(e);
        }
    }

    public T GetElementAtIndex(int i)
    {
        return Items[i];
    }

    public List<T>.Enumerator GetEnumerator()
    {
        return Items.GetEnumerator();
    }
}