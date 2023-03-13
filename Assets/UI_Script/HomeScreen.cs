using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] private string artSceneName = "ARArtPage";
    [SerializeField] private string guideSceneName = "GuidePage";
    public void LoadArt()
    {
        SceneManager.LoadScene(artSceneName);
    }

    public void LoadGuide()
    {
        SceneManager.LoadScene(guideSceneName);
    }
}
