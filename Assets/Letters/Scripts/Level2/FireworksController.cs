using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksController : MonoBehaviour {
    public GameObject Fireworks;

    private float _minY;
    private float _maxY;
    private float _minX;
    private float _maxX;

    public void StartFireworks()
    {
        findMaxBorderValues();

        InvokeRepeating("InvokeBulkFireworks", 0f, 0.5f);
    }

    private void InvokeBulkFireworks()
    {
        var numberOfRockets = Random.Range(0, 4);

        for (var i = 0; i < numberOfRockets; i++)
        {
            // Position
            var randomX = Random.Range(_minX, _maxX);
            var randomY = Random.Range(_minY, _maxY);

            var instantiate = Instantiate(Fireworks, new Vector3(randomX, randomY, 0), Quaternion.identity);
            instantiate.transform.SetParent(gameObject.transform, false);
            instantiate.name = "Fireworks";

            Destroy(instantiate, 5f);
        }
    }

    private void findMaxBorderValues()
    {
        var canvas = FindCanvas().GetComponent<RectTransform>();

        var height = canvas.rect.height;
        var width = canvas.rect.width;

        float offset = 300f;

        _minY = (-1) * (height / 2f);
        _minY += offset;

        _maxY = height / 2f;
        _maxY -= offset;

        _minX = (-1) * (width / 2f);
        _minX += offset;

        _maxX = width / 2f;
        _maxX -= offset;

        Debug.Log(_minX + " " + _maxX);
    }

    private GameObject FindCanvas()
    {
        return GameObject.FindGameObjectWithTag("Canvas");
    }
}
