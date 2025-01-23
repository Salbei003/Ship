using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using System.Diagnostics;

public class ShootsPool : MonoBehaviour
{
    private readonly List<ShootController> shoots = new List<ShootController>(); // можно конечно было использовать очередь, но в нём, в данном контексте, нужды не было
    private static AudioSource shootSound;
    private ShipController ship;
    bool pause = true;

    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("MainShip").GetComponent<ShipController>();

        ship.view.AmmoSlider.MaxValueChange(ship.model.shootsSpeedSpawn);
        shootSound = transform.parent.GetComponent<AudioSource>();
        FillPool();
        AmmoResoring();

    }

    private void OnDestroy()
    {
        shootSound = null;
    }



    public void OnAttack(InputAction.CallbackContext value)
    {

        if (value.performed && !pause)
        {
            ship.view.AmmoSlider.ValueChange(0);
            GetShoot().OnShootActived?.Invoke();
            shootSound.Play();
            pause = true;
            AmmoResoring();
        }
    }
    private void FillPool()
    {
        for (int i = 0; i < transform.childCount; i++)
        {

            if (transform.GetChild(i).GetComponent<ShootController>() != null)
            {
                shoots.Add(transform.GetChild(i).transform.GetComponent<ShootController>());
            }
        }
    }

    private ShootController GetShoot()
    {
        for(int i = 0;i < shoots.Count; i++)
        {
            if (!shoots[i].view.active)
            {
                return shoots[i];
            }
        }

        return null;
    }

    
    private void AmmoResoring()
    {
        Debug.Log("Ammo Restoring");
        ship.view.AmmoSlider.MaxValueChange(ship.model.shootsSpeedSpawn);
        ship.view.AmmoSlider.Slider.DOValue(ship.view.AmmoSlider.CurrentMaxValue, ship.model.shootsSpeedSpawn)
            .OnComplete(() => pause = false);
    }



    public void StartBaff()
    {
        StartCoroutine(nameof(BaffShooting));
    }
    

    private IEnumerator BaffShooting()
    {
        float t = 0;
        pause = true;
        while(t < 1.3f)
        {
            ship.view.AmmoSlider.ValueChange(0);
            GetShoot().OnShootActived?.Invoke();
            shootSound.Play();
            t += 0.1f;
            yield return new WaitForSeconds(0.3f);
            yield return null;
        }

        pause = false;
    }
}
