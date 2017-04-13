using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordCalculator {
    CanvasObject _canvas;
    ChildObject _child;

    List<Vector2> _coords;

    public CoordCalculator(CanvasObject canvas, ChildObject child)
    {
        _canvas = canvas;
        _child = child;
        calculateCoords();
    }

    private void calculateCoords()
    {
        _coords = new List<Vector2>();

        
    }
}
