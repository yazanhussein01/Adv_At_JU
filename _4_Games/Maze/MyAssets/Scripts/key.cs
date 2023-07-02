using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    TMPro.TextMeshProUGUI theText;

    private void Start()
    {
        theText = GameObject.FindGameObjectWithTag("TheText").GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            /*theText.text = "Press E to take the key.";
            if (Input.GetKey(KeyCode.E))
            {
                other.GetComponent<Movement>().gotKey();
                theText.text = "";
                Destroy(gameObject);
            }*/
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //theText.text = "";
    }
}
