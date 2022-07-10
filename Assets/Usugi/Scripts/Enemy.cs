using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の動きのコンポーネント
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>プレイヤーのオブジェクト</summary>
    GameObject _player;

    /// <summary>敵の移動スピード</summary>
    [SerializeField] float _moveSpeed;

    /// <summary>敵に与えるダメージ</summary>
    [SerializeField] float _damagePoint;

    /// <summary>倒された時のスコア</summary>
    [SerializeField] float _scorePoint;

    /// <summary>倒された時のサウンド</summary>
    [SerializeField] AudioClip _downSound;

    AudioSource audioSource;

    void Start()
    {

        _player = FindObjectOfType<Player>().gameObject;
        audioSource = gameObject.GetComponent<AudioSource>();        
    }

    void Update()
    {
        Move();

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// プレイヤーに向かって移動させる
    /// </summary>
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 他のオブジェクトに当たった時のメソッド
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(_downSound);
            FindObjectOfType<GameM>().PlaySound = true;
            GameM.Score += _scorePoint;
            Destroy(gameObject);
        }

        if (collision.tag == "Player")
        {
            audioSource.PlayOneShot(_downSound);
            collision.GetComponent<Player>().HP -= _damagePoint;
            Destroy(gameObject);
        }
    }
}

