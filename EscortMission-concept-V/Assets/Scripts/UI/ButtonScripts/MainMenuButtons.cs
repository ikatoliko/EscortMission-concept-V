using System;
using UnityEngine;

public sealed class MainMenuButtons : AnySceneTransitionRequestor {
    public void TransitionToBattleScene() {
        RequestSceneTransition(SceneTransitioner.ScenesInBuild.BattleScene);
    }
}