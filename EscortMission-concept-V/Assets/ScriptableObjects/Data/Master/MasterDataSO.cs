using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Master Data", menuName = "SOs/Data/Master")]
public class MasterDataSO : ScriptableObject {
    [SerializeField] private List<PlayableCharacterClassSO> _playableClasses;

}
