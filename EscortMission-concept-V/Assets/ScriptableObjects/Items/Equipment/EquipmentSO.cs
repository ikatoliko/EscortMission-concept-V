using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentSO<T> : BaseSO where T : StatSO {
    #if UNITY_EDITOR
    public List<StatValueSource> displayStats;
    #endif
    [field: SerializeField] public EquipmentMaterialSO EquipmentMaterial { get; private set; }
    [field: SerializeField] public EquipmentQualitySO Quality { get; private set; }
    [field: SerializeField] public EnchantmentSO Enchantment { get; private set; }
    public Dictionary<T, List<ValueSource>> Stats { get; private set; }

    private void GenerateStats() {
        Stats = new Dictionary<T, List<ValueSource>>();
        foreach (var p in this.GetType().GetProperties()) {
            if (typeof(StatGiver<T>).IsAssignableFrom(p.PropertyType)) {
                var signedStatList = (p.GetValue(this) as StatGiver<T>).GetSignedStats<T>();
                foreach (var stat in signedStatList.statValueList) {
                    if (!Stats.ContainsKey(stat.Stat)) 
                        Stats.Add(stat.Stat, new List<ValueSource>());
                    Stats[stat.Stat].Add(new ValueSource(stat.Value, signedStatList.source));
                }
            }
        }
    }

    #if UNITY_EDITOR
    private void PopulateDisplayStats() {
        displayStats = new List<StatValueSource>();
        foreach(var item in Stats) {
            displayStats.Add(new StatValueSource(item.Key, item.Value));
        }
    }
    #endif

    void OnEnable() {
        GenerateStats();

        #if UNITY_EDITOR
        PopulateDisplayStats();
        #endif
    }
}