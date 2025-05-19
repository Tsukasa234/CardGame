public class GameOverState : IGameState
{
    private readonly CardControl ctrl;
    public GameOverState(CardControl c) => ctrl = c;

    public void Enter()
    {
        ctrl.StartCoroutine(ctrl.RestartAfterDelay(5f));
    }

    public void Update() { }
    public void Exit() { }
}
