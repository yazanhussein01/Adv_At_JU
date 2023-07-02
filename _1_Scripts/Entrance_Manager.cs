using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entrance_Manager : MonoBehaviour
{
    [SerializeField] Camera startCamera;
    [SerializeField] Camera mainCamera;

    [SerializeField] Image Enterance_UI_BG;


    private Vector3 oldCamPosition;
    private Vector3 targetCamPosition;
    private Quaternion targetCamRotation;
    private float elapstedTime = 0f;
    float camRotationSpeed = 3;
    float camMovementSpeed = 3;


    public void startGame()
    {
        oldCamPosition = startCamera.gameObject.transform.position;
        targetCamPosition = mainCamera.gameObject.transform.position;
        targetCamRotation = mainCamera.gameObject.transform.rotation;
        StartCoroutine(LerpCamera());
    }

    private IEnumerator LerpCamera()
    {
        float alpha = Enterance_UI_BG.color.a;
        while (startCamera.transform.position != targetCamPosition /*|| startCamera.transform.rotation != targetCamRotation*/)
        {
            Enterance_UI_BG.color = new Color(0,0,0, alpha-=0.01f);
            targetCamPosition = mainCamera.gameObject.transform.position;
            targetCamRotation = mainCamera.gameObject.transform.rotation;
            elapstedTime += Time.deltaTime;
            float lerpIncrement = elapstedTime / camMovementSpeed;

            if (startCamera.transform.position != targetCamPosition)
                startCamera.gameObject.transform.position = Vector3.Lerp(oldCamPosition, targetCamPosition, lerpIncrement);
            if (startCamera.transform.rotation != targetCamRotation)
                 startCamera.gameObject.transform.rotation = Quaternion.RotateTowards(startCamera.transform.rotation, targetCamRotation, camRotationSpeed);
            yield return null;
        }
        startCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        
    }



    #region Enterance
    [SerializeField] Text t;

    [SerializeField] GameObject rightDoor;
    [SerializeField] GameObject leftDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            t.text = "Press \"E\" to start";
        }

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(OpenMainDoors());
                t.text = "";
            }
        }
    }

    IEnumerator OpenMainDoors()
    {
        while (rightDoor.transform.rotation.y < 0.75f)
        {
            rightDoor.transform.Rotate(0, 5 * Time.deltaTime, 0);
            leftDoor.transform.Rotate(0, -5 * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.005f);
            t.text = "";
        }
        Destroy(gameObject);
        yield break;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            t.text = "";
        }
    }
    #endregion
}
