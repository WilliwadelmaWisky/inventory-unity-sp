using System.Collections.Generic;

namespace WWWisky.inventory.core
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftQueue
    {
        private const double INTERVALL = 0.5f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        public delegate void OnCrafted(IRecipe recipe, int amount);

        private readonly Queue<Tuple<IRecipe>> _recipeQueue;
        private readonly OnCrafted _onCrafted;
        private IRecipe _currentRecipe;
        private int _remainingAmount;
        private double _timer;

        public bool IsActive => _currentRecipe != null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="onCrafted"></param>
        public CraftQueue(OnCrafted onCrafted)
        {
            _recipeQueue = new Queue<Tuple<IRecipe>>();
            _onCrafted = onCrafted;
            _currentRecipe = null;
            _remainingAmount = 0;
            _timer = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="amount"></param>
        public void Enqueue(IRecipe recipe, int amount)
        {
            if (recipe == null || amount <= 0)
                return;

            Tuple<IRecipe> tuple = new Tuple<IRecipe>(recipe, amount);
            _recipeQueue.Enqueue(tuple);

            if (IsActive)
                return;

            Next();
            _timer = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Tick(double deltaTime)
        {
            if (!IsActive)
                return;

            _timer += deltaTime;
            int craftAmount = System.Math.Min((int)System.Math.Floor(_timer / INTERVALL), _remainingAmount);
            if (craftAmount <= 0)
                return;

            _timer -= craftAmount * INTERVALL;
            _onCrafted(_currentRecipe, craftAmount);
            if (_remainingAmount <= 0)
                _currentRecipe = null;

            if (_timer >= INTERVALL && _recipeQueue.Count > 0)
            {
                Next();
                Tick(0);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Next()
        {
            Tuple<IRecipe> tuple = _recipeQueue.Dequeue();
            _currentRecipe = tuple.Value;
            _remainingAmount = tuple.Amount;
        }
    }
}
