using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.Events;
using System;

using Random = UnityEngine.Random;
public class ShootController : MonoBehaviour
{
    [HideInInspector]
    public ShootView view; 
    [SerializeField]
    private ShootModel config; 

    public Action OnShootActived;

       

    void Start()
    {
        view = GetComponent<ShootView>();

        view.SetSpriteSettenigs(config.Sprite);

        OnShootActived += view.SetOn;
        OnShootActived += PullUpShoot;

    }




    private void PullUpShoot() 
    {
         
        view.transform.DOMoveY(SystemSettings.resolutionInWorldPoints.y, config.Speed)
        .SetEase(Ease.Linear)
        .OnComplete(() => view.SetOff());
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<MeteorController>().GetDamage(config.DMG * ShipModel.baseDmg); Debug.Log(config.DMG * ShipModel.baseDmg);
            view.SetOff();
        }
    }



}
