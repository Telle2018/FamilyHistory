using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour, IInteractable
{
    public GameObject textPanel;

    public void Interact(GameState gameState) {
        textPanel.SetActive(true);
    }

    public void Uninteract(GameState gameState) {
        textPanel.SetActive(false);
    }
    public bool CanInteract(GameState gameState) {
        return true;
    }
}
