using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Korrel.ObjectOnEventCreator
{
    public class ObjectOnEventManager : MonoBehaviour
    {
        public ObjectsOnEvent[] objectsOnEvent;
        private Dictionary<string, List<GameObject>> eventObjects = new Dictionary<string, List<GameObject>>();

        void Awake()
        {
            CreateEventObjects(objectsOnEvent);
        }

        void Start()
        {
            // Register events
            Events.current.onCreateObject += CreateObject;
        }

        private void CreateEventObjects(ObjectsOnEvent[] _objectsOnEvent)
        {
            for (int i = 0; i < _objectsOnEvent.Length; i++)
            {
                if (! eventObjects.ContainsKey(_objectsOnEvent[i].eventIdentifier))
                {
                    eventObjects.Add(_objectsOnEvent[i].eventIdentifier, new List<GameObject>());
                }
                eventObjects[_objectsOnEvent[i].eventIdentifier].AddRange(_objectsOnEvent[i].objectsToCreate);
            }
        }

        public void CreateObject(string eventIdentifier, Transform _transform, float duration)
        {
            if (! eventObjects.ContainsKey(eventIdentifier)) return;
            foreach (GameObject objectToCreate in eventObjects[eventIdentifier])
            {
                GameObject newObject = Instantiate(objectToCreate, _transform.position, _transform.rotation);
                if (duration != 0) Destroy(newObject, duration);
            }
        }
    }
}