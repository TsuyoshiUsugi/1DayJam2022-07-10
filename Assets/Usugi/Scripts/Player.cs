using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̃R���|�[�l���g
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>player��Hp</summary>
    [SerializeField] float _hp;

    /// <summary>�e�̃I�u�W�F�N�g</summary>
    [SerializeField] GameObject _bullet;

    /// <summary>�e�̏o������ꏊ</summary>
    [SerializeField] GameObject _muzzle;

    /// <summary>�e�̌������ʒu</summary>
    [SerializeField] GameObject _targetObj;

    /// <summary>���̒e�ۂ��o����܂ł̎���</summary>
    [SerializeField] float shagekikankaku;

    /// <summary>�e�ۂ��o���邩</summary>
    [SerializeField] bool _canShot = true;

    /// <summary>�ˌ����̉�</summary>
    [SerializeField] AudioClip _shotSound;

    [SerializeField] AudioSource audioSource;

    /// <summary>�^�b�`�����ꏊ��x���W</summary>
    [SerializeField] Vector3 worldPos;

    public float HP { get => _hp; set => _hp = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var screenPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        Fire();
    }

    /// <summary>
    /// �ˌ��̃��\�b�h
    /// </summary>
    void Fire()
    {
        if (Input.GetButtonDown("Fire") && _canShot == true)
        {
            audioSource.PlayOneShot(_shotSound);
            _canShot = false;
            //Instantiate(_targetObj, new Vector3(_x, _y, 0), Quaternion.identity);
            Instantiate(_bullet, _muzzle.transform.position, Quaternion.identity);
            StartCoroutine("ShotInterval");
        }
    }

    /// <summary>
    /// ���Ɍ��Ă�܂ł̃R���[�`��
    /// </summary>
    /// <returns></returns>
    IEnumerator ShotInterval()
    {
        yield return new WaitForSeconds(shagekikankaku);
        _canShot = true;
    }

    /// <summary>
    /// �G�ɓ������������郁�\�b�h
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
