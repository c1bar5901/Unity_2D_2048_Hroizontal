using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnProrerty : MonoBehaviour
{
    //���
    public int passwordField = 123456789;

    //�ݩ�
    //�y�k:
    //�׹��� ������� �ݩʦW�� {�s���l}
    //prop + Tab*2 �۰ʹ�@
    public int passwordProperty { get; set; }
    // get ���o 
    // set �˩w
    // => �H�ڹF Lambda C#6.0
    public int mypasswordProperty { get => 999; }
    //get �ݨϥ�����r return �^��
    public string nameCharacter
    {
        get
        { 
            print("�ڦb�ݩ� name Character ��");
            return "Finn";
        }
    }
    public float attack
    {
        set
        {
            print("�����O:" + value);
        }
    }
    //�}�l�ƥ� :����C���ɰ���@��
    private void Start()
    {
        //�s�� Set �ݩʭ�
        //�y�k:
        //�ݩʸ�� ���w �� ;
        passwordProperty = 777;
        //���o Get �ݩʸ�� 
        //�y�k:
        //print(�ݩʦW��)
        print("�ݩʱK�X:" + passwordProperty);

        //mypasswordProperty = 999;  //����]�w  ��Ū�ݩ�
        print("�ڪ��ݩʱK�X:" + mypasswordProperty);

        print(nameCharacter);

        //print(attack);            //������o �߼g�ݩ�
        attack = 99.9f;
    }
}
