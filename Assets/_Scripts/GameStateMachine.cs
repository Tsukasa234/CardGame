/// <summary>
/// Máquina de estados para controlar el flujo del juego.
/// </summary>
public class GameStateMachine
{
    private IGameState currentState;

    /// <summary>
    /// Cambia el estado actual por uno nuevo.
    /// </summary>
    public void ChangeState(IGameState newState)
    {
        if (newState == null)
            return;
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    /// <summary>
    /// Actualiza el estado actual si existe.
    /// </summary>
    public void Update()
    {
        currentState?.Update();
    }
}
