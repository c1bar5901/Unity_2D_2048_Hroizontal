using UnityEngine;
using UnityEngine.UI;

public class HealthSydtem : MonoBehaviour
{
    [Header("��q"), Range(0, 500)]
    public float hp = 100;
    [Header("�n�����q�P���")]
    public Text textHp;
    public Image imgHp;
    [Header("�y���ˮ`���������")]
    public string tagDamageObject;
    [Header("�ʵe�Ѽ�")]
    public string parameterDamage = "����Ĳ�o";
    public string parameterDead = "���`Ĳ�o";

    private float hpMax;
    private Animator ani;

    //����ƥ� :�b Start ���e����@���A�B�z��l��
    private void Awake()
    {
        hpMax = hp;
        ani = GetComponent<Animator>();
    }

    private void Start()
    {
        textHp.text = "HP" + hp;
        imgHp.fillAmount = 1;
    }

    // �I���ƥ� : ��ӸI�����䤤�@�Ӧ��Ŀ� Is Trigger
    // Enter �I���}�l�ɰ��榹�ƥ�@��
    // collision �I�쪫�󪺸I����T
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �p�G �I�쪺���� �O �y���ˮ`�������
        if (collision.tag == tagDamageObject) Hurt(10);
        {
            // ����(�y���ˮ`���� �l�u�t�� �� �����O)
            {
                Hurt(collision.GetComponent<Bullet>().attack);
            }
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damage">�����쪺�ˮ`</param>
    public void Hurt(float damage)
    {
        if (hp <= 0) return;                //�p�G���`�h�h�X

        hp -= damage;
        hp = Mathf.Clamp(hp, 0, hpMax);     //����(hp, �̤p, �̤j)
        textHp.text = "HP" + hp;
        imgHp.fillAmount = hp / hpMax;
        ani.SetTrigger(parameterDamage);
        if (hp <= 0) Dead();
    }

    /// <summary>
    /// ���`
    /// </summary>
    private void Dead()
    {
        ani.SetTrigger(parameterDead);
    }
}