using UnityEngine;

/// <summary>
/// 認識二維陣列
/// </summary>
public class Learn2DArray : MonoBehaviour
{
    //一維陣列
    public int[] numbers = { 1, 7, 9, 10, 50 };
    //二維陣列
    public int[,] blocks = { { 2, 4 }, { 6, 8 } };

    public string[,] objects = new string[4, 6];

    public int[,] scores = { { 48, 44 }, { 56, 28 }, { 10, 20 } };

    private void Start()
    {
        //一維陣列存取
        numbers[4] = 99;
        print("一維陣列第五筆資料：" + numbers[4]);
        //二維陣列存取
        print("二維陣列第二列第二欄：" + blocks[1, 1]);
        blocks[1, 1] = 11;
        print("二維陣列第二列第二欄：" + blocks[1, 1]);

        print("二維陣列第一維長度：" + scores.GetLength(0));
        print("二維陣列第一維長度：" + scores.GetLength(1));

        string result = "";
            for (int i = 0; i < scores.GetLength(0); i++)
        {
            for (int j = 0; j < scores.GetLength(1); j++)
            {
                result += scores[i, j] + "|";
            }
            result += "\n";
        }
        print(result);
    }
}
