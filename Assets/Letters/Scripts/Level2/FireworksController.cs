using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksController : MonoBehaviour {
    public GameObject[] Fireworks;

    private float _minY;
    private float _maxY;
    private float _minX;
    private float _maxX;

    void Start () {
        findMaxBorderValues();

        for(var i=0; i<10; i++)
        {
            var randomX = Random.Range(_minX, _maxX);
            var randomY = Random.Range(_minY, _maxY);

            var instantiate = Instantiate(Fireworks[0], new Vector3(randomX, randomY, 0), Quaternion.identity);
            instantiate.transform.SetParent(gameObject.transform, false);

            StartCoroutine(destroyFirework(instantiate, 5f));
        }
    }

    private IEnumerator destroyFirework(GameObject obj, float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(obj);
    }

    private void findMaxBorderValues()
    {
        var canvas = FindCanvas().GetComponent<RectTransform>();

        var height = canvas.rect.height;
        var width = canvas.rect.height;

        _minY = (-1) * (height / 2f);
        _maxY = height / 2f;

        _minX = (-1) * (width / 2f);
        _maxX = width / 2f;
    }

    private GameObject FindCanvas()
    {
        return GameObject.FindGameObjectWithTag("Canvas");
    }
}
