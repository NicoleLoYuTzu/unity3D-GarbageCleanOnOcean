using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度

    void Update()
    {
        // 获取玩家的输入
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D键或左右箭头键
        float verticalInput = Input.GetAxis("Vertical"); // W/S键或上下箭头键

        // 计算移动方向
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // 应用移动
        transform.Translate(movement);
    }
}