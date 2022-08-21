using System.Collections.Generic;
using UnityEngine;

public abstract class AnyGameEventWithParameterSO<T> : ScriptableObject {
    private readonly List<IGameEventWithParameterListener<T>> _eventListeners = new();

    public void Raise(T item) {
        for (int i = _eventListeners.Count - 1; i >= 0; i--) {
            _eventListeners[i].OnEventRaised(item);
        }
    }

    public void RegisterListener(IGameEventWithParameterListener<T> listener) {
        if(!_eventListeners.Contains(listener)) _eventListeners.Add(listener);
    }

    public void UnregisterListener(IGameEventWithParameterListener<T> listener) {
        if(_eventListeners.Contains(listener)) _eventListeners.Remove(listener);
    }
}