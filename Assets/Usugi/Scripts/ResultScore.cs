using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] float _result;

    [SerializeField] Text _scoreText;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip _gameover;
    // Start is called before the first frame update
    void Start()
    {
        _result = GameM.Score;
        _scoreText.text = _result.ToString();
        GameM.Score = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(_gameover);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
