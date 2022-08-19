using System;

public sealed class MainMenuButtons : SceneTransitionRequestor {
    public override event Action<SceneTransitioner.ScenesInBuild> transToScene;
    public void TransitionToBattleScene() {
        transToScene?.Invoke(SceneTransitioner.ScenesInBuild.BattleScene);
    }
}