using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class koshk_manager : MonoBehaviour
{
    [SerializeField] List<InventoyItemData> items;
    [SerializeField] GameObject canvas;
    [SerializeField] Text text;

    [SerializeField] TextMeshProUGUI cost;
    
    private void OnTriggerEnter(Collider other)
    {
        text.text = "Press E to open the Koshk menu";
    
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            text.text = "";
            canvas.SetActive(true);
            FindObjectOfType<StarterAssets.ThirdPersonController>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.text = "";
    }

    [SerializeField] int itemID;
    [SerializeField] GameObject buyButton;

    public void pressButton(int i)
    {
        itemID = i;
        cost.text = "Cost = " + items[i].price;
        buyButton.GetComponent<Button>().interactable = true;
    }

    public void BuyButton()
    {
        if (AchievementsManagerScript.achievementsManager.TakePoints(items[itemID].price))
        {
            player_inventory.playerInventory.Add(items[itemID]);
            NotificationSystem.notificationSystem.sendNotification("Thank you for buying! \n See you again!!");
            cost.text = "";
            canvas.SetActive(false);
            FindObjectOfType<StarterAssets.ThirdPersonController>().enabled = true;
            
        }
        else
        {
            text.text = "You don't have enough money for this item";
            canvas.SetActive(false);
            FindObjectOfType<StarterAssets.ThirdPersonController>().enabled = true;
            cost.text = "";
            Invoke(nameof(ResetText), 5);
        }
    }

    void ResetText()
    {
        text.text = "";
    }


}
