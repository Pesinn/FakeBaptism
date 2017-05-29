using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to swap items in list
/// </summary>
public class SwapItems {
    public void SwapTransformsRandomly(List<Transform> listToSwap)
    {
        for (var i = 0; i < listToSwap.Count; i++)
        {
            var random = Random.Range(0, listToSwap.Count);
            var tempPos = listToSwap[i].localPosition;
            listToSwap[i].localPosition = new Vector3(listToSwap[random].localPosition.x, listToSwap[random].localPosition.y, 0);
            listToSwap[random].localPosition = tempPos;
        }
    }
}
