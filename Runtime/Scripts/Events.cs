using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Korrel.ObjectOnEventCreator
{
    public class Events : MonoBehaviour
    {
        public static Events current;

        void Awake()
        {
            current = this;
        }

        public event Action<string, Transform, float> onCreateObject;

        public void SpawnPrefab(string eventIdentifier, Transform _transform, float duration)
        {
            if (onCreateObject != null) onCreateObject(eventIdentifier, _transform, duration);
        }
    }
}