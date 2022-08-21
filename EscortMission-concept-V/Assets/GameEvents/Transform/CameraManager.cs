using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    [SerializeField] private CodedGameEventListener<Transform> _cameraMoveRequest;

    [SerializeField] private float _cameraDistance = 2;

    void Awake() {
        _cameraMoveRequest?.Enable(SnapCameraTo);
    }

    void OnDisable() {
        _cameraMoveRequest?.Disable(SnapCameraTo);
    }

    private void SnapCameraTo(Transform trans) {
        transform.position = trans.position;
        transform.rotation = trans.rotation;
        ApplyDistance();
    }

    private void ApplyDistance() {
        transform.position += Vector3.one * Mathf.Abs(_cameraDistance) * -1;
    }
}
