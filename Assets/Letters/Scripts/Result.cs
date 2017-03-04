using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result
{
    /// <summary>
    /// OK = 0
    /// WARNING = 1
    /// ERROR = 2
    /// </summary>
    public int Status { get; set; }

    // Text to be displayed to the user
    public string Text { get; set; }

    // Text for developers for response description
    public string InnerText { get; set; }

    // Letter that was choosen/picked
    public string Letter { get; set; }

    public bool isCorrectLetter { get; set; }

    public string Action { get; set; }

    // true if the letter should be marked
    public bool isTriggeredLetter { get; set; }

    public bool isCorrectName { get; set; }
}