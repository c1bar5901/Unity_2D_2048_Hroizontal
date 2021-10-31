
using UnityEngine;
/// <summary>
/// summary 摘要
/// 資料說明， 顯示在 VS編譯器提示上
/// </summary>
public class LearnMethod : MonoBehaviour
{
    //方法 Mothod 、 Function (函式)
    //作用：執行較複雜的程式內容
    //語法：
    //修飾詞 傳回資料類型 方法名稱 (參數) { 程式內容 }
    //無傳回 void
    //命名習慣：Unity 方法以大寫開頭
    //自訂方法：不會執行
    public void Test()
    {
        print("我是測試方法");
    }
    private void Start()
    {
        //呼叫方法
        //方法名稱();
        Test();
        Test();
        Drive90();
        Drive150();
        //呼叫方法：引數
        //有預設值的參數可以不填寫，使用預設值
        Drive(70);
        Drive(200,"轟轟轟");
        Drive(300);
        //時數 50，預設音效，石頭
        //指定預設值參數語法 參數名稱 冒號 值
        Drive(50, effect:"石頭") ;

        int t = Ten();
        print("傳回方法值：" + t);

        print("不使用變數儲存傳回值："+Ten());

        int damage = Damage(90, 30);
        print("90 攻擊力 30防禦力的傷害：" + damage);
    }
    //企業需求
    //撥放音效
    //汽車可加速，時速為 90
    //汽車可加速，時速為 150
   public void Drive90()
   {
        print("開車，時速：" + 90);
        print("音效");
   }

    public void Drive150()
    {
        print("開車，時速：" + 150);
        print("音效");
    }

    //定義方法
    //參數：資料類型 參數名稱
    public void Drive(int speed, string sound = "咻咻咻", string effect = "灰塵")
    {
        print("開車，時速：" + speed);
        print("音效"+sound);
        print("特效" + effect);
    }
    public int Ten()
    {
        return 10;
    }

    //90-30=60
    //非必要但很重要!
    /// <summary>
    /// 計算傷害值，攻擊力 - 防禦力 = 傷害值
    /// </summary>
    /// <param name="attack">攻擊力</param>
    /// <param name="defence">防禦力</param>
    /// <returns>傷害值</returns>
    public int Damage(int attack, int defence)
    {
        return attack - defence;
    }
}
