using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class BattleMapManager : AnyMapSceneManager<BattleMap> {
    [SerializeField] private AnyGameEventWithParameterSO<BattleMapParameterPackage> _provideBattleMapLoaderWithData;
    void Start() {
        _provideBattleMapLoaderWithData?.Raise(new BattleMapParameterPackage(5, 6));
    }
}
