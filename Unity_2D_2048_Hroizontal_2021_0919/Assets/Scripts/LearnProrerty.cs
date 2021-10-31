using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnProrerty : MonoBehaviour
{
    //欄位
    public int passwordField = 123456789;

    //屬性
    //語法:
    //修飾詞 資料類型 屬性名稱 {存取子}
    //prop + Tab*2 自動實作
    public int passwordProperty { get; set; }
    // get 取得 
    // set 捨定
    // => 黏巴達 Lambda C#6.0
    public int mypasswordProperty { get => 999; }
    //get 需使用關鍵字 return 回傳
    public string nameCharacter
    {
        get
        { 
            print("我在屬性 name Character 內");
            return "Finn";
        }
    }
    public float attack
    {
        set
        {
            print("攻擊力:" + value);
        }
    }
    //開始事件 :播放遊戲時執行一次
    private void Start()
    {
        //存取 Set 屬性值
        //語法:
        //屬性資料 指定 值 ;
        passwordProperty = 777;
        //取得 Get 屬性資料 
        //語法:
        //print(屬性名稱)
        print("屬性密碼:" + passwordProperty);

        //mypasswordProperty = 999;  //不能設定  唯讀屬性
        print("我的屬性密碼:" + mypasswordProperty);

        print(nameCharacter);

        //print(attack);            //不能取得 唯寫屬性
        attack = 99.9f;
    }
}
