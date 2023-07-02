using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achievementsUIManager : MonoBehaviour
{
    public static achievementsUIManager AchievementsUIManager;
    private void Awake()
    {
        AchievementsUIManager = this;
    }

    public void AchievementIsDone(int i)
    {
        transform.GetChild(i).GetComponent<Button>().interactable = false;
        transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(i).GetChild(2).gameObject.SetActive(true);
    }
}
