using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Swaps position of childrens randomly
/// on trigger.
/// </summary>
public class SwapHandler : MonoBehaviour {

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
        UtilsList<Transform> listHelper = new UtilsList<Transform>();
        _children = listHelper.SchuffleList(_children);
        swap.SwapTransformsRandomly(_children);
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
