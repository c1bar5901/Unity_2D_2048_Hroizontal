using UnityEngine;

public class LearnPropertyStatic : MonoBehaviour
{
    private void Start()
    {
        //�R�A�ݩ� Static Property
        //���o�R�A�ݩ�
        //�y�k�G���O�W��.�R�A�ݩʦW��
        print("�H���ȡG" + Random.value);
        print("��v���`�ơG" + Camera.allCamerasCount);

        //�]�w�R�A�ݩ�
        //�y�k�G���O�W��.�R�A�ݩʦW�� ���w �ȡF
        Cursor.visible = false;
        // Mathf.PI = 9.999999      // (Read Only) ����]�w �߿W�ݩ�

    }
}
