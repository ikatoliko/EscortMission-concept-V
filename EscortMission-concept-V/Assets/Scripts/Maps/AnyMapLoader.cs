using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AnyMapLoader<T> : MonoBehaviour where T : AnyMap {
    public event Action<AnyMapLoader<T>, T> mapCreatedEvent;

    protected void InvokeMapCreatedEvent(AnyMapLoader<T> invoker, T result) {
        mapCreatedEvent?.Invoke(invoker, result);
    }

    public abstract void GenerateMap();
}