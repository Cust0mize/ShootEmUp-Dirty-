namespace ShootEmUp {
    public interface IGameStartListner : IGameLisnter {
        public void OnStartGame();
    }

    public interface IGamePauseListner : IGameLisnter {
        public void OnPauseGame();
    }

    public interface IFinishGameListner : IGameLisnter {
        public void FinishGame();
    }

    public interface IResumeGameListner : IGameLisnter {
        public void OnResumeGame();
    }

    public interface IGameLisnter {
    }

    public interface IUpdateListner : IGameLisnter {
        public bool IsEnable { get; }
        public void UpdateGame(float time);
    }

    public interface IFixedUpdateListner : IGameLisnter {
        public bool IsEnable { get; }
        public void FixedUpdateGame(float time);
    }
}