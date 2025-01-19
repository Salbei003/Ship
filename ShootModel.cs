using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootConfig", menuName = "Scriptable Objects/ShootConfig")]
public class ShootModel : ScriptableObject
{
    public Sprite Sprite;
    public float DMG = 1f;
    [Tooltip("�������� � ��������, ��� ������ ��� �������")]
    public float Speed = 3f;
    public SpecialAbility special = SpecialAbility.None;

}

public enum SpecialAbility
{ 
    None, Fire, Big

}

