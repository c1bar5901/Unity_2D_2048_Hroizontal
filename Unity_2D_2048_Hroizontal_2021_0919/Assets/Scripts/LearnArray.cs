using UnityEngine;

public class LearnArray : MonoBehaviour
{
    // 五個學生的分數 
    public int score1 = 100;
    public int score2 = 90;
    public int score3 = 80;
    public int score4 = 65;
    public int score5 = 70;

    //資料類型[] - 陣列資料類型
    //陣列：儲存相同資料類型
    public int[] scores;

    private void Start()
    {
        score3 = 60;
    }
}
