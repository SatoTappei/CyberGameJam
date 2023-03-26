using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���J�ڂ̃N���X
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// ���O���w�肵�ăV�[�������[�h����
    /// </summary>
    /// <param name="sceneName">���[�h����V�[���̖��O</param>
    public void SceneLoad(string sceneName)
    {
        Debug.Log($"Loading {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}