using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterImageColor : MonoBehaviour {
    private Image _image;

    private Color _defaultColor;
    private Color _successColor;

    void Start () {
        setColors();

        _image = gameObject.GetComponent<Image>();
        _image.color = _defaultColor;
    }

    public void SetLetterSuccess()
    {
        _image.color = _successColor;
    }
	
    private void setColors()
    {
        _defaultColor = new Color(255, 255, 0, 250);
        _successColor = new Color(0, 255, 0, 250);
    }
}
