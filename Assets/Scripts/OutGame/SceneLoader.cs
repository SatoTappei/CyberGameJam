using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移のクラス
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// 名前を指定してシーンをロードする
    /// </summary>
    /// <param name="sceneName">ロードするシーンの名前</param>
    public void SceneLoad(string sceneName)
    {
        Debug.Log($"Loading {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}