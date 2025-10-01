/// <summary>
/// Estado inicial del juego. Prepara la UI y las cartas.
/// </summary>
public class StartState : IGameState
{
    private readonly CardControl ctrl;
    public StartState(CardControl c) => ctrl = c;

    public void Enter()
    {
        ctrl.correctText.SetActive(false);
        ctrl.incorrectText.SetActive(false);

        ctrl.TurnOffCards();

        // Solo el botón de repartir activo
        ctrl.ToggleButtons(hi: false, lo: false, equal: false, deal: true);
    }

    public void Update() { }
    public void Exit() { }
}