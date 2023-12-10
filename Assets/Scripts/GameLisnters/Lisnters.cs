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
}