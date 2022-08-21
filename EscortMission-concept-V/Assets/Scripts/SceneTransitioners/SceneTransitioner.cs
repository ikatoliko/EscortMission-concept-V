using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class SceneTransitioner : MonoBehaviour {
    public enum ScenesInBuild {
        MainScene,
        MainMenuScene,
        BattleScene
    }

#if UNITY_EDITOR
    [SerializeField] private bool doNotLoadFirstScene = false;
#endif

    [SerializeField] private CodedGameEventListener<int> _sceneTransitionRequestListener;
    

    void OnEnable() {
        SceneManager.sceneLoaded += MakeSceneActive;
        _sceneTransitionRequestListener?.Enable(Ovo);
    }
    void OnDisable() {
        SceneManager.sceneLoaded -= MakeSceneActive;
        _sceneTransitionRequestListener?.Disable(Ovo);
    }

    private void MakeSceneActive(Scene scene, LoadSceneMode mode) {
        SceneManager.SetActiveScene(scene);
    }

    private void Ovo(int sceneNO) {
        TransitionTo((ScenesInBuild)sceneNO);
    }

    [SerializeField] private ScenesInBuild _firstScene;

    void Awake() {
        #if UNITY_EDITOR
            if (!doNotLoadFirstScene) {
        #endif
                LoadScene(_firstScene);
        #if UNITY_EDITOR
            }
        #endif
    }

    public void TransitionTo(ScenesInBuild sceneToOpen) {
        UnloadCurrentScene();

        LoadScene(sceneToOpen);
    }

    private void UnloadCurrentScene() {
        if(SceneManager.sceneCount == 2) SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
    }

    private void LoadScene(ScenesInBuild sceneToOpen) {
        SceneManager.LoadSceneAsync((int)sceneToOpen, LoadSceneMode.Additive);
    }
}
