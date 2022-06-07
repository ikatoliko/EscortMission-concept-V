using UnityEngine;

[CreateAssetMenu] public class WeaponTypeSO : BaseSO {
    [field: SerializeField] public WeaponRangeSO Range { get; private set; }
    [field: SerializeField] public WeaponWieldingSO Wielding { get; private set; }
}
