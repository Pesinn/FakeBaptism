using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LetterAction
{
    Result StartLetterProcess(LettersContainer container);
}

public class PickLetter : LetterAction
{
    private string letter;
    public PickLetter(string l)
    {
        letter = l.Substring(0,1);
    }

    public Result StartLetterProcess(LettersContainer container)
    {
        return container.PickLetter(letter);
    }
}

public class UnPickLetter : LetterAction
{
    private string letter;
    public UnPickLetter(string l)
    {
        letter = l.Substring(0, 1);
    }

    public Result StartLetterProcess(LettersContainer container)
    {
        return container.UnPickLetter(letter);
    }
}