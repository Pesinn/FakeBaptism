using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCharm : MonoBehaviour {

    private Image _buttonImage;

    // Use this for initialization
    void Start () {
        _buttonImage = gameObject.GetComponent<Image>();
	}
	
    /// <summary>
    /// ButtonChanges is executed each time
    /// a letter is choosen from the pick
    /// list.
    /// </summary>
    /// <param name="count">Counter of how many
    /// letters have been picked</param>
    public void ButtonChanges(int count)
    {
        if (count <= 0)
        {
            gameObject.GetComponent<ButtonController>().SetUnActive();
            setUnActiveColor();
        }
        else
        {
            gameObject.GetComponent<ButtonController>().SetActive();
            setActiveColor();
        }
    }

    private void setUnActiveColor()
    {
        _buttonImage.color = new Color(0, 0, 0, 1f);
    }

    private void setActiveColor()
    {
        _buttonImage.color = new Color(1f, 1f, 1f, 1f);
    }
}
