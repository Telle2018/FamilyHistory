using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour, IInteractable
{
    public GameObject textPanel;

    public void Interact(GameState gameState) {
        if (gameState.sphereRemoved) {
            textPanel.SetActive(true);
        }
    }

    public void Uninteract(GameState gameState) {
        textPanel.SetActive(false);
    }

     public bool CanInteract(GameState gameState) {
        return gameState.sphereRemoved;
    }
}

