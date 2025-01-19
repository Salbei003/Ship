using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Unity.VisualScripting;

public class UpgradesMenu : MonoBehaviour
{
    public ShipController shipController;
    public PlayerStatsController playerStatsController;
    public Sprite fullRumb;
    public List<UpgradeButton> upgButtons;


    void Start()
    {
        foreach (UpgradeButton upgButton in upgButtons)
        {
            upgButton.OnLevelUpStat += () => shipController.StatsLevelUp(upgButton.stat);
            upgButton.Button.onClick.AddListener(() => OnButtonClick(upgButton));
        }
        
    }

    public void OnButtonClick(UpgradeButton button)
    {
        if (playerStatsController.expPoints > 0)
        {
            button.ActiveRumb();
        }
    }

    public void OpenMenu(GameObject hidden)
    {
        hidden.SetActive(false);
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosedMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
