using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/Void")]
public class VoidGameEventSO : ScriptableObject {
    private readonly List<IVoidGameEventListener> _eventListeners = new();

    public void Raise() {
        for (int i = _eventListeners.Count - 1; i >= 0; i--) {
            _eventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(IVoidGameEventListener listener) {
        if(!_eventListeners.Contains(listener)) _eventListeners.Add(listener);
    }

    public void UnregisterListener(IVoidGameEventListener listener) {
        if(_eventListeners.Contains(listener)) _eventListeners.Remove(listener);
    }
}
