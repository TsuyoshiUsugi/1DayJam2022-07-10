using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 _touchPosition;

    /// <summary>弾丸のスピード</summary>
    [SerializeField] float _bulletSpeed;

    /// <summary>弾丸の消える時間</summary>
    [SerializeField] float _deleteTime;

    /// <summary>タッチした場所のx座標</summary>
    [SerializeField] Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        var screenPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 6)
        {
            Destroy(gameObject);
        }

        if (transform.position == worldPos)
        {
            Debug.Log(worldPos);
            Destroy(gameObject);
        }

        Move();

    }

    private void FixedUpdate()
    {
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, worldPos , _bulletSpeed * Time.deltaTime);
        StartCoroutine("BulletCol");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator BulletCol()
    {
        yield return new WaitForSeconds(_deleteTime);
        Destroy(gameObject);
    }
}
