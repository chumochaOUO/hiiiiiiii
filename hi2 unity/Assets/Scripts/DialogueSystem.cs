using UnityEngine;
using UnityEngine.UI;
using System.Collections;

///<summary>
/// ��ܨt��
/// �N�ݭn��X����r�Q�Υ��r�ĪG�e�{
/// </summary>

public class DialogueSystem : MonoBehaviour
{
    #region ���G���}
    [Header("��ܶ��j"), Range(0, 1)]
    public float interval = 0.3f;
    //interval=���r��r�ɶ�
    [Header("�e����ܨt��")]
    public GameObject goDialogue;
    [Header("��ܤ��e")]
    public Text textContent;
    [Header("��ܧ����ϥ�")]
    public GameObject goTip;
    [Header("��ܫ���")]
    public KeyCode keyDialoge = KeyCode.Mouse0;
    #endregion

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }

    private IEnumerator TypeEffect()
    {
        string test1 = "���o�A�A�n~";
        string test2 = "��ܲĤG�q~";

        string[] test = { test1, test2 };
        
        textContent.text = "";                          //�M���W����ܤ��e
        goDialogue.SetActive(true);                     //��ܹ�ܪ���
        
        for (int j = 0; j < test.Length; j++)          //�M�M�Ҧ����
        {
            for (int i = 0; i < test[j].Length; i++)    //�M�M��ܪ��C�@�Ӧr
            {
                textContent.text += test[j][i];       //�|�[��ܤ��e��r����
                yield return new WaitForSeconds(interval);
            }
        }

        goTip.SetActive(true);

        while (!Input.GetKeyDown(keyDialoge))
        {
            yield return null;
        }
    }
}