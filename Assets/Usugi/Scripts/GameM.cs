using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[�����Ǘ�����R���|�[�l���g
/// </summary>
public class GameM : MonoBehaviour
{
    /// <summary>�_���̕ϐ�</summary>
    [SerializeField] static float _score = 0;

    /// <summary>���Ԃ��J�E���g����ϐ�</summary>
    [SerializeField] float _timeCount;

    /// <summary>����炷���̔���̕ϐ�</summary>
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

        //60�b��������G�����̂��������₷
        if (_timeCount > 60)
        {
            _oni.SetActive(true);
        }
    }

    /// <summary>
    /// �v���C���[���|���ꂽ��V�[���J�ڂ��郁�\�b�h
    /// </summary>
    void EndGame()
    {
        if (Player == null)
        {
            SceneManager.LoadScene("ScoreScene");
        }
    }

    /// <summary>
    /// �G���|���ꂽ�特��炷���\�b�h
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
