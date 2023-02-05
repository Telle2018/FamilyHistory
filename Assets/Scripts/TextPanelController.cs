/** Code is a bit of a mess -- standard "concept start simple and hacked up"

Really works in one of two ways:
- If triggerUninteractable is present, shows one panel of text, which is closed by looking away or a jump, and trigger is called
- if not present, can handle multiple panels of text, and if triggerInteractable is set, triggers after first panel
*/

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
        if (Input.GetButton("Jump") && lookingAtPanels && panelIndex<textPanels.Length && triggerUninteractable == null)
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
        if (triggerUninteractable) {
            
            if (lookingAtPanels) {
                CompleteUninteract(gameState);
                triggerUninteractable=null;
            } else {
                textPanels[0].SetActive(true);
                panelIndex = 0;
                debounce = true;
                lookingAtPanels = true;
                gameState.triggered[triggerIndex] = true;
            }
        } else
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
        if (lookingAtPanels) {
            CompleteUninteract(gameState);
        }
    }

    void CompleteUninteract(GameState gameState) {
        Debug.Log("In complete uninteract");
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
        if (triggerUninteractable) {
            return gameState.triggered[prevTrigIndex];
        }
        return (!lookingAtPanels && panelIndex == 0 && gameState.triggered[prevTrigIndex]);
    }

}
