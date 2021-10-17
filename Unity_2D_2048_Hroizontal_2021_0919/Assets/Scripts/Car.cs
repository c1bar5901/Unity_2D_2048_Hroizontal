
using UnityEngine;      //引用    UnityEngine API

//class 類別(藍圖)
public class Car : MonoBehaviour
{
    #region 欄位語法與四大基本類型
    //-----------欄位 Field , 儲存資料--------------
    //語法:
    //修飾詞 類別 欄位名稱 指定 預設值 結束符號
    //-------------常用基本四大類型---------------
    //整數    int     :沒有小數點的數字   預設值0
    //浮點數  float   :有小數點的數字     預設值0
    //字串    string  :文字               預設值空
    //布林值  bool    :是與否 true&false  預設值false
    //-----------------修飾詞---------------------
    //私人    private  :僅限此類別存取   Unity (預設)  
    //公開    public   :所有類別皆可存取
    //----------------------------------------------------//
    //欄位屬性 Attritube
    //語法:
    //[屬性名稱(值)] - 必須放在欄位前面一行或上一行
    //1. 標題  Header  (字串)
    //2. 提示  Tooltip (字串)
    //3. 範圍  Range   (浮點數,浮點數)
    [Header("汽車性質")]
    [Tooltip("汽車的CC數")][Range(1000,5000)]
    public int cc = 2000;
    [Tooltip("汽車的重量,範圍是 3 ~ 20"), Range(3, 20)]
    public float weight = 3.5f;
    [Tooltip("汽車的品牌")]
    public string brand = "賓士";
    [Tooltip("汽車是否有天窗")]
    public bool hasSkywindow = true;
    #endregion

    #region  遊戲內常用資料類型
    //顏色    Color
    [Header("顏色")]
    public Color color1;
    public Color colorRed = Color.red;      //預設紅色
    public Color color1Custom = new Color(0, 0, 1);         //RGB
    public Color colorCusAlpga = new Color(0, 1, 0, 0.3f);  //RGBA
    //座標   Vector
    // Vector   2 - 4
    [Header("座標")]
    public Vector2 v2;      //預設為0,0
    public Vector2 v2One = Vector2.one;     //預設為1,1
    public Vector2 v2Up = Vector2.up;       //預設為0,1(向上)
    public Vector2 v2Custom = new Vector2(7, 9);    
    public Vector3 v3Custom = new Vector3(1, 2, 3);
    public Vector4 v4Custom = new Vector4(1, 2, 3, 4);
    //按鍵 KeyCode
    [Header("按鍵")]
    public KeyCode kc;   //預設為0
    public KeyCode kcW = KeyCode.W;     //預設為W
    public KeyCode kcML = KeyCode.Mouse0;   //預設為滑鼠左鍵
    //遊戲物件 GameObject 不需要指定值
    [Header("遊戲物件")]
    [Tooltip("存放箱型車")]
    public GameObject carBox;
    [Tooltip("存放油罐車")]
    public GameObject carOil;
    //元件 Component 不需要指定值
    [Header("元件")]
    public Transform traBox;
    public SpriteRenderer sprBox;
    [Tooltip("攝影機")]
    public Camera cam;

    #endregion
}
