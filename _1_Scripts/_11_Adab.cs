using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_Adab : MonoBehaviour
{
    [SerializeField] GameObject MazeEnterButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MazeEnterButton.SetActive(true);
            //FindObjectOfType<LoadingScreenManagerScript>().LoadScreen(0, 1);
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MazeEnterButton.SetActive(false);
        }
    }


}
