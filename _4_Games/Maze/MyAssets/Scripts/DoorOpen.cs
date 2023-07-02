using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject keyImage;

    Animator an;
    BoxCollider bc;

    TMPro.TextMeshProUGUI theText;
    bool notOpened;
    private void Start()
    {
        an = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();

        //theText = GameObject.FindGameObjectWithTag("TheText").GetComponent<TMPro.TextMeshProUGUI>();
        //notOpened = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //an.SetBool("isOpened", true);
        GameObject.FindGameObjectWithTag("timer").GetComponent<timer>().startTimer();
        /*if (notOpened)
        {
            if (other.tag == "Player")
            {

                if (other.GetComponent<Movement>().hasKey())
                {
                    theText.text = "Press E to open the door.";
                    if (Input.GetKey(KeyCode.E))
                    {
                        an.SetBool("isOpened", true);
                        notOpened = false;
                        keyImage.SetActive(false);
                        GameObject.FindGameObjectWithTag("timer").GetComponent<timer>().startTimer();
                    }
                }
                else
                {
                    theText.text = "You need a Key to open this door";
                }
            }
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        //theText.text = "";
    }

}
