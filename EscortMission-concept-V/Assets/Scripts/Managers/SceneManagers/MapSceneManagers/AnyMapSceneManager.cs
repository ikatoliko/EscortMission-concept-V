using UnityEngine;

public abstract class AnyMapSceneManager<T> : AnyManager where T : AnyMap {
    protected T _map;

    #region Events
    [SerializeField] protected TransformGameEventSO _requestCameraMove;
    
    #endregion
    
    public void HandleMapCreatedEvent(T map) {
        if(map != null) {
            _map = map;
            RequestForCameraMovement(_map.InitialCameraTransform());
        }
    }

    private void RequestForCameraMovement(Transform transform) {
        _requestCameraMove?.Raise(transform);
    }
}
