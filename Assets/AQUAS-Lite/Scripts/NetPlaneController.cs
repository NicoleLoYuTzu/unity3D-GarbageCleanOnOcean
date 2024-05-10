using UnityEngine;

public class NetPlaneController : MonoBehaviour
{
    public string targetTag; // 目標標籤
    private Cloth cloth; // 網子平面的 Cloth 組件
    private bool stopped = false; // 是否已停止運動

    void Start()
    {
        // 獲取網子平面的 Cloth 組件
        cloth = GetComponent<Cloth>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 檢查碰撞對象的標籤是否為目標標籤，並且確保只執行一次停止運動的操作
        if (collision.gameObject.tag == targetTag && !stopped)
        {
            // 停止網子平面的 Cloth 效果
            cloth.enabled = false;

            // 確保網子平面不再受物理影響，使其保持靜止
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            stopped = true;
        }
    }
}
