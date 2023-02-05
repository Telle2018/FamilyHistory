using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public GameObject interactPanel;
    GameObject lastViewed;
    bool debounce;

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = new GameState();

        interactPanel.SetActive(false);
        debounce = false;
    }

    void Update() {
        if (Input.GetButton("Jump")) {
            if (lastViewed && !debounce) {
                
                IInteractable interactable = lastViewed.GetComponent<IInteractable>();
                if (interactable != null && interactable.CanInteract(gameState)) {
                    interactable.Interact(gameState);
                    interactPanel.SetActive(false);
                }
            }
            debounce = true;
        } else {
            
            debounce = false;
        }
    }

    // Called in sync with physics system
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int layerMask = 1 << 6; // Layer 6
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, 5.0f, layerMask)) {
            Debug.DrawRay(transform.position, fwd, Color.green);
            if (hit.collider.gameObject != lastViewed) {
                lastViewed = hit.collider.gameObject;
                IInteractable interactable = lastViewed.GetComponent<IInteractable>();
                if (interactable != null && interactable.CanInteract(gameState)) {
                    interactPanel.SetActive(true);
                }
            }
        }
        else if (lastViewed) {
            IInteractable interactable = lastViewed.GetComponent<IInteractable>();
            if (interactable != null) {
                interactable.Uninteract(gameState);
            }
            lastViewed = null;
            interactPanel.SetActive(false);
        }
    }
}
