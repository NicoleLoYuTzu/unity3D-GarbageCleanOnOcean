using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // 移動速度
    public float minX = -5f; // 平面範圍的最小X值
    public float maxX = 5f; // 平面範圍的最大X值
    public float minZ = -5f; // 平面範圍的最小Z值
    public float maxZ = 5f; // 平面範圍的最大Z值

    public GameObject planePrefab; // 需要掉下的plane的Prefab
    public Transform capsuleTop; // capsule正上方的Transform

    private Vector3 targetPosition; // 目標位置
    private float dropInterval = 5f; // 每隔五秒掉下一個plane
    private float timer = 0f;

    void Start()
    {
        // 在起始時設置一個隨機的目標位置
        SetRandomTargetPosition();
    }

    void Update()
    {
        // 將海龜移向目標位置
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 如果到達目標位置，則設置一個新的隨機目標位置
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }

        // 更新計時器
        timer += Time.deltaTime;

        // 如果計時器超過掉下間隔，生成一個plane
        if (timer >= dropInterval)
        {
            DropPlane();
            timer = 0f; // 重置計時器
        }
    }

    // 設置一個隨機目標位置
    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    void DropPlane()
    {
        // 定义一个偏移量来调整平面的高度
        float planeHeightOffset = 2f; // 假设为2单位高度偏移量，你可以根据需要调整这个值

        // 在capsule的正上方生成plane，但是将其位置向上偏移一定距离
        Vector3 planeSpawnPosition = capsuleTop.position + Vector3.up * planeHeightOffset;
        GameObject newPlane = Instantiate(planePrefab, planeSpawnPosition, Quaternion.identity);

        // 取得plane的rigidbody組件
        Rigidbody rb = newPlane.GetComponent<Rigidbody>();
        // 如果找不到rigidbody，則直接返回
        if (rb == null)
        {
            Debug.LogWarning("Plane prefab does not have a Rigidbody component!");
            return;
        }
        // 将布料设置为静态，使其不受物理影响而保持不动
        rb.isKinematic = true;

   
    }


}
