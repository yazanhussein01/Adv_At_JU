using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class achievementController : MonoBehaviour
{
    [SerializeField] int id;

    private void Start()
    {
       /* Debug.Log("Started");
        if (!AchievementsManagerScript.achievementsManager.isFinishedAchievement(id))
        {
            Debug.Log("done");
            transform.GetComponent<Button>().interactable = false;
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
       */
    }

}
