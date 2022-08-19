using System;

public sealed class BattleMapButtons : SceneTransitionRequestor {
    public override event Action<SceneTransitioner.ScenesInBuild> transToScene;

    public void TransitionToMainMenu() {
        transToScene?.Invoke(SceneTransitioner.ScenesInBuild.MainMenuScene);
    }
}
