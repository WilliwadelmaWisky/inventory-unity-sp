using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using WWWisky.inventory.core.components.sub;
using WWWisky.inventory.core.items;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class SlotSortGUI : MonoBehaviour
    {
        enum SortType { Alphabet, Reverse_Alphabet }

        [SerializeField] private TMP_Dropdown SortDropdown;
        [SerializeField] private TMP_Dropdown CategoryDropdown;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            SortDropdown.ClearOptions();
            SortDropdown.AddOptions(new List<string> { "ANY" });
            SortDropdown.AddOptions(Enum.GetNames(typeof(SortType)).ToList());

            CategoryDropdown.ClearOptions();
            CategoryDropdown.AddOptions(new List<string> { "ALL" });
            CategoryDropdown.AddOptions(Enum.GetNames(typeof(ItemType)).ToList());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IComparer<ISlot> GetComparer()
        {
            if (SortDropdown.value <= 0)
                return null;

            SortType sortType = (SortType)Enum.GetValues(typeof(SortType)).GetValue(SortDropdown.value - 1);
            switch (sortType)
            {
                case SortType.Alphabet: return new SortSlotAlphabet(false);
                case SortType.Reverse_Alphabet: return new SortSlotAlphabet(true);
                default: return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Predicate<ISlot> GetPredicate()
        {
            if (CategoryDropdown.value <= 0)
                return slot => true;

            ItemType itemType = (ItemType)Enum.GetValues(typeof(ItemType)).GetValue(CategoryDropdown.value - 1);
            return slot => !slot.IsEmpty && slot.Item.Type == itemType;
        }


        /// <summary>
        /// 
        /// </summary>
        public class SortSlotAlphabet : IComparer<ISlot>
        {
            public bool IsReversed { get; }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="isReversed"></param>
            public SortSlotAlphabet(bool isReversed) => IsReversed = isReversed;


            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(ISlot x, ISlot y)
            {
                if (x.IsEmpty && !y.IsEmpty)
                    return 1;
                if (y.IsEmpty && !x.IsEmpty)
                    return -1;
                if (x.IsEmpty && y.IsEmpty)
                    return 0;

                int multiplier = IsReversed ? -1 : 1;
                int compareValue = x.Item.Name.CompareTo(y.Item.Name) * multiplier;
                return compareValue != 0 ? compareValue : y.Amount.CompareTo(x.Amount);
            }
        }
    }
}
