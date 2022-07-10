using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 押されたらゲームを終了するコンポーネント
/// </summary>
public class QuitButton : MonoBehaviour
{
    public void OnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
