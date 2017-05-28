using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterCreator : MonoBehaviour {
    // Object that is spawned for each letter
    public GameObject _spawnObject;

    public string _canvasTag;

    private CoordCalculator _coordCalculator;

    // Size of each object that contain letter
    // Each object should be on same size
    private ChildObject _childObject;

    private CanvasObject _canvas;

    // List of sprites in alpabetic order, where index 0 is A and last index is Z
    public List<Sprite> _sprites;

    private ObjectInfo _canvasInfo;

    private ObjectInfo _childInfo;

    // Contains all letters that can be displayed on screen
    // We want to be able to show all letters in the English alphabet
    private Dictionary<string, int> _letterDictionary;
    
    private float _spawnTimer;

    private float _spawnTimerConst;

    void Awake () {
        createLetterDictionary();
        getPropertiesFromSpawnObject();
        getLevelSizeLimits();

        _spawnTimer = 0.0f;
        _spawnTimerConst = 0.0f;
        _coordCalculator = new CoordCalculator(_canvasInfo, _childInfo);
    }

    public void SpawnLetters(List<string> letters, int startRowIndex=0, float timer=0.02f)
    {
        _spawnTimerConst = timer;
        spawnChildren(letters, startRowIndex);
    }

    public int GetMaximumLettersCount()
    {
        return _coordCalculator.CountChildrenCapInEachColumn() * _coordCalculator.CountChildrenCapInEachRow();
    }

    /// <summary>
    /// Calculate size of each child object
    /// </summary>
    private void getPropertiesFromSpawnObject()
    {
        RectTransform rectTransform = _spawnObject.GetComponent<RectTransform>();

        var x = rectTransform.rect.width * rectTransform.localScale.x;
        var y = rectTransform.rect.height * rectTransform.localScale.y;

        _childInfo = new ObjectInfo(rectTransform.rect.width, rectTransform.rect.height,
            new Vector2(rectTransform.localScale.x, rectTransform.localScale.y));

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

        _canvasInfo = new ObjectInfo(rectTransform.rect.width, rectTransform.rect.height,
           new Vector2(1, 1));

        _canvas.Size.x = rectTransform.rect.width;
        _canvas.Size.y = rectTransform.rect.height;
        _canvas.Offset = 20f;
        _canvas.BoardSize.x = _canvas.Size.x - _canvas.Offset;
        _canvas.BoardSize.y = _canvas.Size.y - _canvas.Offset;
    }

    private float getEvenRowCoords(int index)
    {
        return _coordCalculator.GetEvenRowCoords(index);
    }

    private float getOddRowCoords(int index)
    {
        return _coordCalculator.GetOddRowCoords(index);
    }

    private float getOddColumnCoords(int index)
    {
        return _coordCalculator.GetOddColumnCoords(index);
    }

    private float getEvenColumnCoords(int index)
    {
        return _coordCalculator.GetEvenColumnCoords(index);
    }

    /// <summary>
    /// Shuffle letters in list
    /// </summary>
    /// <param name="letters">List of letters</param>
    /// <returns>List of letters</returns>
    private List<string> shuffleLetters(List<string> letters)
    {
        UtilsList utilsList = new UtilsList();
        return utilsList.ShuffleList<string>(letters);
    }

    private void spawnChildren(List<string> letters, int startRowIndex)
    {
        var rowCap = _coordCalculator.CountChildrenCapInEachRow();
        var columnCap = _coordCalculator.CountChildrenCapInEachColumn();
        spawnEachChildren(letters, startRowIndex, rowCap, columnCap);
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
            listLetter = splitlist(letters, maxRowNum);

        return listLetter;
    }

    private List<List<string>> splitlist(List<string> letters, int maxSize)
    {
        var list = new List<List<string>>();

        for(int i=0; i<letters.Count; i += maxSize)
            list.Add(letters.GetRange(i, Math.Min(maxSize, letters.Count - i)));

        return list;
    }

    /// <summary>
    /// Goes through each row and each column, then spawn
    /// each letter.
    /// </summary>
    /// <param name="dividedLetters">Double letters list, every list contains each row</param>
    /// <param name="startRow">Row to start in Y coords</param>
    private void spawnAllChildren(List<List<string>> dividedLetters, int startRow)
    {
        var count = startRow;
        var yCoord = 0.0f;
        foreach (var row in dividedLetters)
        {
            if (isEvenNumber(_coordCalculator.CountChildrenCapInEachColumn()))
                yCoord = _coordCalculator.GetEvenColumnCoords(count);
            else
                yCoord = _coordCalculator.GetOddColumnCoords(count);

            // If count has reach the limit of 
            if (yCoord == float.MaxValue)
            {
                count = 0;
                yCoord = _coordCalculator.GetOddColumnCoords(count);
            }

            spawnSingleRow(row, yCoord);
            
            ++count;
        }
    }

    private bool isEvenNumber(float number)
    {
        return number % 2 == 0 ? true : false;
    }

    /// <summary>
    /// Spawn all letters in a single row
    /// </summary>
    /// <param name="lettersRow"></param>
    /// <param name="compareX"></param>
    /// <param name="rowNum"></param>
    /// <param name="indexFrom"></param>
    private void spawnSingleRow(List<string> lettersRow, float yPos)
    {
        var size = lettersRow.Count;
 
        // TODO make some check if cancas size is big enough

        // When only single letter is in the list, spawn it and finish
        if (size == 1)
        {
            spawnLetter(lettersRow[0], 0, yPos);
            return;
        }

        if (size % 2 == 0)
            spawnEvenRow(lettersRow, yPos);
        else
            spawnOddRow(lettersRow, yPos);
    }

    /// <summary>
    /// Spawning even row where lettersRow contains at
    /// least two letters
    /// </summary>
    /// <param name="lettersRow"></param>
    private void spawnEvenRow(List<string> lettersRow, float yPos)
    {
        var midIndex = Convert.ToInt32(lettersRow.Count / 2f);
        
        var leftIndex = midIndex - 1;
        var rightIndex = midIndex;

        spawnRowPart(lettersRow, leftIndex, rightIndex, yPos, true);
    }

    /// <summary>
    /// Spawning odd row where lettersRow contains at least
    /// three letters
    /// </summary>
    /// <param name="lettersRow">List of letters to spawn</param>
    /// <param name="index"></param>
    private void spawnOddRow(List<string> lettersRow, float yPos)
    {
        var midIndex  = Convert.ToInt32(Math.Floor(lettersRow.Count / 2f));

        var coordIndex = 0;

        spawnLetter(lettersRow[midIndex], getOddRowCoords(coordIndex), yPos);

        var leftIndex = midIndex - 1;
        var rightIndex = midIndex + 1;

        spawnRowPart(lettersRow, leftIndex, rightIndex, yPos, false);
    }

    private void spawnRowPart(List<string> letters, int leftIndex, int rightIndex, float yPos, bool isEven)
    {
        var firstCoordIndex = 0;
        var secondCoordIndex = 0;

        if (isEven) {
            firstCoordIndex = 0;
            secondCoordIndex = 1;
        }
        else {
            firstCoordIndex = 1;
            secondCoordIndex = 2;
        }

        spawnLeftPart(letters, firstCoordIndex, leftIndex, yPos, isEven);
        spawnRightPart(letters, secondCoordIndex, rightIndex, yPos, isEven);
    }

    private void spawnRightPart(List<string> letters, int coordIndex, int xIndex, float yPos, bool isEven)
    {
        if (letters.Count <= xIndex || xIndex < 0)
            return;

        if (isEven)
            spawnLetter(letters[xIndex], getEvenRowCoords(coordIndex), yPos);
        else
            spawnLetter(letters[xIndex], getOddRowCoords(coordIndex), yPos);

        coordIndex += 2;

        spawnRightPart(letters, coordIndex, ++xIndex, yPos, isEven);
    }

    private void spawnLeftPart(List<string> letters, int coordIndex, int xIndex, float yPos, bool isEven)
    {
        if (0 > xIndex || letters.Count <= xIndex)
            return;

        if (isEven)
            spawnLetter(letters[xIndex], getEvenRowCoords(coordIndex), yPos);
        else {
            var oddRowCoords = getOddRowCoords(coordIndex);
            spawnLetter(letters[xIndex], oddRowCoords, yPos);
        }
        coordIndex += 2;

        spawnLeftPart(letters, coordIndex, --xIndex, yPos, isEven);
    }

    private void spawnOddLetterRow(List<string> letters, int yIndex)
    {
        if (letters.Count == 1) {
            spawnLetter(letters[0], _coordCalculator.GetOddRowCoords(0), _coordCalculator.GetOddColumnCoords(yIndex));
            return;
        }

        var midIndex = Convert.ToInt32(letters.Count / 2f);

        spawnLetter(letters[midIndex], _coordCalculator.GetOddRowCoords(midIndex), _coordCalculator.GetOddColumnCoords(yIndex));
        
        var indexLeft = midIndex - 1;
        var indexRight = midIndex + 1;

        // Only iterate once over letters list
        while (indexLeft >= 0.0f || indexRight < letters.Count)
        {
            spawnLetter(letters[indexLeft], _coordCalculator.GetOddRowCoords(indexLeft), _coordCalculator.GetOddColumnCoords(yIndex));
            spawnLetter(letters[indexRight], _coordCalculator.GetOddRowCoords(indexRight), _coordCalculator.GetOddColumnCoords(yIndex));

            --indexLeft;
            ++indexRight;
        }
    }

    private void spawnLetterRow(List<string> letters, int xIndex, int yIndex)
    {
        spawnLetterRow(letters, xIndex, yIndex);
    }

    /// <summary>
    /// Spawn letter in X and Y position on the screen
    /// with correct sprite attached to itself.
    /// </summary>
    /// <param name="letter">Letter to display</param>
    /// <param name="x">X position</param>
    /// <param name="y">Y position</param>
    private void spawnLetter(string letter, float x, float y)
    {
        if (_spawnTimerConst > 0.0f)
        {
            _spawnTimer += _spawnTimerConst;
            StartCoroutine(spawnLetterOnTimer(_spawnTimer, letter, x, y));
        }
        else
            spawnLetterInstantly(letter, x, y);
    }

    private IEnumerator spawnLetterOnTimer(float timer, string letter, float x, float y)
    {
        yield return new WaitForSeconds(timer);
        spawnLetterInstantly(letter, x, y);
    }

    private void spawnLetterInstantly(string letter, float x, float y)
    {
        var letterIndex = _letterDictionary[letter];
        GameObject newSpawnObject = _spawnObject;
        newSpawnObject.transform.GetComponent<Image>().sprite = _sprites[letterIndex];
        newSpawnObject.name = letter;
        var instantiate = Instantiate(newSpawnObject, new Vector3(x, y, 0), transform.rotation);
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
