using UnityEngine;
using UnityEngine.EventSystems;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDraggable : IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        
    }
}
