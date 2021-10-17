
using UnityEngine;      //�ޥ�    UnityEngine API

//class ���O(�Ź�)
public class Car : MonoBehaviour
{
    #region ���y�k�P�|�j������
    //-----------��� Field , �x�s���--------------
    //�y�k:
    //�׹��� ���O ���W�� ���w �w�]�� �����Ÿ�
    //-------------�`�ΰ򥻥|�j����---------------
    //���    int     :�S���p���I���Ʀr   �w�]��0
    //�B�I��  float   :���p���I���Ʀr     �w�]��0
    //�r��    string  :��r               �w�]�Ȫ�
    //���L��  bool    :�O�P�_ true&false  �w�]��false
    //-----------------�׹���---------------------
    //�p�H    private  :�ȭ������O�s��   Unity (�w�])  
    //���}    public   :�Ҧ����O�ҥi�s��
    //----------------------------------------------------//
    //����ݩ� Attritube
    //�y�k:
    //[�ݩʦW��(��)] - ������b���e���@��ΤW�@��
    //1. ���D  Header  (�r��)
    //2. ����  Tooltip (�r��)
    //3. �d��  Range   (�B�I��,�B�I��)
    [Header("�T���ʽ�")]
    [Tooltip("�T����CC��")][Range(1000,5000)]
    public int cc = 2000;
    [Tooltip("�T�������q,�d��O 3 ~ 20"), Range(3, 20)]
    public float weight = 3.5f;
    [Tooltip("�T�����~�P")]
    public string brand = "���h";
    [Tooltip("�T���O�_���ѵ�")]
    public bool hasSkywindow = true;
    #endregion

    #region  �C�����`�θ������
    //�C��    Color
    [Header("�C��")]
    public Color color1;
    public Color colorRed = Color.red;      //�w�]����
    public Color color1Custom = new Color(0, 0, 1);         //RGB
    public Color colorCusAlpga = new Color(0, 1, 0, 0.3f);  //RGBA
    //�y��   Vector
    // Vector   2 - 4
    [Header("�y��")]
    public Vector2 v2;      //�w�]��0,0
    public Vector2 v2One = Vector2.one;     //�w�]��1,1
    public Vector2 v2Up = Vector2.up;       //�w�]��0,1(�V�W)
    public Vector2 v2Custom = new Vector2(7, 9);    
    public Vector3 v3Custom = new Vector3(1, 2, 3);
    public Vector4 v4Custom = new Vector4(1, 2, 3, 4);
    //���� KeyCode
    [Header("����")]
    public KeyCode kc;   //�w�]��0
    public KeyCode kcW = KeyCode.W;     //�w�]��W
    public KeyCode kcML = KeyCode.Mouse0;   //�w�]���ƹ�����
    //�C������ GameObject ���ݭn���w��
    [Header("�C������")]
    [Tooltip("�s��c����")]
    public GameObject carBox;
    [Tooltip("�s��o����")]
    public GameObject carOil;
    //���� Component ���ݭn���w��
    [Header("����")]
    public Transform traBox;
    public SpriteRenderer sprBox;
    [Tooltip("��v��")]
    public Camera cam;

    #endregion
    #region �s������� Set Get
    //�{���J�f : �ƥ�
    //�}�l�ƥ� :����C���ɰ���@�� , ��l�]�w
    private void Start()
    {
        print("���OWWWWWWWW");
        //���o Get ����� ���w�]�ȥH�ݩʭ��O���D (Inspector)
        //�y�k:
        //print(�����)
        print("CC��:" + cc);
        print(weight);
        //�s�� Set �����
        //�y�k:
        //����� ���w �� ;
        brand = ("BMW");
        hasSkywindow = false;
        
    }
    #endregion
}
