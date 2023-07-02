using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MTAssets.EasyMinimapSystem;

public class GoToManagerScript : MonoBehaviour
{
    [SerializeField] GameObject[] places;
    [SerializeField] GameObject player;

    StarterAssets.ThirdPersonController cc; 
    public void GoTo(int i)
    {
        cc = player.GetComponent<StarterAssets.ThirdPersonController>();
        StartCoroutine(Teleport(i));
    }

    IEnumerator Teleport(int i)
    {
        cc.enabled = false;
        yield return new WaitForSeconds(0.2f);
        player.transform.position = places[i].transform.position;
        player.transform.rotation = places[i].transform.rotation;
        yield return new WaitForSeconds(0.2f);
        cc.enabled = true;

    }

    [SerializeField] MinimapRoutes navSystem;
    public void NavigateTo(int i)
    {
        navSystem.destinationPoint = places[i].transform;
    }


    public void startPacman()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void start2048()
    {
        SceneManager.LoadSceneAsync(2);
    }
    
}
