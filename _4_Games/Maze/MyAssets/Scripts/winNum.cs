using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winNum : MonoBehaviour
{
    TMPro.TextMeshProUGUI Text;

    private void OnEnable()
    {
        Text = GetComponent<TMPro.TextMeshProUGUI>();
        Text.text = GameObject.FindGameObjectWithTag("timer").GetComponent<timer>().timeLeft();
    }

    public void replay()
    {
        SceneManager.LoadScene(0);
    }
}