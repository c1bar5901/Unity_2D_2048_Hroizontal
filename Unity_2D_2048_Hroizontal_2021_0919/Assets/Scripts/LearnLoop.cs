using UnityEngine;

public class LearnLoop : MonoBehaviour
{
    private void Start()
    {
        //��X�Ʀr 1 ~5
        print("�Ʀr�G" + 1);
        print("�Ʀr�G" + 2);
        print("�Ʀr�G" + 3);
        print("�Ʀr�G" + 4);
        print("�Ʀr�G" + 5);

        //�j��G���ư���
        //while �j��y�k�G
        //while (���L��) {���L�� ���� true �|���� ���򪽨쥬�L�� false �{�����e}
        int number = 1;

        //�� �Ʀr �թ� 6 �|����...
        while (number < 6)
        {
            print("while �j��Ʀr�G" + number);
            number++;
        }

        // for (��l�� ; ���L�� ; �j�鵲������{���ԭz)
        for (int i = 1 ; i < 6; i++)
        {
            print("for �j��Ʀr�G" + i);
        }
    }


}
