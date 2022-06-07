using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment Material", menuName = "SOs/Items/Equipment/Material")]
public class EquipmentMaterialSO : BaseSO {
    [field: SerializeField] public List<string> EffectOnWeapons { get; private set; }
    [field: SerializeField] public List<string> EffectOnArmors { get; private set; }
}
