using Cinemachine;
using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CutScenesManagerScript : MonoBehaviour
{
    public static CutScenesManagerScript Instance { get; private set; }


    [Header("Key Objects")]
    [SerializeField]
    Transform player;

    [Header("Managable UI")]
    //[SerializeField]
    //Canvas screenCanvas;
    [SerializeField]
    GameObject towerCutSceneUI;

    [SerializeField]
    GameObject mainMenUI;

    [Header("Cameras and POVs")]
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Camera TowerCamera;

    [Header("Numbers and Values")]
    [SerializeField]
    float camMovementSpeed;
    [SerializeField]
    float camRotationSpeed;




    private Vector3 oldCamPosition;
    private Quaternion oldCamRotation;
    private Vector3 targetCamPosition;
    private Quaternion targetCamRotation;
    private float elapstedTime = 0f;


    private void Start()
    {
        Instance = this;
    }

    public void EnterTowerCutScene()
    {
        player.gameObject.GetComponent<ThirdPersonController>().enabled = false;
        mainCamera.gameObject.GetComponent<CinemachineBrain>().enabled = false;

        oldCamPosition = mainCamera.gameObject.transform.position;
        oldCamRotation = mainCamera.gameObject.transform.rotation;
        targetCamPosition = TowerCamera.gameObject.transform.position;
        targetCamRotation = TowerCamera.gameObject.transform.rotation;

        towerCutSceneUI.SetActive(true);
        mainMenUI.SetActive(false);

        StartCoroutine(LerpCamera());
    }

    private IEnumerator LerpCamera()
    {
        while (mainCamera.transform.position != targetCamPosition || mainCamera.transform.rotation != targetCamRotation)
        {
            elapstedTime += Time.deltaTime;
            float lerpIncrement = elapstedTime / camMovementSpeed;

            if (mainCamera.transform.position != targetCamPosition)
                mainCamera.gameObject.transform.position = Vector3.Lerp(oldCamPosition, targetCamPosition, lerpIncrement);
            if (mainCamera.transform.rotation != targetCamRotation)
                mainCamera.gameObject.transform.rotation = Quaternion.RotateTowards(mainCamera.transform.rotation, targetCamRotation, camRotationSpeed);

            yield return null;
        }

        elapstedTime = 0;
    }

    public void ExitTowerCutScene()
    {
        player.gameObject.GetComponent<ThirdPersonController>().enabled = true;
        mainCamera.gameObject.GetComponent<CinemachineBrain>().enabled = true;

        towerCutSceneUI.SetActive(false);
        mainMenUI.SetActive(true);

        mainCamera.gameObject.transform.position = oldCamPosition;
        StopAllCoroutines();
    }
}
