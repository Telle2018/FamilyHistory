using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanelController : MonoBehaviour, IInteractable
{
    public GameObject[] textPanels;
    public int triggerIndex;
    public int prevTrigIndex;
    public GameObject triggerInteractable;
    public GameObject triggerUninteractable;

    int panelIndex;
    bool debounce;
    bool lookingAtPanels;

    public void Start() {
        foreach (GameObject textPanel in textPanels) {
            textPanel.SetActive(false);
        }
        panelIndex = 0;
        lookingAtPanels = false;
        textPanels[0].transform.parent.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetButton("Jump") && lookingAtPanels && panelIndex<textPanels.Length)
        {
            if (!debounce)
            {
                textPanels[panelIndex].SetActive(false);
                panelIndex++;

                if (panelIndex<textPanels.Length && textPanels[panelIndex] != null)
                {
                    textPanels[panelIndex].SetActive(true);
                }
                else
                {
                    lookingAtPanels = false;
                }
            }
            debounce = true;
        }
        else
        {
            debounce = false;
        }
    }


    public void Interact(GameState gameState) {
        if (!lookingAtPanels && panelIndex==0)
        {
            textPanels[0].SetActive(true);
            panelIndex = 0;
            debounce = true;
            lookingAtPanels = true;
            gameState.triggered[triggerIndex] = true;
            if(triggerInteractable != null)
            {
                triggerInteractable.GetComponent<IInteractable>().Interact(gameState);
            }
        }
    }

    public void Uninteract(GameState gameState) {
        panelIndex = 0;
        lookingAtPanels = false;
        foreach (GameObject textPanel in textPanels)
        {
            textPanel.SetActive(false);
        }
        if (triggerUninteractable != null)
        {
            triggerUninteractable.GetComponent<IInteractable>().Interact(gameState);
        }
    }
    public bool CanInteract(GameState gameState) {
        return (!lookingAtPanels && panelIndex == 0 && gameState.triggered[prevTrigIndex]);
    }

}
