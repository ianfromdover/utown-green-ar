using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideScene : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenuPage";
    public void BackHome()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
