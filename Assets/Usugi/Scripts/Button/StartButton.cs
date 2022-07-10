using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///　シーンを遷移するコンポーネント
/// </summary>
public class StartButton : MonoBehaviour
{
    /// <summary>
    /// ゲームを始めるメソッド
    /// </summary>
    public void OnClick()
    {
        SceneManager.LoadScene("UsugiScene");
    }


}
