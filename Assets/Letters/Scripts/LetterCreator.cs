using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCreator : MonoBehaviour {
    // Object that is spawned for each letter
    public GameObject _spawnObject;

    public string _canvasTag;

    private class ChildObject
    {
        public Vector2 Size;
        public Vector2 Offset;
        public Vector2 WholeSize;
        public ChildObject()
        {
            Size = new Vector2();
            Offset = new Vector2();
            WholeSize = new Vector2();
        }
    }

    private class CanvasObject
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
        _childObject.WholeSize.x = x + xOffset;
        _childObject.WholeSize.y = y + yOffset;
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
        //        spawnChildren(shuffleLetters(letters));
        spawnChildren(letters);
    }

    /// <summary>
    /// Shuffle letters in list
    /// </summary>
    /// <param name="letters">List of letters</param>
    /// <returns>List of letters</returns>
    private List<string> shuffleLetters(List<string> letters)
    {
        UtilsList utilsList = new UtilsList();
        return utilsList.SchuffleList<string>(letters);
    }

    private void spawnChildren(List<string> letters)
    {
        CanvasChildPositionHandler positionHandler = new CanvasChildPositionHandler();
        var rowCap = countChildrenCapInEachRow();
        var columnCap = countChildrenCapInEachColumn();
        spawnEachChildren(letters, 4, rowCap, columnCap);

        //Test();
        var x = -1400;

/*        foreach (var i in letters)
        {
            var letterIndex = _letterDictionary[i];
            GameObject newSpawnObject = _spawnObject;
            newSpawnObject.transform.GetComponent<Image>().sprite = _sprites[letterIndex];

            GameObjectContainer objectContainer = new GameObjectContainer(newSpawnObject, x, -200);
//            Debug.Log(objectContainer.GetGameObject().transform.GetComponent<Image>().sprite);
            objectContainers.Add(objectContainer);
            //          SpawnGameObject spawner = new SpawnGameObject();

            //          _spawnGameObject.SpawnGameObjectRelatedToParent(objectContainer, gameObject);

            var instantiate = Instantiate(objectContainer.GetGameObject(), new Vector3(objectContainer.GetLocationX(), objectContainer.GetLocationY(), 0), transform.rotation);
            instantiate.transform.SetParent(gameObject.transform, false);

            x += 400;
        }
        
        CanvasChildPositionHandler positionHandler = new CanvasChildPositionHandler(objectContainers);
        positionHandler.Spawn();
        */
    }

    private void printList(List<string> letters)
    {
        var letterStr = "";
        Debug.Log("=========");
        foreach(var i in letters)
        {
            letterStr += i;
            letterStr += ", ";
        }
        Debug.Log(letterStr);
    }

    private void printDoubleList(List<List<string>> letters)
    {
        foreach(var i in letters)
        {
            var letterStr = "";
            foreach(var j in i)
            {
                letterStr += j;
                letterStr += ", ";
            }
            Debug.Log(letterStr);
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

    private void spawnEachChildren(List<string> letters, int startRow, int maxRowCap, int maxColumnCap)
    {
        List<List<string>> dividedChildren = new List<List<string>>();

        dividedChildren = divideLettersIntoRows(maxRowCap, maxColumnCap, letters);

        spawnAllChildren(dividedChildren, startRow);
    }

    private List<List<string>> divideLettersIntoRows(int maxRowNum, int maxColumnNum, List<string> letters)
    {
        List<List<string>> listLetter = new List<List<string>>();

        if(maxRowNum * maxColumnNum < letters.Count)
            Debug.LogError("Canvas cannot handle " + letters.Count + " number of letters");
        else
        {
            listLetter = splitlist(letters, maxRowNum);
            // printDoubleList(listLetter);
        }

        return listLetter;
    }

    private List<List<string>> splitlist(List<string> letters, int maxSize)
    {
        var list = new List<List<string>>();
        for(int i=0; i<letters.Count; i += maxSize)
        {
            list.Add(letters.GetRange(i, Math.Min(maxSize, letters.Count - i)));
        }
        return list;
    }

    private void spawnAllChildren(List<List<string>> dividedLetters, int startRow)
    {
        // Even number
        if (dividedLetters.Count % 2 == 0)
        {
            spawnSingleRow(dividedLetters[0], _childObject.WholeSize.x/2f, startRow, 0);
        }
        else
        {
            spawnSingleRow(dividedLetters[0], 0f, startRow, 4);
        }
    }

    /// <summary>
    /// Spawn all letters in a single row
    /// </summary>
    /// <param name="lettersRow"></param>
    /// <param name="compareX"></param>
    /// <param name="rowNum"></param>
    /// <param name="indexFrom"></param>
    private void spawnSingleRow(List<string> lettersRow, float x, int rowNum, int index)
    {
        printList(lettersRow);

        if (index < 0)
        {
            Debug.Log("index < 0");
            return;
        }

        if (x + _childObject.Offset.x + _canvas.Offset >= _canvas.Size.x)
        {
            Debug.LogError("The canvas is too small");
        }

        if (lettersRow.Count == 1) {
            Debug.Log("Count == 1");
            return;
        }
        else if (lettersRow.Count - 1 == index) {
            Debug.Log("Left");
            spawnRow(lettersRow, x, index);
            return;
        }
        else if(index == 0) {
            spawnRow(lettersRow, x, index);
            return;
        }

        spawnLetter(lettersRow[index], 0, -100);
        lettersRow.RemoveAt(index);
        List<List<string>> dividedLetters = new List<List<string>>();
        dividedLetters = splitlist(lettersRow, lettersRow.Count / 2);

        printList(dividedLetters[0]);
        printList(dividedLetters[1]);

        spawnRow(dividedLetters[0], createNewXPositionLeft(x), dividedLetters[0].Count - 1);
        spawnRow(dividedLetters[1], createNewXPositionRight(x), 0);

//        spawnSingleRow(dividedLetters[0], createNewXPositionLeft(x), rowNum, dividedLetters[0].Count - 1);
//        spawnSingleRow(dividedLetters[1], createNewXPositionRight(x), rowNum, 0);
    }

    private void spawnRow(List<string> letters, float x, int index)
    {
        spawnLetter(letters[index], x, -100);
        if (letters.Count == 1)
        {
            return;
        }
        else if (letters.Count - 1 == index)
        {
            Debug.Log("letters.Count - 1 == index" + letters[index]);
            letters.RemoveAt(index);
            spawnRow(letters, createNewXPositionLeft(x), letters.Count - 1);
        }
        else if (index == 0)
        {
            letters.RemoveAt(index);
            spawnRow(letters, createNewXPositionRight(x), 0);
        }
    }

    private float createNewXPositionLeft(float x)
    {
        var size = _childObject.Size.x + _childObject.Offset.x;
        x += size;
        x *= (-1);
        return x;
    }

    private float createNewXPositionRight(float x)
    {
        x += _childObject.Size.x + _childObject.Offset.x;
        return x;
    }

    private void spawnLetter(string letter, float x, int y)
    {
        var letterIndex = _letterDictionary[letter];
        GameObject newSpawnObject = _spawnObject;
        newSpawnObject.transform.GetComponent<Image>().sprite = _sprites[letterIndex];
        var instantiate = Instantiate(newSpawnObject, new Vector3(x, -100, 0), transform.rotation);
        instantiate.transform.SetParent(gameObject.transform, false);
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
