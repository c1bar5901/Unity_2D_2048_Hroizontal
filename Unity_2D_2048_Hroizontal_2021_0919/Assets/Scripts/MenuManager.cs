using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �}�l�e�����޲z��
/// �}�l�C���B�]�w�B���}�C��
/// </summary>
public class MenuManager : MonoBehaviour
{
    //unity ���s�P�{�����q
    //1.���}��k
    //2.���s�]�w�I���ƥ� on Click

    /// <summary>
    /// �}�l�C��
    /// </summary>
    public void StartGame()
    {
        // �����޲z�A���J��ĵ(�����W��)
        SceneManager.LoadScene("�C������");
        //SceneManager.LoadScene(1);
    }

    /// <summary>
    /// �]�w�C��
    /// </summary>
    public void SettingGame()
    {

    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame()
    {
        //���ε{��.���}();
        //Quit ���|�A Editor ����A�o�������ҡB����BPC
        Application.Quit();
        print("���}�C��");
    }
}
