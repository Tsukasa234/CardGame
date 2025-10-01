/// <summary>
/// Interfaz base para los estados de la máquina de juego.
/// </summary>
public interface IGameState
{
    /// <summary>
    /// Lógica al entrar en el estado.
    /// </summary>
    void Enter();
    /// <summary>
    /// Lógica de actualización por frame.
    /// </summary>
    void Update();
    /// <summary>
    /// Lógica al salir del estado.
    /// </summary>
    void Exit();
}
