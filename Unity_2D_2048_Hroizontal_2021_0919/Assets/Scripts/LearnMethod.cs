using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// summary �K�n
/// ��ƻ����A ��ܦb VS�sĶ�����ܤW
/// </summary>
public class LearnMethod : MonoBehaviour
{
    //��k Mothod �B Function (�禡)
    //�@�ΡG������������{�����e
    //�y�k�G
    //�׹��� �^�Ǹ������ ��k�W�� (�Ѽ�) { �{�����e }
    //�L�^�� void
    //�R�W�ߺD�GUnity ��k�H�j�g�}�Y
    //�ۭq��k�G���|����
    public void Test()
    {
        print("�ڬO���դ�k");
    }
    private void Start()
    {
        //�I�s��k
        //��k�W��();
        Test();
        Test();
        Drive90();
        Drive150();
        //�I�s��k�G�޼�
        Drive(70);
        Drive(200);
    }
    //���~�ݨD
    //���񭵮�
    //�T���i�[�t�A�ɳt�� 90
    //�T���i�[�t�A�ɳt�� 150
   public void Drive90()
   {
        print("�}���A�ɳt�G" + 90);
        print("����");
   }

    public void Drive150()
    {
        print("�}���A�ɳt�G" + 150);
        print("����");
    }

    //�w�q��k
    //�ѼơG������� �ѼƦW��
    public void Drive(int speed)
    {
        print("�}���A�ɳt�G" + speed);
        print("����");
    }
}
