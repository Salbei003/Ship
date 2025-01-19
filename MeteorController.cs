using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEngine;

using Random = UnityEngine.Random;

public class MeteorController : MonoBehaviour
{
    public MeteorView view;

    [SerializeField]
    private MeteorModel config;

    public float CurrentHP { get; set; }

    public Action OnMeteorAwake;


    void Start()
    {
        view = GetComponent<MeteorView>();
        view.SetSettings(config);
        view.SetOff();
        CurrentHP = config.HP;

        OnMeteorAwake += view.SetOn;
        OnMeteorAwake += TransalteMeteorite;
        OnMeteorAwake += () => CurrentHP = config.HP;

    }


    public void GetDamage(float dmg)
    {

        bool deadValue = (CurrentHP -= dmg) <= 0;

        if (deadValue)
        {
            view.SetOff();
            CurrentHP = config.HP;
            PlayerStatsController.OnExpAwarded?.Invoke(config.exp);

            BuffSpawning();

        }
    }

   

    public int DealDmg()
    {
        if (view.canDealDmg)
        {
            view.canDealDmg = false;
            view.SetOff();
            return config.DMG;
        }
        return 0;
    }




    public void TransalteMeteorite()
    {
        view.transform.DOMoveY(config.translatePoint.y, config.translateSpeed)
            .SetEase(Ease.Linear)
            .OnUpdate(() => view.UpdateRotate(config.rotateEuler, config.rotateSpeed))
            .OnComplete(()=> view.SetOff());
            
    }

    private void BuffSpawning()
    {
        int r = Random.Range(0, 40);
        Vector2 v = transform.position;

        if (r <= 5)
        {
            GameObject item = Instantiate(Resources.Load("SpeedUpBuff").GameObject());
            item.transform.position = v;
        }
        else if (r <= 15)
        {
            GameObject item = Instantiate(Resources.Load("RegenDrop").GameObject());
            item.transform.position = v;
        }
    }
}
