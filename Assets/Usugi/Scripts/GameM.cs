using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームを管理するコンポーネント
/// </summary>
public class GameM : MonoBehaviour
{
    /// <summary>点数の変数</summary>
    [SerializeField] static float _score = 0;

    /// <summary>時間をカウントする変数</summary>
    [SerializeField] float _timeCount;

    /// <summary>音を鳴らすかの判定の変数</summary>
    [SerializeField] bool _playSound;

    [SerializeField] Text _scoreText;

    [SerializeField] GameObject Player;

    [SerializeField] AudioClip _downSound;

    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject _oni;

    public bool PlaySound { get => _playSound; set => _playSound = value; }

    public static float Score { get => _score; set => _score = value; }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score : " + _score;

        EndGame();

        EnemyDown();

        _timeCount += 1 * Time.deltaTime;

        //60秒たったら敵をものすごく増やす
        if (_timeCount > 60)
        {
            _oni.SetActive(true);
        }
    }

    /// <summary>
    /// プレイヤーが倒されたらシーン遷移するメソッド
    /// </summary>
    void EndGame()
    {
        if (Player == null)
        {
            SceneManager.LoadScene("ScoreScene");
        }
    }

    /// <summary>
    /// 敵が倒されたら音を鳴らすメソッド
    /// </summary>
    public void EnemyDown()
    {
        if (_playSound == true)
        {
            audioSource.PlayOneShot(_downSound);
            _playSound = false;
        }
    }
}
