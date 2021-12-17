using UnityEngine;
using System.Collections;

///<summary>
/// 對話系統
/// 將需要輸出的文字利用打字效果呈現
/// </summary>

public class DialogueSystem : MonoBehaviour
{
    [Header("對話間隔"), Range(0, 1)]
    public float interval = 0.3f;
    //interval=打字文字時間

    private IEnumerator TypeEffect()
    {
        string test = "哈囉，你好~";

        for (int i = 0;i < test.Length; i++)
        {
            print(test[i]);
            yield return new WaitForSeconds(interval);
        }
    }
}