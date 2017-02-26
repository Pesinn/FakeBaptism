using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour {

    private SwapHandler _swapHandler;

	// Use this for initialization
	void Start () {
        _swapHandler = GameObject.FindGameObjectWithTag("Letters").GetComponent<SwapHandler>();
        _swapHandler.SwapTrigger();
    }
}
