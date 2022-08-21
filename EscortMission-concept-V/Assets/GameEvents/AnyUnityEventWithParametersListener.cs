using UnityEngine;
using UnityEngine.Events;

public abstract class AnyUnityEventWithParametersListener<T> : MonoBehaviour, IGameEventWithParameterListener<T> {
    [SerializeField] private AnyGameEventWithParameterSO<T> _gameEvent;
    [SerializeField] private UnityEvent<T> _response;

    public void OnEventRaised(T item) {
        _response?.Invoke(item);
    }
    private void OnEnable() {
        _gameEvent?.RegisterListener(this);
    }
    private void OnDisable() {
        _gameEvent?.UnregisterListener(this);
    }

}