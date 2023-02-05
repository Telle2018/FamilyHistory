using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour, IInteractable
{
    public TextPanelController openBook;
    public GameObject closedBook;

    public bool CanInteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

    public void Interact(GameState gameState)
    {
        openBook.gameObject.SetActive(true);
        closedBook.SetActive(false);
    }

    public void Uninteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

}
