using UnityEngine;
using System.Collections;

/// <summary>
/// Estado de adivinanza "mayor" o "menor".
/// </summary>
public class GuessingState : IGameState
{
    private readonly CardControl ctrl;
    private readonly bool guessHigh;

    public GuessingState(CardControl c, bool gHi)
    {
        ctrl = c;
        guessHigh = gHi;
    }

    public void Enter()
    {
        int rightIndex = Random.Range(0, ctrl.turningRightCards.Length);
        ctrl.turningRightCards[rightIndex].SetActive(true);

        // Lógica estricta: mayor o menor
        bool isCorrect = guessHigh
            ? rightIndex > ctrl.dealtCardNumber
            : rightIndex < ctrl.dealtCardNumber;

        ctrl.ShowResult(isCorrect);

        if (isCorrect)
            GlobalScore.Instance.AddScore(100);
        else
            GlobalScore.Instance.ResetScore();

        // Espera 3 segundos y reparte automáticamente una nueva carta
        ctrl.StartCoroutine(DealAfterDelay(3f));
    }

    private IEnumerator DealAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ctrl.OnDealButton();
    }

    public void Update() { }
    public void Exit() { }
}
