﻿using UnityEngine;
using System.Collections.Generic;

namespace Sakura.Inventory
{
    public sealed class InventoryScreen : MonoBehaviour
	{
        [SerializeField]
        private List<InventoryItemSlot> itemSlots;

        public void Test()
        {
            Debug.Log("Test");
        }
    }
}