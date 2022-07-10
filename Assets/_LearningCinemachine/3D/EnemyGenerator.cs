using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("�G�̃v���n�u")]
    [SerializeField]private GameObject _enemyPrefab;

    [Header("���b���ƂɓG�𐶐����邩")]
    [SerializeField]private float _enemyGeneratorTime;

    [Tooltip("�Q�[���̌o�ߎ���")]
    private float _totalTime;

    private float _enemyUp;


    private float _countTime;


    private void Update()
    {
        _totalTime += Time.deltaTime;
        if (_totalTime % 10 == 0) 
        {
            _enemyUp += 0.1f;
        }
        _countTime += Time.deltaTime;
        if (_countTime > _enemyGeneratorTime - _enemyUp) 
        {
            Debug.Log("rtgrg");
            var a = Instantiate(_enemyPrefab, this.transform.position, this.transform.rotation);
            _countTime = 0;
        }
    }

}
