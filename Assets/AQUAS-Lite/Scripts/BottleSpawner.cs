using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    public GameObject bottlePrefab; // 瓶子的預製物件
    public float spawnRadius = 5f; // 生成範圍半徑
    public int maxNumberOfBottles = 10; // 最大瓶子數量

    private GameObject[] bottles; // 儲存生成的瓶子物件

    void Start()
    {
        SpawnBottles(maxNumberOfBottles); // 初始化時生成指定數量的瓶子
    }

    void Update()
    {
        // 檢查目前的瓶子數量
        int currentNumberOfBottles = CountBottles();

        // 如果瓶子數量少於最大數量，則新增瓶子
        if (currentNumberOfBottles < maxNumberOfBottles)
        {
            SpawnBottles(1);
        }
    }

    // 生成指定數量的瓶子
    void SpawnBottles(int numBottles)
    {
        for (int i = 0; i < numBottles; i++)
        {
            // 在 Plane 上隨機生成位置
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = 0f; // 將 Y 軸設置為 0，確保瓶子在 Plane 的表面上

            // 生成瓶子的副本並使用與 Bottle Prefab 相同的旋轉值
            GameObject newBottle = Instantiate(bottlePrefab, spawnPosition, Quaternion.identity);

            // 設置瓶子的旋轉值為預置物體的旋轉值
            newBottle.transform.rotation = bottlePrefab.transform.rotation;

            // 將瓶子設置為 Plane 的子物體
            newBottle.transform.parent = transform;
        }
    }


    // 計算目前的瓶子數量
    int CountBottles()
    {
        bottles = GameObject.FindGameObjectsWithTag("bottle");
        return bottles.Length;
    }
}
