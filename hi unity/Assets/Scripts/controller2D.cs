using UnityEngine;

/// <summary>
/// ����G2D ��V���b����
/// </summary>


public class controller2D : MonoBehaviour
{
    #region ���G���}
    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float jump = 300f;
    [Header("�ˬd�a�O�ؤo�P�첾"), Range(0, 1)]
    //��@��Header�����Ƽƭ����A�B���ݭn������Range�A�hRange��b�~��
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;

    //���餸��
    private Rigidbody2D rig;
    #endregion

    /// <summary>
    /// ø�s�ϥ�
    /// �b Unity ø�s���U�ιϥ�
    /// �u���B�g�u�B��ΡB��ΡB���ΡB�Ϥ�
    /// </summary>

    private void OnDrawGizmos()
    {
        //1.�M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        //2.�M�wø�s�ϧ�
        Gizmos.DrawSphere(transform.position + 
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }

    #region Void
    //void = �I�s
    //Start �u�|����@��
    //public = ���}���A�|�X�{�bUnity��
    //private = �p�H���A���|�X�{�bUnity��
    private void Start()
    {
        //������� = ���o����<2D ����>()
         rig = GetComponent<Rigidbody2D>(); 
    }

    ///<summary>
    ///Update �� 60 FPS �� �C�@�V������1��
    ///�T�w��s�ƥ�(FixedUpdate)�G50 FPS
    ///�B�z���z�欰
    ///</summary>
    private void FixedUpdate()
    {
        Move(); 
    }

    private void Update()
    {
        Flip(); 
    }
    #endregion
    #region ��k
    ///<summary>
    ///1.���a�O�_�������ʫ���A���k��V���A�BD
    ///2.���󲾰ʦ欰(API)
    ///3.Unity API >unityengine>classic>input>getAxis
    ///</summary>
    private void Move()
    {
        //h �� ���w�� ��J.���o�b�V(�����b) - �����b�N���k��P AD
        float h = Input.GetAxis("Horizontal");
        print("���a���k�����" + h);

        //���餸��(rig).�[�t�� = �s �G���V�q(h �� * ���ʳt��, ����.�[�t��.����)
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
    }

    ///<summary>
    ///½���G
    /// h �� �p�� 0 ���G���� Y 180
    /// h �� �j�� 0 �k�G���� Y 0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");
        //�p�G h �� �p�� 0 ���G���� Y 180
        if (h < 0)
        {
            //transform = Unity�̪�Transform
            //eulerAngles = ���ਤ��
            //Vector3 = �T��V�q
            transform.eulerAngles = new Vector3(0, 180, 0); 
        }
        //�p�G h �� �j�� 0 �k�G���� Y 0
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero; 
        }
    }
    #endregion
}
