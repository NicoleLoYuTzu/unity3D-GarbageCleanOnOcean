using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0; // 分數
    public Text scoreText; // 用于显示分数的文本对象

    private void OnTriggerEnter(Collider other)
    {
        // 檢查碰撞的物體是否是 BottleSpawner
        if (other.gameObject.tag == "bottle")
        {
            // 碰到 BottleSpawner 增加一分
            score++;
            print("Score: " + score);


            // 銷毀瓶子
            Destroy(other.gameObject);

            // 你可以在這裡執行其他相應的操作，比如播放音效、顯示 UI 提示等等
        }
    }

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }



}
