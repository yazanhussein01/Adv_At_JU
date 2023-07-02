using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementClass : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] string label;
    [SerializeField] Text text;

    [SerializeField] InventoyItemData idPrefab;

    [SerializeField] achievementsUIManager achUiManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.text = "Press E to achieve \" " + label; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (id == 8)
                {
                    player_inventory.playerInventory.Add(idPrefab);
                }
                else if (id == 0)
                {
                    CutScenesManagerScript.Instance.EnterTowerCutScene();
                }


                FinishAchievement();

            }
    }

    private void Start()
    {
        if (AchievementsManagerScript.achievementsManager.isFinishedAchievement(id))
        {
            gameObject.SetActive(false);
        }
    }

    public void FinishAchievement()
    {
        AchievementsManagerScript.achievementsManager.FinishAchievement(id);
        AchievementsManagerScript.achievementsManager.AddPoints(10);

        achUiManager.AchievementIsDone(id);


        text.text = "";
        gameObject.SetActive(false);
    }
}
