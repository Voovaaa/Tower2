using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class interactionTest : MonoBehaviour, IInteractable
{
    private GameObject textWindow;
    public List<string> replics;
    private int replicNumber = -1;

    private void Start()
    {
        textWindow = transform.Find("dialogue UI").Find("text window").gameObject;
        textWindow.transform.Find("text").GetComponent<TMP_Text>().text = replics[0];
    }
    public void onInteract()
    {
        replicNumber += 1;
        if (replicNumber >= replics.Count)
        {
            replicNumber = 0;
        }
        textWindow.transform.Find("text").GetComponent<TMP_Text>().text = replics[replicNumber];
    }
    public void showed()
    {
        playerInteraction.crosshairInteract.SetActive(true);
        transform.Find("dialogue UI").gameObject.SetActive(true);
    }
    public void hided()
    {
        playerInteraction.crosshairInteract.SetActive(false);
        transform.Find("dialogue UI").gameObject.SetActive(false);
    }
}
