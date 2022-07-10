using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 操作説明のシーンに移るコンポーネント
/// </summary>
public class Help : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("HelpScene");
    }
}
