using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "SOs/Items/Equipment/Weapon")]
public class WeaponSO : EquipmentSO {
    [field: SerializeField] public WeaponTypeSO Type { get; private set; }
}