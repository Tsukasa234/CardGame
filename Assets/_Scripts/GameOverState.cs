/// <summary>
/// Estado de fin de juego. Reinicia tras un retraso.
/// </summary>
public class GameOverState : IGameState
{
    private readonly CardControl ctrl;
    public GameOverState(CardControl c) => ctrl = c;

    public void Enter()
    {
        // Reinicia el juego después de 5 segundos
        ctrl.StartCoroutine(ctrl.RestartAfterDelay(5f));
    }

    public void Update() { }
    public void Exit() { }
}
