using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class num : MonoBehaviour
{
    TMPro.TextMeshProUGUI Text;

    private void Start()
    {
        //Text = GetComponent<TMPro.TextMeshProUGUI>();
        //Text.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().TreasuresFound() + "/10";
        //GameObject.FindGameObjectWithTag("Player").SetActive(false);
    }

    public void replay()
    {
        SceneManager.LoadScene(0);
    }
}
