using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCreator : MonoBehaviour {
    // Object that is spawned for each letter
    public GameObject _spawnObject;

    public string _canvasTag;

    public class ChildObject
    {
        public Vector2 Size;
        public Vector2 Offset;

        public ChildObject()
        {
            Size = new Vector2();
            Offset = new Vector2();
        }
    }

    public class CanvasObject
    {
        public Vector2 Size;
        public Vector2 BoardSize;
        public float Offset;

        public CanvasObject()
        {
            Size = new Vector2();
            BoardSize = new Vector2();
        }
    }

    // Size of each object that contain letter
    // Each object should be on same size
    private ChildObject _childObject;

    private CanvasObject _canvas;

    // List of sprites in alpabetic order, where index 0 is A and last index is Z
    public List<Sprite> _sprites;

    // Contains all letters that can be displayed on screen
    // We want to be able to show all letters in the English alphabet
    private Dictionary<string, int> _letterDictionary;
    
    void Awake () {
        createLetterDictionary();
        getPropertiesFromSpawnObject();
        getLevelSizeLimits();
    }

    /// <summary>
    /// Calculate size of each child object
    /// </summary>
    private void getPropertiesFromSpawnObject()
    {
        RectTransform rectTransform = _spawnObject.GetComponent<RectTransform>();

        var x = rectTransform.rect.width* rectTransform.localScale.x;
        var y = rectTransform.rect.height * rectTransform.localScale.y;

        var xOffset = x / 4f;
        var yOffset = x / 4f;

        _childObject = new ChildObject();
        _childObject.Size.x = x;
        _childObject.Size.y = y;
        _childObject.Offset.x = xOffset;
        _childObject.Offset.y = yOffset;
    }

    /// <summary>
    /// Calculate size of Canvas parent. Child objects should never have higher
    /// values than canvas size.
    /// </summary>
    private void getLevelSizeLimits()
    {
        _canvas = new CanvasObject();
        RectTransform rectTransform = GameObject.FindGameObjectWithTag(_canvasTag).GetComponent<RectTransform>();
        _canvas.Size.x = rectTransform.rect.width;
        _canvas.Size.y = rectTransform.rect.height;
        _canvas.Offset = 20f;
        _canvas.BoardSize.x = _canvas.Size.x - _canvas.Offset;
        _canvas.BoardSize.y = _canvas.Size.y - _canvas.Offset;
    }

    public void SpawnLetters(List<string> letters)
    {
        spawnLetters(letters);
    }

    private void spawnLetters(List<string> letters)
    {
        countChildrenCapInEachRow();
        countChildrenCapInEachColumn();
        var x = -200;
        GameObject newSpawnObject;
        foreach (var i in letters)
        {
            Debug.Log(i);
            var letterIndex = _letterDictionary[i];
            newSpawnObject = _spawnObject;
            newSpawnObject.transform.GetComponent<Image>().sprite = _sprites[letterIndex];
            var instantiate = Instantiate(newSpawnObject, new Vector3(0, 0, 0), transform.rotation);
            
            instantiate.transform.SetParent(gameObject.transform, false);
            x += 400;
        }
    }

    private int countChildrenCapInEachRow()
    {
        return countChildrenCap(_childObject.Size.x, _childObject.Offset.x, _canvas.BoardSize.x);
    }

    private int countChildrenCapInEachColumn()
    {
        return countChildrenCap(_childObject.Size.y, _childObject.Offset.y, _canvas.BoardSize.y);
    }

    /// <summary>
    /// Check how many children can be fit input parent object.
    /// </summary>
    /// <param name="childSize">Size of each child object</param>
    /// <param name="childOffset">Offset for each child</param>
    /// <param name="parentSize">Size of the parent</param>
    /// <returns>Children count</returns>
    private int countChildrenCap(float childSize, float childOffset, float parentSize)
    {
        var firstChildSpace = childSize + childOffset * 2;

        var otherChildSpace = childSize + childOffset;

        return countChildObjectCap(firstChildSpace, otherChildSpace, parentSize);
    }

    /// <summary>
    /// Check how many children can be fit into parent object.
    /// </summary>
    /// <param name="firstObject">Size of first object spawned on the board</param>
    /// <param name="otherObjects">Size of all other objects spawned on the board</param>
    /// <param name="world">Size of the parent which the child objects cannot reach higher values</param>
    /// <returns>Children count</returns>
    private int countChildObjectCap(float firstChildSize, float otherChildrenSize, float parentSize)
    {
        int counter = 0;

        // At least single object can fit
        if (parentSize > firstChildSize)
        {
            ++counter;

            // Leave out allocated part of the board and calculate for the rest
            var boardSizeLeftover = parentSize - firstChildSize;
            return counter + (int)(boardSizeLeftover / otherChildrenSize);
        }

        return counter;
    }


    private void createLetterDictionary()
    {
        _letterDictionary = new Dictionary<string, int>();
        _letterDictionary.Add("A", 0);
        _letterDictionary.Add("B", 1);
        _letterDictionary.Add("C", 2);
        _letterDictionary.Add("D", 3);
        _letterDictionary.Add("E", 4);
        _letterDictionary.Add("F", 5);
        _letterDictionary.Add("G", 6);
        _letterDictionary.Add("H", 7);
        _letterDictionary.Add("I", 8);
        _letterDictionary.Add("J", 9);
        _letterDictionary.Add("K", 10);
        _letterDictionary.Add("L", 11);
        _letterDictionary.Add("M", 12);
        _letterDictionary.Add("N", 13);
        _letterDictionary.Add("O", 14);
        _letterDictionary.Add("P", 15);
        _letterDictionary.Add("Q", 16);
        _letterDictionary.Add("R", 17);
        _letterDictionary.Add("S", 18);
        _letterDictionary.Add("T", 19);
        _letterDictionary.Add("U", 20);
        _letterDictionary.Add("V", 21);
        _letterDictionary.Add("X", 22);
        _letterDictionary.Add("Y", 23);
        _letterDictionary.Add("Z", 24);
    }



}
