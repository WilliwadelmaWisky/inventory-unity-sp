using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatorGUI : MonoBehaviour
    {
        [SerializeField] private Canvas Canvas;
        [Header("Optional")]
        [SerializeField] private WindowGUI[] Prefabs;


        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            foreach (WindowGUI prefab in Prefabs)
                CreateGUI(prefab);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public T CreateGUI<T>(T element) where T : MonoBehaviour
        {
            T obj = Instantiate(element, Canvas.transform);
            return obj;
        }
    }
}
