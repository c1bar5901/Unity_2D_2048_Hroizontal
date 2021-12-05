using UnityEngine;
using UnityEngine.UI;
using System.Linq;


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
                //三元運算子
                //語法:布林值 ? 值 A : 值 B ;
                //當布林值為 true 結果為 值 A
                //當布林值為 false 結果為 值 b
                result += "編號" + blocks[i, j].v2Index + " <color=red>數字：" + blocks[i, j].number + "</color> <color=yellow>" +(blocks[i, j].goBlock ? "有" : "一") + "</color> |";
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


        //實例化 - 生成(物件，父物件)
        GameObject tempBlock = Instantiate(goNumberBlock, traCavnas2048);
        //生成區塊 指定座標
        tempBlock.transform.position = dataRandom.v2Position;
        //儲存 生成區塊 資料 
        dataRandom.goBlock = tempBlock;

        printBlockData();
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
            CheckAndMoveBlock();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.Down;
            CheckAndMoveBlock();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
            CheckAndMoveBlock();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.Right;
            CheckAndMoveBlock();
        }
        #endregion

        #region 滑鼠與觸控
        if(!isClickMouse && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isClickMouse = true;
            posDown = Input.mousePosition;
            //print("按下座標"+posDown);
        }
        else if(isClickMouse && Input.GetKeyUp(KeyCode.Mouse0))
        {
            isClickMouse = false;
            posUP = Input.mousePosition;
            //print("放開左鍵"+posUP);

            // 1. 計算向量值 放開座標 - 按下座標
            Vector3 directionValue = posUP - posDown;
            //print("向量值:" + directionValue);
            // 2. 轉換成 0 ~ 1 值
            //print("轉換後值:" + directionValue.normalized);

            // 方向 X 與 Y 取絕對值
            float xAbs = Mathf.Abs(directionValue.normalized.x);
            float yAbs = Mathf.Abs(directionValue.normalized.y);
            // X > Y 水平方向
            if(xAbs > yAbs)
            {
                if (directionValue.normalized.x > 0) direction = Direction.Right;
                else direction = Direction.Left;
                CheckAndMoveBlock();
            }
            // Y > X 垂直方向
            if (yAbs > xAbs)
            {
                if (directionValue.normalized.y > 0) direction = Direction.Up;
                else direction = Direction.Down;
                CheckAndMoveBlock();
            }
        }
        #endregion
    }

    private void CheckAndMoveBlock()
    {
        print("目前的方向:" + direction);
        BlockData blockOrinal = new BlockData();        //原始有數字的區塊
        BlockData blockCheck = new BlockData();         //檢查旁邊的區塊
        bool canMove = false;                           //是否可以移動區塊
        bool sameNumber = false;                        //是否相同數字
   

        switch (direction)
        {
            case Direction.Right:
                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    for (int j = blocks.GetLength(1)-2; j >= 0; j--)
                    {
                        blockOrinal = blocks[i, j];

                        // 如果 該區塊的數字 為零 就 繼續 (跳過此迴圈執行下個迴圈)
                        if (blockOrinal.number == 0) continue;
                        for (int k = j + 1; k < blocks.GetLength(1); k++)
                        {
                            if (blocks[i, k].number == 0)
                            {
                                blockCheck = blocks[i, k];
                                canMove = true;
                            }
                            else if (blocks[i, k].number == blockOrinal.number)
                            {
                                blockCheck = blocks[i, k];
                                canMove = true;
                                sameNumber = true;
                            }
                            //否則 如果 檢查區塊 的數字 與 原本區塊 的數字 不相同 就不移動、數字不相同並中斷
                            else if (blocks[i, k].number != blockOrinal.number)
                            {
                                canMove = false;
                                sameNumber = false;
                                break;
                            }
                        }

                        //如果 可以移動 在執行 移動區塊(開始，檢查，是否相同數字)
                        if (canMove) MoveBlock(blockOrinal, blockCheck, sameNumber);
                        {

                        }
                    }
                }

                break;
            case Direction.Left:
                for (int i = 0; i < blocks.GetLength(0); i++)
                {
                    for (int j = 1; j < blocks.GetLength(1); j++)
                    {
                        blockOrinal = blocks[i, j];

                        // 如果 該區塊的數字 為零 就 繼續 (跳過此迴圈執行下個迴圈)
                        if (blocks[i, j].number == 0) continue;

                        for (int k = j - 1; k >= 0; k--)
                        {
                            print("檢查次數:" + k);

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

                        //如果 可以移動 在執行 移動區塊(開始，檢查，是否相同數字)
                        if (canMove) MoveBlock(blockOrinal, blockCheck, sameNumber);
                        {
                            
                        }
                    }
                }

                printBlockData();

                break;
            case Direction.Up:
                for (int i = 0; i < blocks.GetLength(1); i++)
                {
                    for (int j = 1; j < blocks.GetLength(0); j++)
                    {
                        blockOrinal = blocks[j, i];

                        // 如果 該區塊的數字 為零 就 繼續 (跳過此迴圈執行下個迴圈)
                        if (blockOrinal.number == 0) continue;

                        for (int k = j - 1; k >= 0; k--)
                        {
                            print("檢查次數:" + k);

                            if (blocks[k, i].number == 0)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                            }
                            else if (blocks[k, i].number == blockOrinal.number)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                                sameNumber = true;
                            }
                        }

                        //如果 可以移動 在執行 移動區塊(開始，檢查，是否相同數字)
                        if (canMove) MoveBlock(blockOrinal, blockCheck, sameNumber);
                        {

                        }
                    }
                }

                break;
            case Direction.Down:

                for (int i = 0; i < blocks.GetLength(1); i++)
                {
                    for (int j = blocks.GetLength(0) - 2; j >= 0 ; j--)
                    {
                        blockOrinal = blocks[j, i];

                        // 如果 該區塊的數字 為零 就 繼續 (跳過此迴圈執行下個迴圈)
                        if (blockOrinal.number == 0) continue;

                        for (int k = j + 1; k < blocks.GetLength(0); k++)
                        {
                            if (blocks[k, i].number == 0)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                            }
                            else if (blocks[k, i].number == blockOrinal.number)
                            {
                                blockCheck = blocks[k, i];
                                canMove = true;
                                sameNumber = true;
                            }
                        }

                        //如果 可以移動 在執行 移動區塊(開始，檢查，是否相同數字)
                        if (canMove) MoveBlock(blockOrinal, blockCheck, sameNumber);
                    }
                }
                break;
        }                           //移動後 生成下一顆區塊

        CreateRandomNumberBlock();
    }
#endregion

/// <summary>
/// 移動區塊
/// </summary>
/// <param name="blockOrinal">原始的區塊，要被移動的</param>
/// <param name="blockCheck">檢查的區塊，原始區塊旁邊的區塊</param>
/// <param name="sameNumber">是否相同數字</param>
private void MoveBlock(BlockData blockOrinal,BlockData blockCheck,bool sameNumber)
    {
        // 將原本的物件移動到檢查數字為零的區塊旁邊
        //將原本數字歸零，檢查數字補上
        //將原本的物件清空，檢查物件補上
        blockOrinal.goBlock.transform.position = blockCheck.v2Position;

        if (sameNumber)
        {
            int number = blockCheck.number * 2;
            blockCheck.number = number;

            Destroy(blockOrinal.goBlock);
            blockCheck.goBlock.transform.transform.Find("數字").GetComponent<Text>().text = number.ToString();
        }
        else
        {
            blockCheck.number = blockOrinal.number;
            blockCheck.goBlock = blockOrinal.goBlock;
        }
        blockOrinal.number = 0;
        blockOrinal.goBlock = null;
    }
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