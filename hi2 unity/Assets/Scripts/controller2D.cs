using UnityEngine;

/// <summary>
/// 控制器：2D 橫向卷軸版本
/// </summary>


public class controller2D : MonoBehaviour
{
    #region 欄位：公開
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300f;
    [Header("檢查地板尺寸與位移"), Range(0, 1)]
    //當一個Header內有複數個欄位，且不需要全部都Range，則Range放在外面
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;

    #endregion

    #region 欄位：私人
    /// <summary>
    /// 剛體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;
    //將私人欄位顯示在屬性面板上
    [SerializeField]
    ///<summary>
    ///是否在地板上
    ///</summary>
    private bool isGrounded;
    #endregion

    #region 事件 Void
    /// <summary>
    /// 繪製圖示
    /// 在 Unity 繪製輔助用圖示
    /// 線條、射線、圓形、方形、扇形、圖片
    /// </summary>

    private void OnDrawGizmos()
    {
        //1.決定圖示顏色
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        //2.決定繪製圖形
        //transform.position 此物件的世界座標
        //transform.TranformDirection()根據變形元件的區域座標轉換為世界座標
        Gizmos.DrawSphere(transform.position + 
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }
 
    //void = 呼叫
    //Start 只會執行一次
    //public = 公開的，會出現在Unity的
    //private = 私人的，不會出現在Unity的
    private void Start()
    {
        //剛體欄位 = 取得元件<2D 剛體>()
         rig = GetComponent<Rigidbody2D>(); 
    }

    ///<summary>
    ///Update 約 60 FPS → 每一幀都執行1次
    ///固定更新事件(FixedUpdate)：50 FPS
    ///處理物理行為
    ///</summary>
    private void FixedUpdate()
    {
        Move(); 
    }

    private void Update()
    {
        Flip();
        CheckGround();
        Jump();
    }
    #endregion

    #region 方法
    ///<summary>
    ///1.玩家是否有按移動按鍵，左右方向鍵或A、D
    ///2.物件移動行為(API)
    ///3.Unity API >unityengine>classic>input>getAxis
    ///</summary>
    private void Move()
    {
        //h 值 指定為 輸入.取得軸向(水平軸) - 水平軸代表左右鍵與 AD
        float h = Input.GetAxis("Horizontal");
        //print("玩家左右按鍵值" + h);

        //剛體元件(rig).加速度 = 新 二維向量(h 值 * 移動速度, 剛體.加速度.垂直)
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
    }

    ///<summary>
    ///翻面：
    /// h 值 小於 0 左：角度 Y 180
    /// h 值 大於 0 右：角度 Y 0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");
        //如果 h 值 小於 0 左：角度 Y 180
        if (h < 0)
        {
            //transform = Unity裡的Transform
            //eulerAngles = 旋轉角度
            //Vector3 = 三圍向量
            transform.eulerAngles = new Vector3(0, 180, 0); 
        }
        //如果 h 值 大於 0 右：角度 Y 0
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero; 
        }
     ///<summary>
     ///檢查是否在地板
     /// </summary>
     
     
        
    }
    

    ///<summary>
    ///檢查是否在地板
    /// </summary>
    private void CheckGround()
    {
        //碰撞資訊 = 2D 物理.覆蓋圓形(中心點，半徑，圖層)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        //print("碰到的物件名稱:" + hit.name);

        isGrounded = hit;
    }

    private void Jump()
    {
        //如果 在地板上 並且 按下指定鍵
        if (isGrounded && Input.GetKeyDown(keyjump))
        {
            //剛體.添加推力(二維向量)
            rig.AddForce(new Vector2(0, jump));
        }
    }
    #endregion
}
