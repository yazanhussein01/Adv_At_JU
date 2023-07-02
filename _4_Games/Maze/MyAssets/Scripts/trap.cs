using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    [SerializeField] Animator an;
    [SerializeField] GameObject ss;
    private void OnTriggerEnter(Collider other)
    {
        an.SetBool("open", true);
        Invoke(nameof(sound), 1f);
    }

    void sound()
    {
        ss.SetActive(true);
        Invoke(nameof(destroy), 1f);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
