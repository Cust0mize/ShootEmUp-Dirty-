namespace ShootEmUp {
    public interface IGameStartListener : IGameListener {
        public void OnStartGame();
    }

    public interface IGamePauseListener : IGameListener {
        public void OnPauseGame();
    }

    public interface IFinishGameListener : IGameListener {
        public void OnFinishGame();
    }

    public interface IResumeGameListener : IGameListener {
        public void OnResumeGame();
    }

    public interface IGameListener {
    }

    public interface IUpdateListener : IGameListener {
        public void OnUpdateGame(float deltaTime);
    }

    public interface IFixedUpdateListener : IGameListener {
        public void OnFixedUpdateGame(float fixedDeltaTime);
    }
}