using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceController : MonoBehaviour, IInteractable
{
    public float deltaX;
    public float deltaY;
    public float deltaZ;
    public AudioSource sound;

    public bool CanInteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

    public void Interact(GameState gameState)
    {
        transform.Translate(new Vector3(deltaX, deltaY, deltaZ));
        if (sound != null)
        {
            sound.Play();
        }
    }

    public void Uninteract(GameState gameState)
    {
        throw new System.NotImplementedException();
    }

}
