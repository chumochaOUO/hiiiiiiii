using UnityEngine;

//�إ߱M�פ������(menuName = "���W��") ��Ƨ�/�l���
[CreateAssetMenu(menuName = "�t�t/���")]

/// <summary>
/// ��ܸ��
/// �O�s NPC �n�򪱮a������ܤ��e
/// </summary>
/// Scriptable Object �}���ƪ���G�N�{������x�s��
public class DataDialogue : ScriptableObject
{
    //Text Area (�̤p��ơA�̤j���) - �ȭ� string
    [Header("��ܤ��e"), TextArea(3, 5)]
    public string[] dialogus; 
}
