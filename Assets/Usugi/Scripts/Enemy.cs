using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̓����̃R���|�[�l���g
/// </summary>
public class Enemy : MonoBehaviour
{
    /// <summary>�v���C���[�̃I�u�W�F�N�g</summary>
    GameObject _player;

    /// <summary>�G�̈ړ��X�s�[�h</summary>
    [SerializeField] float _moveSpeed;

    /// <summary>�G�ɗ^����_���[�W</summary>
    [SerializeField] float _damagePoint;

    /// <summary>�|���ꂽ���̃X�R�A</summary>
    [SerializeField] float _scorePoint;

    /// <summary>�|���ꂽ���̃T�E���h</summary>
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
    /// �v���C���[�Ɍ������Ĉړ�������
    /// </summary>
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// ���̃I�u�W�F�N�g�ɓ����������̃��\�b�h
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

