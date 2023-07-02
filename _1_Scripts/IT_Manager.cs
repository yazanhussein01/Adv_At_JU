using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Manager : MonoBehaviour
{
    [SerializeField] GameObject PackmanButton;

    private void OnTriggerEnter(Collider other)
    {
        PackmanButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        PackmanButton.SetActive(false);   
    }
}
