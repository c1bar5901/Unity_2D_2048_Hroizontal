
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

        #region
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
    }
}
