﻿using UnityEngine;
using WWWisky.inventory.core;
using WWWisky.inventory.core.components;
using WWWisky.inventory.core.items;
using WWWisky.inventory.unity.items;

namespace WWWisky.inventory.unity.components
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorMono : MonoBehaviour
    {
        [SerializeField] private string Name;
        [SerializeField] private ItemSO[] Items;

        private Vendor _vendor;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _vendor = new Vendor(Name);
        }
        void Start()
        {
            foreach (ItemSO itemSO in Items)
            {
                IItem item = itemSO.Create();
                if (item is IVendible vendible)
                    _vendor.Add(vendible);
            }
        }


        public IVendor GetVendor() => _vendor;
    }
}
