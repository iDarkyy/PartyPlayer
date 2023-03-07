using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PartyPlayer.Utils;

public delegate void QueueItemAddedHandler(object sender, QueueItemAddedArgs args);

public delegate void QueueItemRemovedHandler(object sender, QueueItemRemovedArgs args);

public delegate void QueueItemMovedHandler(object sender, QueueItemMovedArgs args);

public delegate void QueueUpdatedHandler(object sender, QueueUpdatedArgs args);

public class ListQueue<T> : IEnumerable<T>
{
    private readonly BindingList<T> _list = new();

    public int Count => _list.Count;

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public event QueueItemAddedHandler QueueItemAdded;
    public event QueueItemRemovedHandler QueueItemRemoved;
    public event QueueItemMovedHandler QueueItemMoved;
    public event QueueUpdatedHandler QueueUpdated;

    public IList GetList()
    {
        return _list;
    }


    /**
         * Add an item to the queue
         */
    public void Enqueue(T item)
    {
        _list.Add(item);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemAdded?.Invoke(this, new QueueItemAddedArgs { Index = _list.Count - 1 });
    }

    /**
         * Add an item to the first place in the queue
         */
    public void EnqueueNext(T item)
    {
        _list.Insert(0, item);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemAdded?.Invoke(this, new QueueItemAddedArgs { Index = 0 });
    }

    /**
         * Add an item to the specified place in the queue
         */
    public void EnqueueAt(int index, T item)
    {
        _list.Insert(index, item);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemAdded?.Invoke(this, new QueueItemAddedArgs { Index = index });
    }

    /**
         * Move an item to the specific place in the queue
         */
    public void Move(int oldIndex, int newIndex)
    {
        var old = _list[oldIndex];
        _list.RemoveAt(oldIndex);
        _list.Insert(newIndex, old);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemMoved?.Invoke(this, new QueueItemMovedArgs { OldIndex = oldIndex, NewIndex = newIndex });
    }

    /**
         * Dequeue the first item in the queue
         */
    public T Dequeue()
    {
        if (_list.Count == 0) throw new QueueEmptyException();
        var item = _list[0];
        _list.RemoveAt(0);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemRemoved?.Invoke(this, new QueueItemRemovedArgs { Index = 0 });

        return item;
    }

    public T Dequeue(int index)
    {
        var item = _list[index];
        _list.RemoveAt(index);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemRemoved?.Invoke(this, new QueueItemRemovedArgs { Index = index });

        return item;
    }

    /**
         * Take a look at the first item in the queue
         */
    public T Peek()
    {
        if (_list.Count == 0) throw new QueueEmptyException();

        return _list[0];
    }

    /**
         * Take a look at the item at the specified place in the queue
         */
    public T Peek(int index)
    {
        return _list[index];
    }

    public void Remove(T item)
    {
        _list.Remove(item);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemRemoved?.Invoke(this, new QueueItemRemovedArgs { Index = -1 });
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
        QueueUpdated?.Invoke(this, new QueueUpdatedArgs());
        QueueItemRemoved?.Invoke(this, new QueueItemRemovedArgs { Index = index });
    }

    public IEnumerable<T> AsEnumerable()
    {
        return _list.AsEnumerable();
    }

    public class QueueEmptyException : Exception
    {
    }

    public object this[int eIndex] => _list.ElementAt(eIndex);
}

public class QueueItemAddedArgs : EventArgs
{
    public int Index;
}

public class QueueItemRemovedArgs : EventArgs
{
    public int Index;
}

public class QueueItemMovedArgs : EventArgs
{
    public int OldIndex, NewIndex;
}

public class QueueUpdatedArgs : EventArgs
{
}