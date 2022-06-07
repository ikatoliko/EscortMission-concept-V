using UnityEngine;

public abstract class BaseSO : ScriptableObject {
    [SerializeField, HideInInspector] private bool _useCustomName = false;
    [SerializeField, HideInInspector] private string _customName;

    public string GetNameOfTheSO() => _useCustomName ? _customName : this.name;
}
