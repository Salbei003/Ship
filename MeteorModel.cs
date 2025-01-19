using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Meteor", menuName = "Scriptable Objects/Meteor")]
public class MeteorModel : ScriptableObject
{
    public Sprite sprite = null;
    public Vector2 meteorScale = new (0.2f,0.2f);
    public Vector2 translatePoint = new(0, -6);
    public Vector3 rotateEuler = new(0, 0, -90);
    public float rotateSpeed = 1f;
    [Tooltip("Скорость в секундах, чем меньше тем быстрее")]
    public float translateSpeed = 10f;
    public float HP = 5f;
    public int DMG = 5;
    public int exp = 0;
    public int money = 0;
    public MeteorVariant meteorVariant = MeteorVariant.classic;





}

public enum MeteorVariant
{
    classic, big, fire

}

