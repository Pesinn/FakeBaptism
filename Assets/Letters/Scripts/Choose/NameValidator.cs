using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choose
{
    public class NameValidator : MonoBehaviour {

        // Max number is 39
        private List<GameObject> _gameObjects;

        void Start()
        {
            _gameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject gObject)
        {
            _gameObjects.Add(gObject);
        }

        public void RemoveGameObject(GameObject gObject)
        {
            _gameObjects.Remove(gObject);
        }

        private void Deb()
        {
            foreach(var i in _gameObjects)
            {
                Debug.Log(i);
            }
            Debug.Log("=====");
        }
    }
}