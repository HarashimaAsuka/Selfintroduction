using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics; // Process用
using System.IO;
using System.Collections;

public class GameLauncher : MonoBehaviour
{
    public Button game1Button;
    public Button game2Button;

    void Start()
    {
        // ボタンを押すとLaunchGameにパスを渡す
        game1Button.onClick.AddListener(() => StartCoroutine(LaunchGame("ActionGame")));
        game2Button.onClick.AddListener(() => StartCoroutine(LaunchGame("PickUpPresent")));
    }

    IEnumerator LaunchGame(string relativePath)
    {
        string exePath = "";

#if UNITY_EDITOR
        // エディタ用の絶対パス
        if(relativePath.Contains("ActionGame")){
            exePath = @"C:\大学課題\2年\前期\プログラミング入門\ActionGame\ActionGameExe\ActionGameProject.exe";
        }
        else if(relativePath.Contains("PickUpPresent")){
            exePath = exePath = @"C:\Github\pickuppresent\exe_resize\PickUpPresent.exe";
        }
#else
        // ビルド後は相対パス
        if(relativePath == "ActionGame"){
            exePath = Path.Combine(Application.dataPath, "../ActionGame/ActionGameProject.exe");
        }
        else if(relativePath == "PickUpPresent"){
            exePath = Path.Combine(Application.dataPath, "../PickUpPresent/PickUpPresent.exe");
        }
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
}
