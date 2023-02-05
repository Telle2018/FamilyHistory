using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(GameState gameState);
    void Uninteract(GameState gameState);
    bool CanInteract(GameState gameState);
}
