using UnityEngine;

public class LearnSwitch : MonoBehaviour
{
    public string equipment;

    private void Start()
    {
        // Switch �y�k�G
        // Switch (�n�P�_�����)
        //{
        //      case �� 1�G
        //          �{�����e;
        //          break;
        //      case �� 2�G
        //          �{�����e;
        //          break;
        //      default�G        //���Ƥ��ŦX�W�� case �i�ٲ�
        //          �{�����e;
        //          break;
        //}

        switch (equipment)
        {
            case "�M�l":
                print("�A�{�b���ۤM�l");
                break;
            case "�e�l":
                print("�A�{�b���ۤe�l");
                break;
            default:
                print("�A�������O�Z��.....");
                break;
        }

    }
}
