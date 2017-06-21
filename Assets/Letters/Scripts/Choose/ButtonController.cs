using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Choose;
public class ButtonController : MonoBehaviour {

    private bool isActive;

    void Start()
    {
        isActive = false;
    }

    public void SetActive()
    {
        isActive = true;
    }

    public void SetUnActive()
    {
        isActive = false;
    }

    public void OnClick()
    {
        if(isActive)
        {
            // Save choosen name to storage
            GameObject.Find("/Canvas/Panel/Choosen").GetComponent<NameValidator>().SaveNewName();

            SceneManager.LoadScene(1);
        }
    }
}
