using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class AchievementsManagerScript : MonoBehaviour
{
    [Serializable]
    class achievement
    {
        public int id, value;
        public bool done;
        public GameObject obj;
    }

    [SerializeField] List<achievement> achievements;
    [SerializeField] int points { get; set; }
    [SerializeField] TextMeshProUGUI pointsText;

    [SerializeField] GameObject achUiManager;



    public static AchievementsManagerScript achievementsManager;

    private void OnEnable()
    {
        achievementsManager = this;

        foreach (achievement a in achievements)
        {
            a.done = PlayerPrefs.GetInt(a.id.ToString(), 0) == 1;
            if (a.done)
                achUiManager.GetComponent<achievementsUIManager>().AchievementIsDone(a.id);

        }
        

        
        points = PlayerPrefs.GetInt("Points", 0);
        pointsText.text = points.ToString();
    }

    public void AddPoints(int i)
    {
        points += i;
        pointsText.text = points.ToString();
        PlayerPrefs.SetInt("Points", points);
        PlayerPrefs.Save();
    }

    public bool TakePoints(int i)
    {
        if (points >= i)
        {
            points -= i;
            pointsText.text = points.ToString();
            PlayerPrefs.SetInt("Points", points);
            PlayerPrefs.Save();
            return true;
        }
        return false;
    }

    public void FinishAchievement(int id)
    {
        achievements[id].done = true;
        PlayerPrefs.SetInt(achievements[id].id.ToString(), 1);
        NotificationSystem.notificationSystem.sendNotification("Achievement is Done!!");
        //Destroy(achievements[id].obj);
    }

    public bool isFinishedAchievement(int id)
    {
        return achievements[id].done;
    }



    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
