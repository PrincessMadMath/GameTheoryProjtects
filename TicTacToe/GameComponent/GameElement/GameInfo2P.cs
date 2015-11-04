using GameComponent.Interface;

namespace GameComponent.GameElement
{
    public class GameInfo2P : IGameInfo
    {
        public IState State { get; set; }
        public IPlayer PlayerA { get; set; }
        public IPlayer PlayerB { get; set; }
    }
}