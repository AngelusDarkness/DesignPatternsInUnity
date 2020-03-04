using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum ScenesNames {
    kMain,
    kLevel1,
    kLevel2,
    kResult,
}

public class LevelController : MonoBehaviour {
    [SerializeField] private string[] _scenes;
    
    private int _loadedScenes = 1;
    private bool _loadingScene = true;

    private void Start() {
        StartCoroutine(MergeScenes());
    }

    private IEnumerator MergeScenes() {
        Debug.Log("Destination Scene: " + _scenes[0]);
        _loadedScenes = 1;
        for(var i=1; i<_scenes.Length; i++) {
			
            StartCoroutine(MergeAsyncScene(_scenes[i], _scenes[0]));
            while(_loadingScene) {
                yield return null;
            }

#if UNITY_EDITOR
            // AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(_scenes[i]);
            // while (!asyncUnload.isDone) {
            // 	Debug.Log("Waiting for unloading: " + _scenes[i]);
            // 	yield return null;
            // }
#endif			
        }
        Debug.Log("Loaded Scenes: " + _loadedScenes);
        while(_loadedScenes < _scenes.Length) {
            yield return null;
        }

        //Activate last scene loaded.
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_scenes[_scenes.Length - 1]));
        Debug.Log("Scenes Merge Finalized");
        
        StartGame();
    }

    IEnumerator MergeAsyncScene(string srcSceneName, string dstSceneName) {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        var asyncLoad = SceneManager.LoadSceneAsync(srcSceneName, LoadSceneMode.Additive);
        _loadingScene = true;
        //Wait until the last operation fully loads to return anything
        Debug.Log($"Fake Progress: {asyncLoad.progress}");
        while (!asyncLoad.isDone) {
            yield return null;
        }		

        _loadedScenes++;
        _loadingScene = false;
    }

    void StartGame() {
        Debug.Log("Game Begin");
    }
}
