using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour
{
    TMPro.TextMeshProUGUI theText;

    [SerializeField] GameObject opened;
    [SerializeField] GameObject closed;

    private void Start()
    {
        //theText = GameObject.FindGameObjectWithTag("TheText").GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            /*theText.text = "Press E to open the treasure.";
            if (Input.GetKey(KeyCode.E))
            {
                //other.GetComponent<Movement>().FoundOne();
                theText.text = "";
                GetComponent<BoxCollider>().enabled = false;
                opened.SetActive(true);
                closed.SetActive(false);
            }*/

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //theText.text = "";
    }
}
