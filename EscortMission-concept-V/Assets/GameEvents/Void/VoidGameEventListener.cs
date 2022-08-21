using UnityEngine;
using UnityEngine.Events;

public class VoidGameEventListener : MonoBehaviour, IVoidGameEventListener {
    [SerializeField] private VoidGameEventSO _gameEvent;
    [SerializeField] private UnityEvent _response;

    public void OnEventRaised() {
        _response?.Invoke();
    }
    private void OnEnable() {
        _gameEvent?.RegisterListener(this);
    }
    private void OnDisable() {
        _gameEvent?.UnregisterListener(this);
    }
}
