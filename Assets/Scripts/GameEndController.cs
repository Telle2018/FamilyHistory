using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour, IInteractable
{
    public bool CanInteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

    public void Interact(GameState gameState)
    {
        SceneManager.LoadScene(3);
    }

    public void Uninteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }
}
