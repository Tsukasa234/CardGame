using System.Collections;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    [HideInInspector] public int dealtCardNumber;
    [SerializeField] private GameObject hiButton, loButton, dealButton, equalButton;
    public GameObject correctText;
    public GameObject incorrectText;
    public GameObject[] dealingLeftCard;
    public GameObject[] turningRightCards;


    public GameStateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new GameStateMachine();
        stateMachine.ChangeState(new StartState(this));
    }

    private void Update() => stateMachine.Update();

    public void OnDealButton() => stateMachine.ChangeState(new DealingState(this));
    public void OnGuessHi() => stateMachine.ChangeState(new GuessingState(this, true));
    public void OnGuessLo() => stateMachine.ChangeState(new GuessingState(this, false));
    //public void OnGuessEqual() => stateMachine.ChangeState(new EqualGuessingState(this));

    public void ToggleButtons(bool hi, bool lo, /*bool equal,*/ bool deal)
    {
        hiButton.SetActive(hi);
        loButton.SetActive(lo);
        //equalButton.SetActive(equal);
        dealButton.SetActive(deal);
    }

    public void ShowResult(bool correct)
    {
        correctText.SetActive(correct);
        incorrectText.SetActive(!correct);
        ToggleButtons(false, false, /*false,*/ false);
    }

    public void TurnOffCards()
    {
        foreach (var c in dealingLeftCard) c.SetActive(false);
        foreach (var c in turningRightCards) c.SetActive(false);
    }

    public IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        stateMachine.ChangeState(new StartState(this));
    }
}
