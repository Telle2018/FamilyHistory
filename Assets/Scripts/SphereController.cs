using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour, IInteractable
{
    public void Interact(GameState gameState) {
        gameObject.SetActive(false);
        gameState.sphereRemoved = true;
    }

    public void Uninteract(GameState gameState) {
    }
    public bool CanInteract(GameState gameState) {
        return true;
    }
}
