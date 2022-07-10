using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのコンポーネント
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>playerのHp</summary>
    [SerializeField] float _hp;

    /// <summary>弾のオブジェクト</summary>
    [SerializeField] GameObject _bullet;

    /// <summary>弾の出現する場所</summary>
    [SerializeField] GameObject _muzzle;

    /// <summary>弾の向かう位置</summary>
    [SerializeField] GameObject _targetObj;

    /// <summary>次の弾丸が出せるまでの時間</summary>
    [SerializeField] float shagekikankaku;

    /// <summary>弾丸が出せるか</summary>
    [SerializeField] bool _canShot = true;

    /// <summary>射撃時の音</summary>
    [SerializeField] AudioClip _shotSound;

    [SerializeField] AudioSource audioSource;

    /// <summary>タッチした場所のx座標</summary>
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
    /// 射撃のメソッド
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
    /// 次に撃てるまでのコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator ShotInterval()
    {
        yield return new WaitForSeconds(shagekikankaku);
        _canShot = true;
    }

    /// <summary>
    /// 敵に当たった時壊れるメソッド
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
