using System;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using WWWisky.inventory.core;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorGUI : MonoBehaviour
    {
        [SerializeField] private VendibleGUI VendiblePrefab;
        [SerializeField] private ListGUI VendibleList;
        [Header("Optional")]
        [SerializeField] private TextMeshProUGUI NameText;

        private IObjectPool<IElementGUI> _slotPool;
        private IVendor _vendor;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            _slotPool = new ObjectPool<IElementGUI>(() => (VendibleGUI)VendiblePrefab.Clone());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendor"></param>
        public void Assign(IVendor vendor)
        {
            _vendor = vendor;

            NameText?.SetText(_vendor.Name);
            Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Refresh() => Refresh(vendible => true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        public void Refresh(Predicate<IVendible> match)
        {
            VendibleList.Clear().ForEach(element => _slotPool.Release(element));
            _vendor.ForEach((vendible, index) =>
            {
                if (match(vendible))
                    AddVendible(vendible, index);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendible"></param>
        /// <param name="index"></param>
        private void AddVendible(IVendible vendible, int index)
        {
            VendibleGUI vendibleGUI = (VendibleGUI)_slotPool.Get();
            VendibleList.Add(vendible, vendibleGUI);
            vendibleGUI.OnClicked += () => OnVendibleClicked(vendibleGUI);
            vendibleGUI.transform.SetSiblingIndex(index);
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnVendibleClicked(VendibleGUI vendibleGUI)
        {
            if (vendibleGUI == null)
                return;

            Debug.Log("Buy: " + vendibleGUI.Vendible.Name);
            _vendor.Buy(vendibleGUI.Vendible, 1);
        }
    }
}
