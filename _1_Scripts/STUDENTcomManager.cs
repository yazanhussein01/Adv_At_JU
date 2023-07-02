using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STUDENTcomManager : MonoBehaviour
{
    [SerializeField] GameObject _2048button;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _2048button.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            _2048button.SetActive(false);
    }
}
