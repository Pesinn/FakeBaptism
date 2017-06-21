using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo
{
    private float _width;
    private float _height;
    private Vector2 _scale;

    public ObjectInfo(float width, float height, Vector2 scale)
    {
        _width = width;
        _height = height;
        _scale = scale;
    }

    public float GetWidth()
    {
        return _width;
    }

    public float GetHeight()
    {
        return _height;
    }

    public Vector2 GetScale()
    {
        return _scale;
    }
}

public class ChildObject
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


public class CoordCalculator {
    private CanvasObject _canvas;
    private ChildObject _childObject;

    private List<float> _evenRowCoords;
    private List<float> _oddRowCoords;
    private List<float> _evenColumnCoords;
    private List<float> _oddColumnCoords;

    public CoordCalculator(ObjectInfo canvas, ObjectInfo child)
    {
        initialize(canvas, child);
        calculateCoords();
    }

    private void initialize(ObjectInfo canvas, ObjectInfo child)
    {
        generateChildStats(child);
        generateCanvasStats(canvas);
    }

    public List<float> GetEvenRowCoords()
    {
        return _evenRowCoords;
    }

    public float GetEvenRowCoords(int index)
    {
        if (_evenRowCoords.Count <= index)
            return -1;
        return _evenRowCoords[index];
    }

    public List<float> GetOddRowCoords()
    {
        return _oddRowCoords;
    }

    public float GetOddRowCoords(int index)
    {
        if (_oddRowCoords.Count <= index)
            return float.MaxValue;
        return _oddRowCoords[index];
    }

    public List<float> GetEvenColumnCoords()
    {
        return _evenColumnCoords;
    }

    public float GetEvenColumnCoords(int index)
    {
        if (_evenColumnCoords.Count <= index)
            return float.MaxValue;
        return _evenColumnCoords[index];
    }

    public List<float> GetOddColumnCoords()
    {
        return _oddColumnCoords;
    }

    public float GetOddColumnCoords(int index)
    {
        if (_oddColumnCoords.Count <= index)
            return float.MaxValue;
        return _oddColumnCoords[index];
    }

    /// <summary>
    /// Calculate size of each child object
    /// </summary>
    private void generateChildStats(ObjectInfo child)
    {
        var x = child.GetWidth() * child.GetScale().x;
        var y = child.GetHeight() * child.GetScale().y;

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
    private void generateCanvasStats(ObjectInfo canvas)
    {
        _canvas = new CanvasObject();
        _canvas.Size.x = canvas.GetWidth();
        _canvas.Size.y = canvas.GetHeight();
        _canvas.Offset = 20f;
        _canvas.BoardSize.x = _canvas.Size.x - _canvas.Offset;
        _canvas.BoardSize.y = _canvas.Size.y - _canvas.Offset;
    }

    private void calculateCoords()
    {
        _evenRowCoords = new List<float>();
        _oddRowCoords = new List<float>();
        _evenColumnCoords = new List<float>();
        _oddColumnCoords = new List<float>();

        calculateOddRowCords();
        calculateEvenRowCoords();
        calculateColumnCoords();
    }

    private void calculateOddRowCords()
    {
        calculateRowCoords(0.0f, false);
    }

    private void calculateEvenRowCoords()
    {
        // Calculate the offset from middle
        var offset = _childObject.Offset.x / 2f;

        // Calculate the mid coord of the object
        var midPosition = (_childObject.Size.x / 2f);

        var x = (-1) * (offset + midPosition);

        calculateRowCoords(x, true);
    }

    private void calculateRowCoords(float x, bool isEven)
    {
        if (!isInsideCanvas(x, 0.0f)) return;

        addXCoords(x, isEven);
        if (x == 0)
            calculateRowCoords(createNewXPositionLeft(x), isEven);
        else
        {
            // Be sure that the negative value is also inside
            // the canvas before adding it
            var positiveCoord = (-1) * x;
            if (isInsideCanvas(positiveCoord, 0.0f))
                addXCoords(positiveCoord, isEven);

            calculateRowCoords(createNewXPositionLeft(x), isEven);
        }
    }

    private void addXCoords(float coords, bool isEven)
    {
        if (isEven)
            _evenRowCoords.Add(coords);
        else
            _oddRowCoords.Add(coords);
    }

    private void addYCoords(float coords, bool isEven)
    {
        if (isEven)
            _evenColumnCoords.Add(coords);
        else
            _oddColumnCoords.Add(coords);
    }
    
    /// <summary>
    /// Create new X position according to parameters position.
    /// When displaying new object left to an old object,
    /// the paramter should have the old object x pos, and
    /// the new object's X position will be returned.
    /// </summary>
    /// <param name="x">Position to work from</param>
    /// <returns>New X position</returns>
    private float createNewXPositionLeft(float x)
    {
        // Change x to positive number if it's negative
        if (x < 0.0f)
            x = x * (-1);

        var size = _childObject.Size.x + _childObject.Offset.x;
        x += size;
        x *= (-1);
        return x;
    }

    /// <summary>
    /// Create new X position according to parameters position.
    /// When displaying new object right to an old object,
    /// the paramter should have the old object x pos, and
    /// the new object's X position will be returned.
    /// </summary>
    /// <param name="x">Position to work from</param>
    /// <returns>New X position</returns>
    private float createNewXPositionRight(float x)
    {
        x += _childObject.Size.x + _childObject.Offset.x;
        return x;
    }

    private bool isInsideCanvas(float x, float y)
    {
        // Create positive number if needed
        x = x < 0.0f ? x * (-1) : x;

        var returnValue = (_canvas.BoardSize.x / 2f) > x ? true : false;

        if (returnValue)
        {
            y = y < 0.0f ? y * (-1) : y;

            returnValue = (_canvas.BoardSize.y / 2f) > y ? true : false;
        }

        return returnValue;
    }

    private void calculateColumnCoords()
    {
        calculateEvenColumnCoords();
        calculateOddColumnCoords();
    }

    private void calculateEvenColumnCoords()
    {
        // Calculate the offset from middle
        var offset = _childObject.Offset.y / 2f;

        // Calculate the mid coord of the object
        var midPosition = (_childObject.Size.y / 2f);

        var y = (-1) * (offset + midPosition);

        calculateColumnCoords(y, true);

        _evenColumnCoords.Sort();
        _evenColumnCoords.Reverse();
    }

    private void calculateOddColumnCoords()
    {
        calculateColumnCoords(0.0f, false);

        _oddColumnCoords.Sort();
        _oddColumnCoords.Reverse();
    }

    private void calculateColumnCoords(float y, bool isEven)
    {
        if (!isInsideCanvas(0.0f, y)) return;

        addYCoords(y, isEven);

        if (y == 0)
            calculateColumnCoords(createNewYPositionDown(y), isEven);
        else
        {
            // Be sure that the negative value is also inside
            // the canvas before adding it
            var positiveCoord = (-1) * y;
            if (isInsideCanvas(positiveCoord, 0.0f))
                addYCoords(positiveCoord, isEven);

            calculateColumnCoords(createNewYPositionDown(y), isEven);
        }
    }

    private float createNewYPositionUp(float y)
    {
        var size = _childObject.Size.y + _childObject.Offset.y;
        y += size;
        return y;
    }

    private float createNewYPositionDown(float y)
    {
        y = y < 0.0f ? y * (-1) : y;

        var size = _childObject.Size.y + _childObject.Offset.y;
        y += size;
        y *= (-1);
        return y;
    }

    public int CountChildrenCapInEachRow()
    {
        return countChildrenCap(_childObject.Size.x, _childObject.Offset.x, _canvas.BoardSize.x);
    }

    public int CountChildrenCapInEachColumn()
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



}
