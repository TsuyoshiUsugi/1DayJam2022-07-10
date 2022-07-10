using UnityEngine;

public class Enemymorisy : MonoBehaviour
{
   
    [SerializeField]
    private GameObject enemyPrefab;//�����I�u�W�F�N�g 

    [SerializeField] float minX = -2.27f;//�����͈�
    [SerializeField] float maxX = 2.27f;//�����͈�
    [SerializeField] float minY = 5.6f;//�����͈�
    [SerializeField] float maxY = 8.0f;//�����͈�

    public float minTime = 1.0f;//���ԊԊu�ŏ��l
    public float maxTime = 3.0f;//���ԊԊu�ő�l
    private float enemyframe;//��������Ԋu
    private float enemytime;//�o�ߎ���

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