
using UnityEngine;

public class LearnIf : MonoBehaviour
{
    public bool openDoor;

    private void Start()
    {
        //�P�_�� if
        //�y�k
        //�p�G (���L��) { ���L�� ���� true �|���� �{�����e }
        //�_�h { ���L�� ���� false �|���� �{�����e }
        if (true)
        {
            print("���L��true�G");
        }
        if (false)
        {
            print("���L��false�G");
        }

        // openDoor == true �P openDoor 
        if(openDoor)
        {
            print("�}��");
        }
        else
        {
            print("����");
        }
    }
}

