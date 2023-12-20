using System.Threading.Tasks;
using UnityEngine;

namespace WWWisky.inventory.unity.gui
{
    /// <summary>
    /// 
    /// </summary>
    public class AnimatedWindowGUI : WindowGUI
    {
        [SerializeField] private float Duration;


        /// <summary>
        /// 
        /// </summary>
        public override void Show()
        {
            CanvasGroup.blocksRaycasts = true;
            Run(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Hide()
        {
            CanvasGroup.blocksRaycasts = false;
            Run(true);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isReversed"></param>
        private async void Run(bool isReversed)
        {
            float timer = isReversed ? Duration : 0;
            float deltaSeconds = 0.02f;
            int deltaMilliseconds = Mathf.FloorToInt(deltaSeconds * 1000);

            do
            {
                float percent = Mathf.Clamp01(timer / Duration);
                CanvasGroup.alpha = percent;

                timer = isReversed ? timer - deltaSeconds : timer + deltaSeconds;
                await Task.Delay(deltaMilliseconds);

            } while (timer > 0 && timer < Duration);
        }
    }
}
