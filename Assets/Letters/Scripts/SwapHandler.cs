using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Swaps position of childrens randomly
/// on trigger.
/// </summary>
public class SwapHandler : MonoBehaviour {

    private SwapItems _swap;

	// Use this for initialization
	void Awake () {
        _swap = new SwapItems();
    }

    public void SwapTrigger()
    {
        var children = new List<Transform>();
        children = getChildren();

        UtilsList listHelper = new UtilsList();
        children = listHelper.ShuffleList<Transform>(children);
        _swap.SwapTransformsRandomly(children);
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
