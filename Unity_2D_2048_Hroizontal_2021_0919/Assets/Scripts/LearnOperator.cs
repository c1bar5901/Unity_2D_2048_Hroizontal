
using UnityEngine;

/// <summary>
/// �{�ѹB��l
/// 1. ���w
/// 2. �ƾ�
/// 3. ���
/// 4. �޿�
/// </summary>
public class LearnOperator : MonoBehaviour
{
    public float a = 10;
    public float b = 3;
    public float c = 30;
    public int hp = 100;
    private void Start()
    {
        #region ���w�B��l
        // ���w = 
        //��������w�B��l�k��b���w������
        #endregion

        #region �ƾǹB��l
        //�[����l
        //+ - * / %
        print("�[�k" + (a + b));      //���G 13
        print("��k" + (a - b));      //���G 7
        print("���k" + (a * b));      //���G 30
        print("���k" + (a / b));      //���G 3.33333
        print("�l��" + (a % b));      //���G 1

        c = c + 1;                    //��l�g�k
        print("c ���G�G" + c);
        c++;                          //���W ++�A���� --
        print("c ���G�G" + c);

        hp = hp + 10;
        print("HP ���G�G" + hp);
        hp += 10;                     //�O�μƾǹB��l += -= /= %=
        print("HP ���G�G" + hp);
        #endregion

        #region ����B��l
        //�j��B�p��B�j�󵥩�B�p�󵥩�B����B������
        // >     <     >=        <=     ==    !=
        //�����ӭȡA�åB�o�쥬�L�ȵ��G

        print("a > b" + (a > b));    //t
        print("a > b" + (a < b));    //f
        print("a > b" + (a >= b));   //t
        print("a > b" + (a <= b));   //f
        print("a > b" + (a == b));   //f
        print("a > b" + (a != b));   //t
        #endregion

        #region
        //�åB�B�Ϊ̡B�A��
        // &&   ||    !
        //�åB�B�Ϊ�
        //�����ӥ��L�ȡA�åB�o�쥬�L�ȵ��G
        //�åB�G�u�n���@�� f ���G�N�O f
        print("t && t" + (true && true));       //t
        print("f && t" + (false && true));       //f
        print("t && f" + (true && false));       //f
        print("f && f" + (false && false));       //f
        //�Ϊ̡G�u�n���@�� t ���G�N�O t
        print("t || t" + (true || true));       //t
        print("f || t" + (false || true));       //t
        print("t || f" + (true || false));       //t
        print("f || f" + (false || false));       //f
        //Alt + Shift + > �ֳtŪ��

        //�A�ˡG�u��Φb���L��
        print(!true);               //f
        print(!(a > b));            //f
        print(!(true && true));      //f


        #endregion
    }
}