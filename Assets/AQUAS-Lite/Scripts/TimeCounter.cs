using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCounter : MonoBehaviour
{
    public Text countdownText;
    private float totalTime = 60f; // 倒數總時間，這裡設置為60秒
    private float timeLeft; // 剩餘時間

    void Start()
    {
        timeLeft = totalTime;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            UpdateTimerUI();
            yield return new WaitForSeconds(1f); // 等待一秒
            timeLeft -= 1f; // 每過一秒，減少剩餘時間
        }

        // 當計時器結束時，更新UI以顯示00:00
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        // 將時間轉換為分鐘和秒
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);

        // 格式化時間並更新UI
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
