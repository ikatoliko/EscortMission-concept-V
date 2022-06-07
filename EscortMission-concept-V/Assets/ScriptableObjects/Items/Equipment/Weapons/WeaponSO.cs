using UnityEngine;

[CreateAssetMenu] public class WeaponSO : EquipmentSO {
    [field: SerializeField] public WeaponTypeSO Type { get; private set; }
}