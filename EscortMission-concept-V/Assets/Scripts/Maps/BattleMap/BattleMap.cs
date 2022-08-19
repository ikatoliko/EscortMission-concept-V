using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMap : AnyMap {
    private HexCollection _hexCollection;

    void OnEnable() {
        _hexCollection = new();
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
}
