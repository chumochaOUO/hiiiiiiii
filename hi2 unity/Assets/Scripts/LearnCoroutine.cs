using UnityEngine;
using System.Collections; //�ޥ� �t��.���X �]�t��P�{��

/// <summary>
/// �{�Ѩ�P�{��
/// </summary>
public class LearnCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Test());
        StartCoroutine(TestWithLoop());
    }

    //�w�q��P�{��
    //�Ǧ^���� IEnumerator
    private IEnumerator Test()
    {
        print("�o�O�Ĥ@�q��r�T��");
        yield return new WaitForSeconds(1); //���ݬ��
        print("�o�O�ĤG�q��r�T��");
        yield return new WaitForSeconds(3);
        print("�S���F�T����");
    } 
    private IEnumerator TestWithLoop()
    {
        //�j�馸�� i ��l=0 ��i<10 ����B�@ i+1
        for (int i = 0; i < 10; i++) 
        {
            print("�Ʀr�G" + i);
            //���ݼv��ɶ���
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
    