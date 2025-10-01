using System.Collections;
using UnityEngine;

/// <summary>
/// Controlador principal de la lógica de cartas y UI.
/// </summary>
public class CardControl : MonoBehaviour
{
    [HideInInspector] public int dealtCardNumber;
    [SerializeField] private GameObject hiButton, loButton, dealButton, equalButton;
    [SerializeField] public GameObject correctText;
    [SerializeField] public GameObject incorrectText;
    [SerializeField] public GameObject[] dealingLeftCard;
    [SerializeField] public GameObject[] turningRightCards;

    public GameStateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new GameStateMachine();
        stateMachine.ChangeState(new StartState(this));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    // Métodos de UI para botones
    public void OnDealButton()
    {
        dealButton.SetActive(false); // Oculta el botón Deal al repartir
        stateMachine.ChangeState(new DealingState(this));
    }
    public void OnGuessHi() => stateMachine.ChangeState(new GuessingState(this, true));
    public void OnGuessLo() => stateMachine.ChangeState(new GuessingState(this, false));
    public void OnGuessEqual() => stateMachine.ChangeState(new EqualGuessingState(this));

    /// <summary>
    /// Activa o desactiva los botones de la UI.
    /// </summary>
    public void ToggleButtons(bool hi, bool lo, bool equal, bool deal)
    {
        hiButton.SetActive(hi);
        loButton.SetActive(lo);
        equalButton.SetActive(equal);
        dealButton.SetActive(deal);
    }

    /// <summary>
    /// Muestra el resultado de la jugada y desactiva los botones.
    /// </summary>
    public void ShowResult(bool correct)
    {
        correctText.SetActive(correct);
        incorrectText.SetActive(!correct);
        ToggleButtons(false, false, false, false);
    }

    /// <summary>
    /// Apaga todas las cartas de la mesa.
    /// </summary>
    public void TurnOffCards()
    {
        foreach (var c in dealingLeftCard)
            c.SetActive(false);
        foreach (var c in turningRightCards)
            c.SetActive(false);
    }

    /// <summary>
    /// Reinicia el juego tras un retraso.
    /// </summary>
    public IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        stateMachine.ChangeState(new StartState(this));
    }
}
