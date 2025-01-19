using DG.Tweening;
using UnityEngine.Events;
using UnityEngine;
using System;

public class ShootView : MonoBehaviour, IToggleActivity
{
    
    Vector2 startPosition;
    SpriteRenderer spriteRender;
    Animator animator;
    CircleCollider2D collider2D;

    Transform parent;


    public bool active;

    void Awake()
    {
        
        
        parent = transform.parent;
        startPosition = transform.transform.localPosition;
        spriteRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<CircleCollider2D>();

        SetOff();


    }

    public void SetOn()
    {

        spriteRender.enabled = true;
        collider2D.enabled = true;
        animator.enabled = true;
        active = true;
        transform.parent = null;
    }

    public void SetOff()
    {
        transform.DOKill();
        spriteRender.enabled = false;
        collider2D.enabled = false;
        animator.enabled = false;
        transform.parent = parent;
        transform.localPosition = startPosition;
        active = false;

    }

    public void OnHit()
    {

        

        animator.SetTrigger("HIT");
    }

    


    public void SetSpriteSettenigs(Sprite sprite)
    {
        spriteRender.sprite = sprite;
     
    }

    private void OnDestroy()
    {
        SetOff();
    }

}
