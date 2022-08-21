using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AnyMapLoader<T> : MonoBehaviour where T : AnyMap {
    [SerializeField] protected AnyGameEventWithParameterSO<T> _mapLoadedEvent;

    public void InvokeMapCreatedEvent(T result) {
        _mapLoadedEvent?.Raise(result);
    }
}