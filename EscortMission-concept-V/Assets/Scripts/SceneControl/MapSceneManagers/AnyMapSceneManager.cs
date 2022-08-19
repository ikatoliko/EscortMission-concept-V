using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnyMapSceneManager<T> : MonoBehaviour where T : AnyMap {
    private T _map;

    protected virtual void OnEnable() {
        var mapLoader = GameObject.FindObjectOfType<AnyMapLoader<T>>();
        if(mapLoader != null) mapLoader.mapCreatedEvent += HandleMapCreatedEvent;
        else Debug.LogError($"There is no MapLoader of type {mapLoader.GetType()}");
    }
    protected void HandleMapCreatedEvent(AnyMapLoader<T> eventSender, T map) {
        eventSender.mapCreatedEvent -= HandleMapCreatedEvent;
        _map = map;
    }
}
