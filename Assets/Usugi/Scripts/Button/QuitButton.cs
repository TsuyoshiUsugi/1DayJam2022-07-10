using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����ꂽ��Q�[�����I������R���|�[�l���g
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
