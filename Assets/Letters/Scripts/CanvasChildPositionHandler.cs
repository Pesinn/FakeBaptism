using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChildPositionHandler {

    private class ChildObject
    {
        public Vector2 Size;
        public Vector2 Offset;

        public ChildObject()
        {
            Size = new Vector2();
            Offset = new Vector2();
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


    public CanvasChildPositionHandler()
    {
        
    }

    public void Spawn()
    {

    }
}
