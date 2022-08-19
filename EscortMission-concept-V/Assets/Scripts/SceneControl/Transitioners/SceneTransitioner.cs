using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class SceneTransitioner : MonoBehaviour {
    public enum ScenesInBuild {
        MainScene,
        MainMenuScene,
        BattleScene
    }

    public ScenesInBuild _firstScene;

    private ScenesInBuild _currentScene;
    private List<SceneTransitionRequestor> _currentRequestors;

    void OnEnable() {
        _currentRequestors = new();
        SceneManager.sceneLoaded += ScanForSceneTransitionRequestors;
        LoadScene(_firstScene);
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= ScanForSceneTransitionRequestors;
    }

    private void ScanForSceneTransitionRequestors(Scene scene, LoadSceneMode mode) {
        foreach(var requestor in GameObject.FindObjectsOfType<SceneTransitionRequestor>()) {
            requestor.transToScene += TransitionTo;
            _currentRequestors.Add(requestor);
        }
    }

    public void TransitionTo(ScenesInBuild sceneToOpen) {
        UnloadCurrentScene();

        LoadScene(sceneToOpen);
    }

    private void UnloadCurrentScene() {
        UnsubscribeFromAllRequestors();
        SceneManager.UnloadSceneAsync((int)_currentScene);
    }

    private void LoadScene(ScenesInBuild sceneToOpen) {
        SceneManager.LoadScene((int)sceneToOpen, LoadSceneMode.Additive);
        _currentScene = sceneToOpen;
    }

    private void UnsubscribeFromAllRequestors() {
        foreach(var requestor in _currentRequestors) {
            requestor.transToScene -= TransitionTo;
        }
        _currentRequestors.Clear();
    }
}
