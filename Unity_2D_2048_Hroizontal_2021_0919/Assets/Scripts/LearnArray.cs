using UnityEngine;

public class LearnArray : MonoBehaviour
{
    // ���Ӿǥͪ����� 
    public int score1 = 100;
    public int score2 = 90;
    public int score3 = 80;
    public int score4 = 65;
    public int score5 = 70;

    //�������[] - �}�C�������
    //�}�C�G�x�s�ۦP�������
    public int[] scores;
    // �w�q�@�ӥ]�t�ƶq���}�C
    public float[] attacks = new float[3];
    //�w�q�]�t�Ȫ��}�C
    public string[] props = { "����", "�Ť�","ī�G" };

    private void Start()
    {
        score3 = 60;

        //�s���}�C���
        //���o�}�C���
        //�y�k�G�}�C�W��[�s��] - �s���q0�}�l
        print("�ĤT�ӹD��G"+props[2]);
        // print("�ĤT�ӹD��G" + props[3]);  //OutOfRange �W�X�d����~
        //�]�w�}�C���
        //�y�k�G�}�C���W[�s��] ���w �� ;
        props[0] = "����";

        //�}�C�ƶq Length
        print("�D��ƶq:" + props.Length);

        //�Q�ΰj��]�w�}�C�� �G10 ~ 50
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = i * 10 + 10;
        }
    }
}
