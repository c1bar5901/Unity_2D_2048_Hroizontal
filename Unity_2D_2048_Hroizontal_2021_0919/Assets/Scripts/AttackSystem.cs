using UnityEngine;

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
    #endregion

    #region ��k : ���}
    // virtual ���� : ���\�l���O�Ƽg
    /// <summary>
    /// ������k
    /// </summary>
    public virtual void Attack()
    {
        print("�o�ʧ����A�����O���G" + attack);
    }
    #endregion  
}
