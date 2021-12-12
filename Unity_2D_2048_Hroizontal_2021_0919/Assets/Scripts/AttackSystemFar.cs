using UnityEngine;

/// <summary>
/// �����t�ΡG���Z��
/// �~�ӻy�k�G �l���O : �n�~�Ӫ����O(�����O)
/// �֦������O�������G���B�ݩʡB��k�B�ƥ�
/// </summary>
public class AttackSystemFar : AttackSystem
{
    [Header("�ͦ��ɤl��m")]
    public Transform positionSpawn;
    [Header("�����ɤl")]
    public GameObject goAttackParticle;
    [Header("�ɤl���ʳt��")]
    public float speed = 500;

    // override �Ƽg : �Ƽg�����O virtual ����
    public override void Attack()
    {
        base.Attack();      //base �� : �����O�����e

        print("���Z����");

        // �ͦ�(����B�y�СB����)
        // �ͦ�������W�٫��|�� (clone)
        // Ouaternion �|����
        // identity �s����
        GameObject tempAttack = Instantiate(goAttackParticle, positionSpawn.position, Quaternion.identity);
        tempAttack.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
    }
}
