using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {
    public string LatestParentPath { get; set; }

    void Start()
    {
    }    

    public void SetLatestParent(string LatestParentPath)
    {
        this.LatestParentPath = LatestParentPath;
    }

    public string GetLetter()
    {
        return this.LatestParentPath;
    }
}
