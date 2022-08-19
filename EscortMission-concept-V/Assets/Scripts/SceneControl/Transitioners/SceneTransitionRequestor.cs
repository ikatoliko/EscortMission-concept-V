using UnityEngine;
using System;

public abstract class SceneTransitionRequestor : MonoBehaviour {
    public abstract event Action<SceneTransitioner.ScenesInBuild> transToScene;
}
