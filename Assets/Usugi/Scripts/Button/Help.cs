using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��������̃V�[���Ɉڂ�R���|�[�l���g
/// </summary>
public class Help : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("HelpScene");
    }
}
