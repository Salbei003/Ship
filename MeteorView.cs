using UnityEngine;
using DG.Tweening;
using System;

using Random = UnityEngine.Random;

public class MeteorView : MonoBehaviour, IToggleActivity
{

    private float RandomYPosition { get; set; }
    private CircleCollider2D collider;
    private SpriteRenderer sprite;
    public bool active, canDealDmg;



    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }



    public void SetOff()
    {
        transform.DOKill();
        canDealDmg = true;
        collider.enabled = false;
        sprite.enabled = false;
        active = false;
    }

    public void SetOn()
    {

        RandomYPosition = Random.Range(7f, 12f);
        ReturnOnLevel(BoundsProvider.GetXPoints(gameObject),RandomYPosition);
        collider.enabled = true;
        sprite.enabled = true;
        active = true;

    }


    public void UpdatePosition(Vector2 newPosition)
    {
        transform.localPosition = newPosition;
    }

    public void UpdateRotate(Vector3 euler, float speed)
    {
        
        transform.Rotate(euler * speed * Time.deltaTime);
  
    }

    public void SetSettings(MeteorModel config)
    {
        sprite.sprite = config.sprite;
        transform.localScale = config.meteorScale;
    }




    public void ReturnOnLevel(Vector2 pointsX,float rndY)
    {
        float randomX = Random.Range(pointsX.x, pointsX.y);
        UpdatePosition(new Vector2(randomX, rndY));

 
    }

    private void OnDestroy()
    {
        SetOff();
    }
}
