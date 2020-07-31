﻿using Sakura.Entities;
using Sakura.UI;
using UnityEngine;

namespace Sakura.InventoryUI
{
    /// <summary>
    /// A UI for the player's inventory.
    /// </summary>
    [RequireComponent(typeof(GameObjectParameter))]
    [RequireComponent(typeof(WindowController))]
    public sealed class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject HUD = null;

        public void DisplayHUD()
        {
            Instantiate(HUD);
        }
    }
}
