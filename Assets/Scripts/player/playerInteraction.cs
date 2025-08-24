using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    public float interactionOffset;
    public float interactionRange;
    public string interactionTagName = "Interactable object";
    public string interactKey = "e";

    public static GameObject crosshairs;
    public static GameObject crosshairAttack;
    public static GameObject crosshairInteract;
    public static GameObject crosshairNpc;

    GameObject objectToInteract;
    GameObject previousObjectToInteract;

    public void initialize()
    {
        crosshairs = transform.Find("crosshairsUI").transform.Find("crosshairs").gameObject;
        crosshairAttack = crosshairs.transform.Find("attack").gameObject;
        crosshairInteract = crosshairs.transform.Find("interact").gameObject;
        crosshairNpc = crosshairs.transform.Find("npc").gameObject;
    }
    public void Update()
    {
        objectToInteract = findInteractableObject();
        if (objectToInteract != null)
        {
            objectToInteract.GetComponent<IInteractable>().showed();
            previousObjectToInteract = objectToInteract;
            if (Input.GetKeyDown(interactKey))
            {
                objectToInteract.GetComponent<IInteractable>().onInteract();
            }
        }
        else if (previousObjectToInteract != null)
        {
            previousObjectToInteract.GetComponent<IInteractable>().hided();
        }
    }    
    public GameObject findInteractableObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * interactionOffset, interactionRange);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<IInteractable>() != null)
            {
                return collider.gameObject;
            }
        }
        return null;
    }
}
