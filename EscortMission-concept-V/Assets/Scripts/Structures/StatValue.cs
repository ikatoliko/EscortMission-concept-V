using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StatValue<T> where T : StatSO {
    [field: SerializeField] public T Stat { get; private set; }
    [field: SerializeField] public float Value { get; private set; }

    public StatValue(T stat, float value) {
        this.Stat = stat;
        this.Value = value;
    }
}

[System.Serializable]
public class SignedStatValueList<T> where T : StatSO {
    public StatGiver<T> source;
    public List<StatValue<T>> statValueList;

    public SignedStatValueList(StatGiver<T> source, System.Collections.Generic.List<StatValue<T>> statValueList) {
        this.source = source;
        this.statValueList = statValueList;
    }
}

[System.Serializable]
public class ValueSource {
    public float value;
    public StatGiver source;

    public ValueSource(float value, StatGiver source) {
        this.value = value;
        this.source = source;
    }
}

[System.Serializable]
public class StatValueSource {
    public StatSO stat;
    public float sum = 0;
    public List<ValueSource> valueSourceList;

    public StatValueSource(StatSO stat, List<ValueSource> valueSourceList) {
        this.stat = stat;
        this.valueSourceList = valueSourceList;
        
        foreach(var v in valueSourceList) {
            sum += v.value;
        }
    }
}