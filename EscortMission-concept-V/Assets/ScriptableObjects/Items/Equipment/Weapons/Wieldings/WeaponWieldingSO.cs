using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] public class WeaponWieldingSO : BaseSO {
    // I might decide later that all Two-handed weapons have something like +20% AP or something.
    [field: SerializeField] public List<string> EffectOfWielding { get; private set; }
}
