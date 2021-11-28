using UnityEngine;
using UnityEngine.UI;
using System.Linq;


/// <summary>
/// 2048 �t��
/// �x�s�C�Ӱ϶����
/// �޲z�H���ͦ�
/// �ưʱ���
/// �Ʀr�X�֧P�w
/// �C������P�w
/// </summary>
public class System2048 : MonoBehaviour
{
    #region ���:���}
    [Header("�ťհ϶�")]
    public Transform[] blocksEmpty;
    [Header("�Ʀr�϶�")]
    public GameObject goNumberBlock;
    [Header("�e�� 2048")]
    public Transform traCavnas2048;
    #endregion

    #region ���:�p�H
    //�p�H�����ܦb�ݩʭ��O�W
    [SerializeField]
    private Direction direction;
    /// <summary>
    /// �Ҧ��϶����
    /// </summary>
    private BlockData[,] blocks = new BlockData[1, 4];

    /// <summary>
    /// ���U�y��
    /// </summary>
    private Vector3 posDown;
    /// <summary>
    /// ��}�y��
    /// </summary>
    private Vector3 posUP;
    /// <summary>
    /// �O�_���U����
    /// </summary>
    private bool isClickMouse;
    #endregion

    #region �ƥ�
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        CheckDirection();
    }
    #endregion

    #region ��k:�p�H
    /// <summary>
    /// ��l�Ƹ��
    /// </summary>
    private void Initialize()
    {
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                blocks[i, j] = new BlockData();
                blocks[i, j].v2Index = new Vector2Int(i, j);
                blocks[i, j].v2Position = blocksEmpty[i * blocks.GetLength(1) + j].position;
            }
        }

        printBlockData();
        CreateRandomNumberBlock();
        CreateRandomNumberBlock();
    }
    /// <summary>
    /// ��X�϶��G���}�C���
    /// </summary>
    private void printBlockData()
    {
        string result = "";

        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                //�s���B�Ʀr�P �y��
                //result += "�s��" + blocks[i, j].v2Index + " <color=green>�Ʀr�G" + blocks[i, j].number + "</color>" + blocks[i, j].v2Position + "|";
                //�s���B�Ʀr�P ����
                //�T���B��l
                //�y�k:���L�� ? �� A : �� B ;
                //���L�Ȭ� true ���G�� �� A
                //���L�Ȭ� false ���G�� �� b
                result += "�s��" + blocks[i, j].v2Index + " <color=red>�Ʀr�G" + blocks[i, j].number + "</color> <color=yellow>" +(blocks[i, j].goBlock ? "��" : "�@") + "</color> |";
            }
            result += "\n";
        }
        print(result);
    }
    /// <summary>
    /// �إ��H���Ʀr�϶�
    /// �P�_�Ҧ��϶����S���Ʀr���϶� - �Ʀr���s
    /// �H���D��@��
    /// �ͦ��Ʀr��b�Ӱ϶���
    /// </summary>
    private void CreateRandomNumberBlock()
    {
        var equalZero =
            from BlockData data in blocks
            where data.number == 0
            select data;

        print("���s����Ʀ��X���G" + equalZero.Count());

        int ranomIndex = Random.Range(0, equalZero.Count());
        print("�H���s���G" + ranomIndex);

        //��X�H���϶� �s��
        BlockData select = equalZero.ToArray()[ranomIndex];
        BlockData dataRandom = blocks[select.v2Index.x, select.v2Index.y];
        //�N�Ʀr 2��J���H���϶���
        dataRandom.number = 2;


        //��Ҥ� - �ͦ�(����A������)
        GameObject tempBlock = Instantiate(goNumberBlock, traCavnas2048);
        //�ͦ��϶� ���w�y��
        tempBlock.transform.position = dataRandom.v2Position;
        //�x�s �ͦ��϶� ��� 
        dataRandom.goBlock = tempBlock;

        printBlockData();
    }

    ///<summary>
    /// �ˬd��V
    /// </summary>
    private void CheckDirection()
    {
        #region ��L
        if (Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.Up;
            CheckAndBlock();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.Down;
            CheckAndBlock();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
            CheckAndBlock();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.Right;
            CheckAndBlock();
        }
        #endregion

        #region �ƹ��PĲ��
        if(!isClickMouse && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClickMouse = true;
            posDown = Input.mousePosition;
            //print("���U�y��"+posDown);
        }
        else if(isClickMouse && Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClickMouse = false;
            posUP = Input.mousePosition;
            //print("��}����"+posUP);

            // 1. �p��V�q�� ��}�y�� - ���U�y��
            Vector3 directionValue = posUP - posDown;
            //print("�V�q��:" + directionValue);
            // 2. �ഫ�� 0 ~ 1 ��
            //print("�ഫ���:" + directionValue.normalized);

            // ��V X �P Y �������
            float xAbs = Mathf.Abs(directionValue.normalized.x);
            float yAbs = Mathf.Abs(directionValue.normalized.y);
            // X > Y ������V
            if(xAbs > yAbs)
            {
                if (directionValue.normalized.x > 0) direction = Direction.Right;
                else direction = Direction.Left;
                CheckAndBlock();
            }
            // Y > X ������V
            if (yAbs > xAbs)
            {
                if (directionValue.normalized.y > 0) direction = Direction.Up;
                else direction = Direction.Down;
                CheckAndBlock();
            }
        }
        #endregion
    }

    private void CheckAndBlock()
    {
        print("�ثe����V:" + direction);
        switch (direction)
        {
            case Direction.Right:
                break;
            case Direction.Left:
                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    for (int j = 0; j < blocks.GetLength(1); j++)
                    {
                        BlockData blockOrinal = new BlockData();        //��l���Ʀr���϶�
                        BlockData blockCheck = new BlockData();         //�ˬd���䪺�϶�
                        bool canMove = false;                           //�O�_�i�H���ʰ϶�
                        bool sameNumber = false;                        //�O�_�ۦP�Ʀr
                        blockOrinal = blocks[i, j];

                        // �p�G �Ӱ϶����Ʀr ���s �N �~�� (���L���j�����U�Ӱj��)
                        if (blocks[i, j].number == 0) continue;

                        for (int k = j - 1; k >= 0; k--)
                        {
                            print("�ˬd����:" + k);

                            if (blocks[i, k].number == 0)
                            {
                                blockCheck = blocks[i, k];
                                canMove = true;
                            }
                            else if(blocks[i, k].number == blockOrinal.number)
                            {
                                blockCheck = blocks[i, k];
                                canMove = true;
                                sameNumber = true;
                            }
                        }

                        if (canMove)
                        {
                            // �N�쥻�����󲾰ʨ��ˬd�Ʀr���s���϶�����
                            //�N�쥻�Ʀr�k�s�A�ˬd�Ʀr�ɤW
                            //�N�쥻������M�šA�ˬd����ɤW
                            blockOrinal.goBlock.transform.position = blockCheck.v2Position;

                            if (sameNumber)
                            {
                                int number = blockCheck.number * 2;
                                blockCheck.number = number;

                                Destroy(blockOrinal.goBlock);
                                blockCheck.goBlock.transform.transform.Find("�Ʀr").GetComponent<Text>().text = number.ToString();
                            }
                            else
                            {
                                blockCheck.number = blockOrinal.number;
                                blockCheck.goBlock = blockOrinal.goBlock;
                            }
                            blockOrinal.number = 0;
                            blockOrinal.goBlock = null;
                        }
                    }
                }

                printBlockData();

                break;
            case Direction.Up:
                break;
            case Direction.Down:
                break;
        }
    }
#endregion

    /// <summary>
    /// �϶����
    /// �C�Ӱ϶��C������B�y�СB�s���B�Ʀr
    /// </summary>
    public class BlockData
    {
        /// <summary>
        /// �϶������Ʀr����
        /// </summary>
        public GameObject goBlock;
        /// <summary>
        /// �϶��y��
        /// </summary>
        public Vector2 v2Position;
        /// <summary>
        /// �϶��s���G�G���}�C�����s��
        /// </summary>
        public Vector2Int v2Index;
        /// <summary>
        /// �϶��Ʀr�G�w�]��0�A�Ϊ� 2�B4�B8........2048
        /// </summary>
        public int number;
    }
    
    public enum Direction
    {
        None, Right, Left, Up, Down
    }
}