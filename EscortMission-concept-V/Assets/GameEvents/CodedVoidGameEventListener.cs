using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable] public class CodeVoidGameEventListener : IVoidGameEventListener {
    [SerializeField] private VoidGameEventSO _gameEvent;
    private Action _response;

    public void OnEventRaised() {
        _response?.Invoke();
    }

    public void Enable(Action response) {
        Debug.Log("Enable");
        _gameEvent?.RegisterListener(this);
        _response = response;
    }

    public void Disable(Action response) {
        Debug.Log("Disable");
        _gameEvent?.RegisterListener(this);
        _response = null;
    }

}


[System.Serializable] public class CodedGameEventListener<T> : IGameEventWithParameterListener<T> {
    [SerializeField] private AnyGameEventWithParameterSO<T> _gameEvent;
    private Action<T> _response;

    public void OnEventRaised(T item) {
        _response?.Invoke(item);
    }

    public void Enable(Action<T> response) {
        Debug.Log("Enable");
        _gameEvent?.RegisterListener(this);
        _response = response;
    }

    public void Disable(Action<T> response) {
        Debug.Log("Disable");
        _gameEvent?.RegisterListener(this);
        _response = null;
    }
}