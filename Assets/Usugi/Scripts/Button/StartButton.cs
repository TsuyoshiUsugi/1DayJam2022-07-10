using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///�@�V�[����J�ڂ���R���|�[�l���g
/// </summary>
public class StartButton : MonoBehaviour
{
    /// <summary>
    /// �Q�[�����n�߂郁�\�b�h
    /// </summary>
    public void OnClick()
    {
        SceneManager.LoadScene("UsugiScene");
    }


}
