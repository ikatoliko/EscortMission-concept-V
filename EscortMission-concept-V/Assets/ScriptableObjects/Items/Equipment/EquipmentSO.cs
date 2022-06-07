using UnityEngine;

public abstract class EquipmentSO : BaseSO {
    [field: SerializeField] public EquipmentMaterialSO Material { get; private set; }
    [field: SerializeField] public EquipmentQualitySO Quality { get; private set; }
}
