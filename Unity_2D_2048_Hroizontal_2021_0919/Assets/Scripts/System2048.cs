using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

/// <summary>
/// 2048 系統
/// 儲存每個區塊資料
/// 管理隨機生成
/// 滑動控制
/// 數字合併判定
/// 遊戲機制判定
/// </summary>
public class System2048 : MonoBehaviour
{
    #region 欄位:公開
    [Header("空白區塊")]
    public Transform[] blocksEmpty;
    [Header("數字區塊")]
    public GameObject goNumberBlock;
    [Header("畫布 2048")]
    public Transform traCavnas2048;
    #endregion

    #region 欄位:私人
    //私人欄位顯示在屬性面板上
    [SerializeField]
    private Direction direction;
    /// <summary>
    /// 所有區塊資料
    /// </summary>
    private BlockData[,] blocks = new BlockData[4, 4];

    /// <summary>
    /// 按下座標
    /// </summary>
    private Vector3 posDown;
    /// <summary>
    /// 放開座標
    /// </summary>
    private Vector3 posUP;
    /// <summary>
    /// 是否按下左鍵
    /// </summary>
    private bool isClickMouse;
    #endregion

    #region 事件
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        CheckDirection();
    }
    #endregion

    #region 方法:私人
    /// <summary>
    /// 初始化資料
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
    /// 輸出區塊二維陣列資料
    /// </summary>
    private void printBlockData()
    {
        string result = "";

        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            for (int j = 0; j < blocks.GetLength(1); j++)
            {
                //編號、數字與 座標
                //result += "編號" + blocks[i, j].v2Index + " <color=green>數字：" + blocks[i, j].number + "</color>" + blocks[i, j].v2Position + "|";
                //編號、數字與 物件
                result += "編號" + blocks[i, j].v2Index + " <color=green>數字：" + blocks[i, j].number + "</color> < color = red >" +blocks[i, j].goBlock + "</color> |";
            }
            result += "\n";
        }
        print(result);
    }
    /// <summary>
    /// 建立隨機數字區塊
    /// 判斷所有區塊內沒有數字的區塊 - 數字為零
    /// 隨機挑選一個
    /// 生成數字放在該區塊內
    /// </summary>
    private void CreateRandomNumberBlock()
    {
        var equalZero =
            from BlockData data in blocks
            where data.number == 0
            select data;

        print("為零的資料有幾筆：" + equalZero.Count());

        int ranomIndex = Random.Range(0, equalZero.Count());
        print("隨機編號：" + ranomIndex);

        //選出隨機區塊 編號
        BlockData select = equalZero.ToArray()[ranomIndex];
        BlockData dataRandom = blocks[select.v2Index.x, select.v2Index.y];
        //將數字 2輸入到隨機區塊內
        dataRandom.number = 2;

        printBlockData();

        //實例化 - 生成(物件，父物件)
        GameObject tempBlock = Instantiate(goNumberBlock, traCavnas2048);
        //生成區塊 指定座標
        tempBlock.transform.position = dataRandom.v2Position;
        //儲存 生成區塊 資料 
        dataRandom.goBlock = tempBlock;
    }

    ///<summary>
    /// 檢查方向
    /// </summary>
    private void CheckDirection()
    {
        #region 鍵盤
        if (Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.Up;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.Down;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.Right;
        }
        #endregion

        #region 滑鼠與觸控
        if(!isClickMouse && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClickMouse = true;
            posDown = Input.mousePosition;
            print("按下座標"+posDown);
        }
        else if(isClickMouse && Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClickMouse = false;
            posUP = Input.mousePosition;
            print("放開左鍵"+posUP);

            // 1. 計算向量值 放開座標 - 按下座標
            Vector3 directionValue = posUP - posDown;
            print("向量值:" + directionValue);
            // 2. 轉換成 0 ~ 1 值
            print("轉換後值:" + directionValue.normalized);

            // 方向 X 與 Y 取絕對值
            float xAbs = Mathf.Abs(directionValue.x);
            float yAbs = Mathf.Abs(directionValue.y);
            // X > Y 水平方向
            if(xAbs > yAbs)
            {
                print("水平方向");
            }
            // Y > X 垂直方向
            if (yAbs > xAbs)
            {
                print("垂直方向");
            }
        }

        
        #endregion
    }
#endregion

    /// <summary>
    /// 區塊資料
    /// 每個區塊遊戲物件、座標、編號、數字
    /// </summary>
    public class BlockData
    {
        /// <summary>
        /// 區塊內的數字物件
        /// </summary>
        public GameObject goBlock;
        /// <summary>
        /// 區塊座標
        /// </summary>
        public Vector2 v2Position;
        /// <summary>
        /// 區塊編號：二維陣列內的編號
        /// </summary>
        public Vector2Int v2Index;
        /// <summary>
        /// 區塊數字：預設維0，或者 2、4、8........2048
        /// </summary>
        public int number;
    }
    
    public enum Direction
    {
        None, Right, Left, Up, Down
    }
}