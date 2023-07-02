    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story : MonoBehaviour
{
    TMPro.TextMeshProUGUI theText;
    private void OnTriggerEnter(Collider other)
    {
        theText = GameObject.FindGameObjectWithTag("TheText").GetComponent<TMPro.TextMeshProUGUI>();
        if (other.tag == "Player")
        {
            theText.text = "Welcome to the castle maze\n there are 10 treasures in this castle.";
            Invoke(nameof(secondline), 4f);
        }
    }
    void secondline()
    {
        theText.text = "You have 5 minutes to find all of them\n or you'll die in here trying.";
        Invoke(nameof(destroyline), 4f);
    }
    private void destroyline()
    {
        theText.text = "";
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject, 4f);
    }
}
