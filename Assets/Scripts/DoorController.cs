using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour, IInteractable
{
    public string sceneName;

    public bool CanInteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

    public void Interact(GameState gameState)
    {
        SceneManager.LoadScene(sceneName);


            }

    public void Uninteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

}

