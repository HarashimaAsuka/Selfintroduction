using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics; // Process用
using System.IO;
using System.Collections;

public class GameLauncher : MonoBehaviour
{
    public Button game1Button;

    void Start()
    {
        // ボタンを押すとLaunchGameにパスを渡す
        game1Button.onClick.AddListener(() => StartCoroutine(LaunchGame("PastGame1/PastGame1.exe")));  
    }

    IEnumerator LaunchGame(string relativePath)
    {
        string exePath;

#if UNITY_EDITOR
        // エディタ用の絶対パス
        exePath = @"C:\大学課題\2年\前期\プログラミング入門\ActionGame\ActionGameExe\ActionGameProject.exe";
#else
        // ビルド後は相対パス
        exePath = Path.Combine(Application.dataPath, "../ActionGameExe/ActionGameProject.exe");
#endif

        if (File.Exists(exePath))
        {
            Process process = new Process();
            process.StartInfo.FileName = exePath;
            process.Start();

            // exeが閉じられるまでUnityは待機
            while (!process.HasExited)
            {
                yield return null;
            }

            UnityEngine.Debug.Log("外部ゲームが終了。自己紹介アプリに戻りました！");
        }
        else
        {
            UnityEngine.Debug.LogError("ゲームが見つかりません: " + exePath);
        }
    }

    void Update()
    {
        // 今は使わない
    }
}
