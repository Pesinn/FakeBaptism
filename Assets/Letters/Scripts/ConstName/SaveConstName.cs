using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveConstName : MonoBehaviour {
    private StoreHandler _storeHandler;
	// Use this for initialization
	void Start () {
        _storeHandler = new StoreHandler();

        _storeHandler.SaveName("PEZ MAN");

        SceneManager.LoadScene(1);
    }
}
