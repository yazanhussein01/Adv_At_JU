using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] GameObject lose;
    [SerializeField] GameObject win;
    [SerializeField] GameObject pause;
    [Space]
    [SerializeField] GameObject player;
    [Space]
    [SerializeField] int time;
    TMPro.TextMeshProUGUI timerText;

    bool stillPlaying = true;
    bool paused = false;

    public void startTimer()
    {
        timerText = GetComponent<TMPro.TextMeshProUGUI>();
        StartCoroutine(tim());
    }

    IEnumerator tim()
    {
        
        timerText.text = (time / 60 < 10 ? "0" + time / 60 : time / 60) + ":" + (time % 60 < 10 ? "0" + time % 60 : time % 60);
        if (paused)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(tim());
        }
        else if (stillPlaying && time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            StartCoroutine(tim());
        }
        else if (time == 0)
        {
            lose.SetActive(true);
        }
        else
        {
            win.SetActive(true);
        }
    }

    public void pauseIt()
    {
        paused = true;
        pause.SetActive(true);
        player.SetActive(false);
    }

    public void resume()
    {
        pause.SetActive(false);
        paused = false;
        player.SetActive(true);
    }

    public void won()
    {
        stillPlaying = false;
    }
    public string timeLeft()
    {
        return (time / 60 < 10 ? "0" + time / 60 : time / 60) + ":" + (time % 60 < 10 ? "0" + time % 60 : time % 60);
    }
}
