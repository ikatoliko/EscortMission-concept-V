using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HexRenderer))]
public class Hexa : MonoBehaviour {
    public int q;
    public int r;

    public void SetCoords(int q, int r) {
        this.q = q;
        this.r = r;
        
        gameObject.name = $"Hex ({this.q}, {this.r})";
    }
}
