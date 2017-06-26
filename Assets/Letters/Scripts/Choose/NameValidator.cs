using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choose
{
    public class NameValidator : MonoBehaviour {

        private List<GameObject> _gameObjects;
        private NameLetterStorage _storeHandler;
        private const int MAX = 33;

        void Start()
        {
            _gameObjects = new List<GameObject>();
            _storeHandler = new NameLetterStorage();

            handleContinueButton();
        }

        public bool isNameFull()
        {
            if (_gameObjects.Count >= MAX)
                return true;
            return false;
        }

        public bool isNameEmpty()
        {
            if (_gameObjects.Count <= 0)
                return true;
            return false;
        }

        public void AddGameObject(GameObject gObject)
        {
            if (_gameObjects.Count >= MAX)
                Debug.LogWarning("Maximum number of letters already picked");
            else
            {
                _gameObjects.Add(gObject);
                saveNewName();
                handleContinueButton();
            }
        }

        public void RemoveGameObject(GameObject gObject)
        {
            if (_gameObjects.Count > 0) {
                _gameObjects.Remove(gObject);
                saveNewName();
                handleContinueButton();
            }
            else
                Debug.LogWarning("Trying to remove object in a empty list");
        }

        private void handleContinueButton()
        {
            GameObject.Find("/Canvas/Panel/Continue/Button").GetComponent<ButtonCharm>().ButtonChanges(_gameObjects.Count);
        }

        public void saveNewName()
        {
            var nameList = new List<string>();
            foreach(var i in _gameObjects)
                nameList .Add(i.name.Substring(0, 1));
            _storeHandler.SetName(nameList);
        }
    }
}