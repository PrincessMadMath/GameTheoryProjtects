using GameComponent.Interface;
using GameSolver.Component;

namespace Connect4.GameElement
{
    public class Connect4Move : IMove
    {
        public int X { get; set; }
        public IToken Token { get; set; }

        public string GetDescription()
        {
            return string.Format("Placement d'un token dans colonne ({0})", X);
        }
    }
}