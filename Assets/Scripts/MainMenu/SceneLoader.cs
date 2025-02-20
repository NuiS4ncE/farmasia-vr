﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private string scene;

    public CameraFadeController fadeController;

    public void SwapScene(SceneTypes type) {
        switch (type) {
            case SceneTypes.Restart:
                ChangeScene("Restart");
                return;
            case SceneTypes.MainMenu:
                ChangeScene("MainMenu");
                return;
            case SceneTypes.MedicinePreparation:
                ChangeScene("MedicinePreparation");
                return;
            case SceneTypes.Tutorial:
                ChangeScene("ControlsTutorial");
                return;
            case SceneTypes.MembraneFilteration:
                ChangeScene("XR MembraneFilteration 2.0");
                return;
            case SceneTypes.ChangingRoom:
                ChangeScene("ChangingRoom");
                return;
            case SceneTypes.FireHazard:
                ChangeScene("Laboratory");
                return;
            case SceneTypes.FireExtinguisherTutorial:
                ChangeScene("FireExtinguisherTutorial");
                return;
            case SceneTypes.FireBlanketTutorial:
                ChangeScene("FireBlanketTutorial");
                return;
            case SceneTypes.EyeShowerTutorial:
                ChangeScene("EyeShowerTutorial");
                return;
            case SceneTypes.EmergencyShowerTutorial:
                ChangeScene("EmergencyShowerTutorial");
                return;
        }
    }

    private void ChangeScene(string name) {
        scene = name;
        FadeOutScene();
    }

    public void FadeOutScene() {
        fadeController.onFadeOutComplete.AddListener(OnFadeComplete);
        fadeController.BeginFadeOut();
    }

    private void OnFadeComplete() {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Resources.UnloadUnusedAssets();
        LoadScene();
    }

    private void LoadScene() {
        Events.Reset();
        if (scene.Equals("Restart")) {
            Logger.PrintVariables("Restarting current scene", scene);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
            Logger.PrintVariables("Loading scene", scene);
            SceneManager.LoadScene(scene);
        }
    }
}
