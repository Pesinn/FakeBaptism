using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Swaps position of childrens randomly
/// on trigger.
/// </summary>
public class SwapHandler : MonoBehaviour {
    private class NumberContainer
    {
        public int Number { get; set; }
        public bool isUsed { get; set; }

        public NumberContainer(int number, bool isUsed)
        {
            Number = number;
            this.isUsed = isUsed;
        }
    }

    List<Transform> _children;
    SwapItems swap;

	// Use this for initialization
	void Awake () {
        swap = new SwapItems();
        _children = new List<Transform>();
        _children = getChildren();
    }

    public void SwapTrigger()
    {
        _children = schuffleList(_children);
        swap.SwapTransformsRandomly(_children);
    }

    private List<Transform> schuffleList(List<Transform> oldChildren)
    {
        var capacity = oldChildren.Count;
        List<Transform> newChildren = new List<Transform>();
        List<NumberContainer> numbers = new List<NumberContainer>();
        numbers = createNewNumberContainer(capacity);

        var random = 0;
        while (!allNumbersInNumberContainerUsed(numbers))
        {
            random = Random.Range(0, capacity);

            if (!numbers[random].isUsed)
            {
                newChildren.Add(oldChildren[numbers[random].Number]);
                numbers[random].isUsed = true;
            }
        }

        return newChildren;
    }

    /// <summary>
    /// Create number container with numbers from 0 up to 'capacity'
    /// </summary>
    /// <param name="capacity">One (+1) above highest number in the container</param>
    private List<NumberContainer> createNewNumberContainer(int capacity)
    {
        List<NumberContainer> container = new List<NumberContainer>();
        for(int i=0; i<capacity; i++)
        {
            container.Add(new NumberContainer(i, false));
        }
        return container;
    }

    private bool allNumbersInNumberContainerUsed(List<NumberContainer> numbers)
    {
        foreach(var i in numbers)
        {
            if(i.isUsed == false)
            {
                return false;
            }
        }
        return true;
    }

    private List<Transform> getChildren()
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in transform)
        {
            children.Add(child);
        }
                
        return children;
    }
}
