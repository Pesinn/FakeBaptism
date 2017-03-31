using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsList {

    private class ObjectContainer
    {
        public int Number { get; set; }
        public bool isUsed { get; set; }

        public ObjectContainer(int number, bool isUsed)
        {
            Number = number;
            this.isUsed = isUsed;
        }
    }

    /// <summary>
    /// Shuffle list randomly
    /// </summary>
    /// <param name="list">List to shuffle</param>
    /// <returns>Shuffled list</returns>
    public List<T> SchuffleList<T>(List<T> list) where T : class
    {
        var capacity = list.Count;
        List<T> newChildren = new List<T>();
        List<ObjectContainer> obj = new List<ObjectContainer>();
        obj = createNewObjectContainer(capacity);

        var random = 0;
        while (!allNumbersInObjectContainerUsed(obj))
        {
            random = Random.Range(0, capacity);

            if (!obj[random].isUsed)
            {
                newChildren.Add(list[obj[random].Number]);
                obj[random].isUsed = true;
            }
        }

        return newChildren;
    }

    /// <summary>
    /// Create number container with numbers from 0 up to 'capacity'
    /// </summary>
    /// <param name="capacity">One (+1) above highest number in the container</param>
    private List<ObjectContainer> createNewObjectContainer(int capacity)
    {
        List<ObjectContainer> container = new List<ObjectContainer>();
        for (int i = 0; i < capacity; i++)
        {
            container.Add(new ObjectContainer(i, false));
        }
        return container;
    }

    private bool allNumbersInObjectContainerUsed(List<ObjectContainer> numbers)
    {
        foreach (var i in numbers)
        {
            if (i.isUsed == false)
            {
                return false;
            }
        }
        return true;
    }
}
