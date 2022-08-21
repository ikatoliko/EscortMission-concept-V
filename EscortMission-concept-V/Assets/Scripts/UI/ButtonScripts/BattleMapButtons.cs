using System;
using UnityEngine;

public sealed class BattleMapButtons : AnySceneTransitionRequestor {
    public void TransitionToMainMenu() {
        RequestSceneTransition(SceneTransitioner.ScenesInBuild.MainMenuScene);
    }
}


