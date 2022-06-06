using UnityEngine;

public abstract class BaseSO : ScriptableObject {
    [SerializeField] private bool _useCustomName = false;
    [SerializeField] private string _customName;

    public string GetNameOfTheSO() => _useCustomName ? _customName : this.name;
}
