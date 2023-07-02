using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour
{
    [SerializeField] Text t;
    [SerializeField] GameObject notificationClosed;

    public static NotificationSystem notificationSystem;

    private void Awake()
    {
        notificationSystem = this;
    }

    public void sendNotification(string s)
    {
        notificationClosed.SetActive(true);
        t.text = s;
        Invoke(nameof(close), 7);
    }

    void close()
    {
        gameObject.SetActive(false);
        t.text = "";
    }
}
