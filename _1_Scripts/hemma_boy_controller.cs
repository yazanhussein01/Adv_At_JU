using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class hemma_boy_controller : MonoBehaviour
{

    Animator an;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform followPoint;

    [SerializeField] GameObject panelUI;
    [SerializeField] GameObject textSpeech;

    
    bool done = false;
    bool first = true;
    void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && first)
        {
            first = false;
            panelUI.SetActive(true);
            textSpeech.GetComponent<FixGUITextCS>().StartDialogue();
            StartCoroutine(follow());
        }
    }

    IEnumerator follow()
    {
        agent.SetDestination(followPoint.position);
        an.SetFloat("speed", Mathf.Abs(transform.position.x - followPoint.position.x)/10);
        Debug.Log(Mathf.Abs(transform.position.x - followPoint.position.x) / 10);
        yield return new WaitForSeconds(0.1f);
        if (agent.destination == followPoint.position)
            an.SetTrigger("stop");
        if (!done)
            StartCoroutine(follow());
        else
            an.SetTrigger("die");
    }

    public void die()
    {
        done = true;
    }
}
