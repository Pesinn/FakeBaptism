using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class LettersContainer
{
    private List<string> _correctChoosenLetters;
    private List<string> _choosenLetters;
    private List<string> _correctLetters;

    private Result _containerStatus;

    public LettersContainer()
    {
        _correctChoosenLetters = new List<string>();
        _choosenLetters = new List<string>();
        _correctLetters = new List<string>();

        _containerStatus = new Result();

        _correctLetters.Add("N");
        _correctLetters.Add("A");
        _correctLetters.Add("D");
        _correctLetters.Add("I");
        _correctLetters.Add("A");
        _correctLetters.Add("B");
        _correctLetters.Add("J");
        _correctLetters.Add("O");
        _correctLetters.Add("R");
        _correctLetters.Add("K");
    }

    public List<string> GetCorrectName()
    {
        return _correctLetters;
    }

    public List<string> GetChoosenLetters()
    {
        return _correctChoosenLetters;
    }

    public string GetListAsString(string name, List<string> list)
    {
        var str = "";
        var index = 0;
        foreach (var i in list)
        {
            if (index > 0)
            {
                str += ",";
            }
            str += i;
            index++;
        }
        Debug.Log(name + ": " + str);
        return str;
    }

    public Result PickLetter(string letter)
    {
        resetResult();

        setLetter(letter);

        _containerStatus.Action = "PICK";
        // User cannot pick higher number of letters than
        // the name represents
        if (_choosenLetters.Count < _correctLetters.Count)
        {
            _choosenLetters.Add(letter);
            pickLetter(letter);
        }
        else
        {
            _containerStatus.Status = 1;
            _containerStatus.Text = "Ekki er hægt að velja fleiri stafi";
            _containerStatus.InnerText = "Maximum number of picked letters is already reached";
        }

        if (isCorrectName())
            _containerStatus.isCorrectName = true;

        // GetListAsString("_correctChoosenLetters", _correctChoosenLetters);
        // GetListAsString("_choosenLetters", _choosenLetters);

        return _containerStatus;
    }

    private void pickLetter(string letter)
    {
        if (_correctChoosenLetters.Count <= _correctLetters.Count)
        {
            if (isCorrectLetter(letter))
                processCorrectLetter(letter);
            else
                processWrongLetter(letter);
        }
        else
        {
            _containerStatus.Status = 2;
            _containerStatus.InnerText = "Error. Correct choosen count is higher than all correct letters!";
        }
    }

    public Result UnPickLetter(string letter)
    {
        resetResult();
        setLetter(letter);

        _containerStatus.Action = "UNPICK";

        if (_choosenLetters.Contains(letter))
        {
            _choosenLetters.Remove(letter);
            _containerStatus.Status = 0;
        }
        else
        {
            _containerStatus.Status = 2;
            _containerStatus.InnerText = "You cannot unpick a letter that hasn't been picked";
        }

        return _containerStatus;
    }

    private void processCorrectLetter(string letter)
    {
        _containerStatus.isCorrectLetter = true;

        if (_correctChoosenLetters.Count <= _correctLetters.Count)
        {
            if (!isLetterCap(letter))
            {
                _containerStatus.isTriggeredLetter = true;
                _correctChoosenLetters.Add(letter);
                _containerStatus.Status = 0;
                _containerStatus.InnerText = "The letter is correct and added to the list";
            }
            else
            {
                _containerStatus.Status = 0;
                _containerStatus.InnerText = "The letter has already been choosen";
            }
        }
    }

    private void processWrongLetter(string letter)
    {
        _containerStatus.isCorrectLetter = false;
        _containerStatus.Status = 0;
        _containerStatus.isTriggeredLetter = false;
        _containerStatus.InnerText = "Wrong letter";
    }

    private void resetResult()
    {
        _containerStatus.Action = "";
        _containerStatus.Status = 0;
        _containerStatus.Text = "";
        _containerStatus.Letter = "";
        _containerStatus.isCorrectLetter = false;
        _containerStatus.isTriggeredLetter = false;
        _containerStatus.InnerText = "";
        _containerStatus.isCorrectName = false;
    }
    
    /// <summary>
    /// Check if letter has been choosen as often as it should
    /// </summary>
    /// <param name="correct">List of correct letters</param>
    /// <param name="choosen">List of choosen letters</param>
    /// <param name="letter">Letter to check</param>
    /// <returns>true if no more 'letter' should be added to choosen list</returns>
    private bool isLetterCap(string letter)
    {
        if(countNumberOfLetterInList(_correctLetters, letter) <= countNumberOfLetterInList(_correctChoosenLetters, letter))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Compares _correctChoosenLetters to _correctLetters
    /// and returns true if they both contain same elements
    /// regardless of the order.
    /// </summary>
    /// <returns>true if lists contain same elements</returns>
    private bool isCorrectName()
    {
        if (_correctChoosenLetters.Count != _correctLetters.Count)
            return false;

        List<string> correctChoosenLetters = _correctChoosenLetters;
        List<string> correctLetters = _correctLetters;

        var correctChoosenOrdered = correctChoosenLetters.OrderBy(x => x).ToList();
        var correctOrdered = correctLetters.OrderBy(x => x).ToList();

        return correctChoosenOrdered.SequenceEqual(correctOrdered);
    }

    private int countNumberOfLetterInList(List<string> list, string letter)
    {
        var counter = 0;

        foreach (var i in list)
        {
            if(i == letter)
            {
                ++counter;
            }
        }

        return counter;
    }

    private bool isCorrectLetter(string letter)
    {
        if(_correctLetters.Contains(letter))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void setLetter(string letter)
    {
        _containerStatus.Letter = letter;
    }
}