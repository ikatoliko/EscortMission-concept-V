using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMapLoader : AnyMapLoader<BattleMap> {
    [SerializeField] private GameObject _hexPrefab;

    public override void GenerateMap() {
        var battleMap = new GameObject("BattleMap").AddComponent<BattleMap>();
        var spawnMethod = new RectangleHexSpawnMethod();
        spawnMethod.SetPrefab(_hexPrefab, battleMap.transform);
        var hexesList = spawnMethod.SpawnHexes(2, 6, 2);

        var hexDisplacer = new DirectHexDisplacer();
        hexDisplacer.RegisterHexesList(hexesList);
        hexDisplacer.DisplaceHexes();

        InvokeMapCreatedEvent(this, battleMap);
    }
}