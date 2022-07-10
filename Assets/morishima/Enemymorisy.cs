using UnityEngine;

public class Enemymorisy : MonoBehaviour
{
   
    [SerializeField]
    private GameObject enemyPrefab;//生成オブジェクト 

    [SerializeField] float minX = -2.27f;//生成範囲
    [SerializeField] float maxX = 2.27f;//生成範囲
    [SerializeField] float minY = 5.6f;//生成範囲
    [SerializeField] float maxY = 8.0f;//生成範囲

    public float minTime = 1.0f;//時間間隔最小値
    public float maxTime = 3.0f;//時間間隔最大値
    private float enemyframe;//生成する間隔
    private float enemytime;//経過時間

    void Start()
    {
        enemyframe = GetRandomTime();
    }

    void Update()
    {
        enemytime += Time.deltaTime;
        
        if (enemytime > enemyframe)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = GetRandomPosition();
            enemytime = 0;
            enemyframe = GetRandomTime();
        }
        

        enemyPrefab.transform.Translate(0, -0.01f, 0);
    }

    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private Vector2 GetRandomPosition()
    {
        float posX = Random.Range(minX, maxX);
        float posY = Random.Range(minY, maxY);
        return new Vector2(posX, posY);
    }
}