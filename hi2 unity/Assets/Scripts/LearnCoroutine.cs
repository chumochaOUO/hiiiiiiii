using UnityEngine;
using System.Collections; //引用 系統.集合 包含協同程序

/// <summary>
/// 認識協同程序
/// </summary>
public class LearnCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Test());
        StartCoroutine(TestWithLoop());
    }

    //定義協同程序
    //傳回類型 IEnumerator
    private IEnumerator Test()
    {
        print("這是第一段文字訊息");
        yield return new WaitForSeconds(1); //等待秒數
        print("這是第二段文字訊息");
        yield return new WaitForSeconds(3);
        print("又等了三秒鐘");
    } 
    private IEnumerator TestWithLoop()
    {
        //迴圈次數 i 初始=0 當i<10 停止運作 i+1
        for (int i = 0; i < 10; i++) 
        {
            print("數字：" + i);
            //等待影格時間↘
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
    