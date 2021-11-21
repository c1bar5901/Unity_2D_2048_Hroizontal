using UnityEngine;

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
    [Header("�ťհ϶�")]
    public Transform[] blocksEmpty;
    /// <summary>
    /// �Ҧ��϶����
    /// </summary>
    public BlockData[,] blocks = new BlockData[4, 4];

    private void Start()
    {
        Initialize();
    }

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
    }

    private void printBlockData()
    {
        string result = "";

        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                result += "�s��(" + blocks[i,j].v2Index + ")" + "<color=green>�Ʀr�G" + blocks[i,j].number + "</color>" +blocks[i, j].v2Position + "|";
            }
            result += "\n";
        }
        print(result);
    }
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
}