using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMap : AnyMap {
    private HexCollection _hexCollection;

    public override Transform InitialCameraTransform() {
        var trans = transform;
        trans.position = _hexCollection.GetHex(0, 0).transform.position;

        return trans;
    }

    public void RegisterNewHexList(List<Hexa> hexes) {
        _hexCollection = new(hexes);
    }

}

public class HexCollection {
    private Dictionary<HexCoords, Hexa> _hexColl;

    public HexCollection() {
        _hexColl = new();
    }

    public HexCollection(List<Hexa> hexesList) : this() {
        hexesList.ForEach(x => AddHexToCollection(x));
    }

    public bool AddHexToCollection(Hexa hex) {
        return _hexColl.TryAdd(hex.coords, hex);
    }

    public Hexa GetHex(int q, int r) {
        return _hexColl.GetValueOrDefault(HexCoords.Coords(q, r));
    }
}
