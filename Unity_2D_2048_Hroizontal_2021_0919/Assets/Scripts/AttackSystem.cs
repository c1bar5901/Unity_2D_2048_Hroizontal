using UnityEngine;
using UnityEngine.UI;
using System.Collections;   //�ޥ� �t�� ���X API : ��P�{�� Coroutine
using UnityEngine.Events;

/// <summary>
/// �����t��
/// </summary>
public class AttackSystem : MonoBehaviour
{
    #region ��� : ���}
    [Header("�����O��")]
    public float attack = 10;
    [Header("�����ؼ�")]
    public GameObject goTarget;
    [Header("�����O����")]
    public Text textAttack;
    [Header("�������"), Range(0, 10)]
    public float delayAttack = 3.5f;
    [Header("����ǰe�ˮ`"), Range(0, 5)]
    public float delaysendDamage = 0.5f;
    [Header("�ʵe�Ѽ�")]
    public string parameterAttack = "����Ĳ�o";
    #endregion

    #region ��� : �O�@ protected
    // public ���\�������O�s��
    // private ���\�����O�s��
    // protected ���\�l���O�s��
    protected HealthSydtem targetHealthSystem;
    protected Animator ani;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        textAttack.text = "ATK" + attack;
        ani = GetComponent<Animator>();
        targetHealthSystem = goTarget.GetComponent<HealthSydtem>();
    }
    #endregion

    [Header("���������ƥ�")]
    public UnityEvent onAttackFinish;

    #region ��k : ���}
    // virtual ���� : ���\�l���O�Ƽg
    /// <summary>
    /// ������k
    /// </summary>
    public virtual void Attack()
    {
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        // ���� 3.5 ��
        yield return new WaitForSeconds(delayAttack);
        //�����ʵe
        ani.SetTrigger(parameterAttack);
        // ���� 0.5 ��
        yield return new WaitForSeconds(delaysendDamage);
        // �ǰe�ˮ`
        targetHealthSystem.Hurt(attack);
        onAttackFinish.Invoke();
    }
    #endregion  
}
