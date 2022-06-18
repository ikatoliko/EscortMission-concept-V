using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon Type", menuName = "SOs/Items/Equipment/Weapons/Type")]
public class WeaponTypeSO : StatGiver<WeaponStatSO> {
    [field: SerializeField] public WeaponRangeSO Range { get; private set; }
    [field: SerializeField] public WeaponWieldingSO Wielding { get; private set; }
}