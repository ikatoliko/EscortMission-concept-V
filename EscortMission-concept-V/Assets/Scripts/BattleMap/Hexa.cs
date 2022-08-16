using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(HexRenderer))]
public class Hexa : MonoBehaviour {
    public HexCoords coords;
    public int deploymentField = 0;
    public TileSO tileTypeSO;

    public event Action<Hexa> onHexSelect;

    public GameObject hexOccupant;

    private MeshRenderer _myMeshRenderer;


    void OnEnable() {
        _myMeshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetCoords(int q, int r) {
        coords = new HexCoords(q, r);

        gameObject.name = $"Hex ({q}, {r})";
        if(tileTypeSO.passable) gameObject.AddComponent<MeshCollider>();
        _myMeshRenderer.material.color = tileTypeSO.c;
    }

    public void AssignDeploymentField(int fieldNo) {
        this.deploymentField = fieldNo;
    }

    void OnMouseEnter() {
    }

    void OnMouseExit() {
    }

    void OnMouseUpAsButton() {
        onHexSelect?.Invoke(this);
    }
}

public struct HexCoords {
    public int q, r;
    public HexCoords(int q, int r) {
        this.q = q;
        this.r = r;
    }

    public int GetS() => -q -r;

}
