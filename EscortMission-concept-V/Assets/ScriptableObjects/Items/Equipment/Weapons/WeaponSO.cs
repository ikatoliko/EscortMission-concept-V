using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "SOs/Items/Equipment/Weapon")]
public class WeaponSO : EquipmentSO<WeaponStatSO> {
    [field: SerializeField] public WeaponTypeSO WeaponType { get; private set; }
}