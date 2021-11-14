using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 開始畫面選單管理器
/// 開始遊戲、設定、離開遊戲
/// </summary>
public class MenuManager : MonoBehaviour
{
    //unity 按鈕與程式溝通
    //1.公開方法
    //2.按鈕設定點擊事件 on Click

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void StartGame()
    {
        // 場景管理，載入場警(場景名稱)
        SceneManager.LoadScene("遊戲場景");
        //SceneManager.LoadScene(1);
    }

    /// <summary>
    /// 設定遊戲
    /// </summary>
    public void SettingGame()
    {

    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        //應用程式.離開();
        //Quit 不會再 Editor 執行，發布執行黨、手機、PC
        Application.Quit();
        print("離開遊戲");
    }
}
