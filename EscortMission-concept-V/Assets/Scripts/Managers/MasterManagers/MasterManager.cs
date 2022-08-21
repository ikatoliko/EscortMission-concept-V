using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public sealed class MasterManager : AnyManager {
    [SerializeField] private MasterDataSO _masterData;

    private Camera _mainCamera;

    void OnStart() {
        RegisterCamera();
    }

    private void RegisterCamera() {
        _mainCamera = FindCamera();
    }

    private Camera FindCamera() {
        return FindObjectOfType<Camera>();
    }
    
}