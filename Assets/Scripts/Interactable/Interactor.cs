using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayerMask;
    [SerializeField] private Camera mainCamera;
    public Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 2, interactableLayerMask))
        {   
            if(hit.collider.GetComponent<Interactable>() != false)
            {   
                if(interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                }
                EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.ON_HOVER_TREAT);
                Debug.Log("I SEE A TREAT");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (interactable.getInteractableType() == "Treat")
                    {
                        EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.ON_INTERACT);
                        EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.TREAT_FOUND);

                        interactable.OnInteract();
                        GameController.instance.GetTreat();
                    }
                }
            }
            
        }
        else
        {
            EventBroadcaster.Instance.PostEvent(EventNames.JabubuEvents.NOT_HOVER_TREAT);
        }
    }

}
