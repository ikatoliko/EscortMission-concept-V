using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] public class EquipmentMaterialSO : BaseSO {
    [field: SerializeField] public List<string> EffectOnWeapons { get; private set; }
    [field: SerializeField] public List<string> EffectOnArmors { get; private set; }
}
