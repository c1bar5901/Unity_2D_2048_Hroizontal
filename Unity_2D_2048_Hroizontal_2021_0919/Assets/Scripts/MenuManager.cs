using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/// <summary>
/// �}�l�e�����޲z��
/// �}�l�C���B�]�w�B���}�C��
/// </summary>
/// �~�����O�N�i�H�s���䦨���G���B�ݩʡB��k
public class MenuManager : MonoBehaviour
{
    //unity ���s�P�{�����q
    //1.���}��k
    //2.���s�]�w�I���ƥ� on Click

    public AudioMixer mixer;

    /// <summary>
    /// �}�l�C��
    /// </summary>
    public void StartGame (float delay)
    {
        //�ϥ��~�����O�������y�k�G
        //�~�����O����k
        //��k�W��(�������޼�)
        //���� delay ���I�s ��k
        Invoke("DelayStartGame", delay);
    }
    public void DelayStartGame()
    {
        // �����޲z�A���J��ĵ(�����W��)
        SceneManager.LoadScene("�C������");
        //SceneManager.LoadScene(1);
    }

    /// <summary>
    /// �]�w�C��
    /// </summary>
    public void SettingGameBGM(float volume)
    {
        print("BGM �Ʊ쭵�q�G" + volume);
        mixer.SetFloat("���qBGM", volume);
        
    }
    public void SettingGameSFX(float volume)
    {
        print("SFX �Ʊ쭵�q�G" + volume);
        mixer.SetFloat("���qSFX", volume);
    }
    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame(float delay)
    {
        Invoke("DelayQuitGame", delay);
    }
    private void DelayQuitGame()
    {
        //���ε{��.���}();
        //Quit ���|�A Editor ����A�o�������ҡB����BPC
        Application.Quit();

        print("���}�C��");
    }
}
