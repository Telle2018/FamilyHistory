using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject titlePanel;

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits(bool show)
    {
        creditsPanel.SetActive(show);
        titlePanel.SetActive(!show);
    }
}
