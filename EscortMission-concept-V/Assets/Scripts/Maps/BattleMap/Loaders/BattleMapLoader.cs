using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMapLoader : AnyMapLoader<BattleMap> {
    [SerializeField] private GameObject _hexPrefab;
    [SerializeField] private CodedGameEventListener<BattleMapParameterPackage> _receivedMapParameterPackage;

    private BattleMap GenerateMap(BattleMapParameterPackage bmpp) {
        BattleMap battleMap = null;
        if (bmpp != null) {
            battleMap = new GameObject("BattleMap").AddComponent<BattleMap>();
            battleMap.transform.rotation = Quaternion.LookRotation(Vector3.one);

            var spawnMethod = new RectangleHexSpawnMethod();
            spawnMethod.SetPrefab(_hexPrefab, battleMap.transform);
            var hexesList = spawnMethod.SpawnHexes(bmpp.mapWidth, bmpp.mapHeight, 2);

            var hexDisplacer = new DirectHexDisplacer();
            hexDisplacer.RegisterHexesList(hexesList);
            hexDisplacer.DisplaceHexes();

            battleMap.RegisterNewHexList(hexesList);
        }
        return battleMap;
    }

    void OnEnable() {
        _receivedMapParameterPackage?.Enable(SetMapParameterPackage);
    }

    void OnDisable() {
        _receivedMapParameterPackage?.Disable(SetMapParameterPackage);
    }

    private void SetMapParameterPackage(BattleMapParameterPackage bmpp) {
        InvokeMapCreatedEvent(GenerateMap(bmpp));
        Destroy(gameObject);
    }
}

public class BattleMapParameterPackage {
    public int mapWidth;
    public int mapHeight;

    public BattleMapParameterPackage(int mapWidth, int mapHeight) {
        this.mapWidth = mapWidth;
        this.mapHeight = mapHeight;
    }
}