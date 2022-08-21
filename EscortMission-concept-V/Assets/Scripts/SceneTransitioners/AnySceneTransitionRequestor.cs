using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnySceneTransitionRequestor : MonoBehaviour {
    [SerializeField] protected AnyGameEventWithParameterSO<int> _sceneTransitionRequest;

    protected void RequestSceneTransition(SceneTransitioner.ScenesInBuild toScene) {
        _sceneTransitionRequest?.Raise((int)toScene);
    }
}
