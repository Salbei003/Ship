using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UpgradeButton : MonoBehaviour
{
    public ShipStats stat;
    public event Action OnLevelUpStat;

    private UpgradesMenu upgradesMenu;
    public Button Button { get; set; }
    private Dictionary<Image, bool> Rumbs = new Dictionary<Image, bool>();

   
    void Awake()
    {
        Button = GetComponent<Button>();
        upgradesMenu = GetComponentInParent<UpgradesMenu>();

        for (int i = 1; i < transform.childCount; i++)
        {
            Rumbs.Add(transform.GetChild(i).GetComponent<Image>(),false);
        }

    }


    public void ActiveRumb()
    {
        Dictionary<Image, bool> temporary = Rumbs;
        Image tempRumb;
        foreach (var rumb in temporary)
        {
            if (!rumb.Value)
            {
                rumb.Key.sprite = upgradesMenu.fullRumb;
                tempRumb = rumb.Key;
                Rumbs[tempRumb] = true;
                OnLevelUpStat?.Invoke();
                break;
            }
        }

    }
}
