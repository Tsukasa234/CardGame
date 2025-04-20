using System;
using System.Collections;
using UnityEngine;

public class CardControl : MonoBehaviour
{

    /// This script is used to control the card game state logic
    public enum GameState
    {
        Start,
        Dealing,
        Guessing,
        Guessed,
        GameOver
    }

    ///variables to keep track of the dealt and new card numbers
    public int dealtCardNumber;
    public int newCardNumber;

    ///variables to keep track of the card numbers generated for dealing and guessing
    private int cardGenerateDealing;
    private int cardGenerateGuessed;

    //variable for the text objects to show correct and incorrect guesses
    [SerializeField] private GameObject correctText;
    [SerializeField] private GameObject incorrectText;

    //variables for the buttons and cards to show and hide
    [SerializeField] private GameObject hiButton;
    [SerializeField] private GameObject loButton;
    [SerializeField] private GameObject dealButton;
    [SerializeField] private GameObject[] dealingLeftCard;
    [SerializeField] private GameObject[] TurningRightCards;

    //variable to keep track of the time to wait before restarting the game
    private float timeToWait = 5f;
    private float timeCheck = 0f;

    ///variables to keep track of the guesses made by the player
    public static bool GuessHi = false;
    public static bool GuessLo = false;

    ///variable to keep track of the current game state
    public GameState currentState;

    private void Awake()
    {
        currentState = GameState.Start;
    }

    private void Update()
    {
        /// Check the current game state and call the appropriate method
        if (currentState == GameState.Dealing)
        {
            /// Call the method to deal the cards
            DealingCards();
        }
        else if (currentState == GameState.Guessed)
        {
            /// Call the method to check the guessed card
            Guessed();
        }
        else if (currentState == GameState.GameOver)
        {
            /// Call the method to check if the game should restart
            if (timeCheck < timeToWait)
            {
                /// Increment the time check
                timeCheck += Time.deltaTime;
            }
            else
            {
                /// Call the method to restart the game
                RestartGame();
            }
        }
    }

    private void Guessed()
    {
        /// Check if the player has made a guess
        cardGenerateGuessed = UnityEngine.Random.Range(0, 12);
        TurningRightCards[cardGenerateGuessed].SetActive(true);
        newCardNumber = cardGenerateGuessed;
        /// Check if the guess was correct or incorrect
        if (GuessHi == true)
        {
            /// Check if the new card number is greater than or equal to the dealt card number
            if (newCardNumber >= dealtCardNumber)
            {
                CorrectSelection();
                currentState = GameState.GameOver;
            }
            else
            {
                IncorrectSelection();
                currentState = GameState.GameOver;
            }
        }
        else if (GuessLo == true)
        {
            if (newCardNumber <= dealtCardNumber)
            {
                CorrectSelection();
                currentState = GameState.GameOver;
            }
            else
            {
                IncorrectSelection();
                currentState = GameState.GameOver;
            }
        } 
    }

    /// This method is called when the player makes a correct selection
    private void CorrectSelection()
    {
        correctText.SetActive(true);
        hiButton.SetActive(false);
        loButton.SetActive(false);
    }
    /// This method is called when the player makes an incorrect selection
    private void IncorrectSelection()
    {
        incorrectText.SetActive(true);
        hiButton.SetActive(false);
        loButton.SetActive(false);
    }
    /// This method is called to restart the game
    private void RestartGame()
    {
        timeCheck = 0f;
        GameStart();
    }


    /// This method is called to start the game
    private void GameStart()
    {
        currentState = GameState.Start;
        TurnOffCards();
        hiButton.SetActive(false);
        loButton.SetActive(false);
        dealButton.SetActive(true);
        correctText.SetActive(false);
        incorrectText.SetActive(false);
        dealtCardNumber = 0;
        newCardNumber = 0;
        cardGenerateDealing = 0;
        cardGenerateGuessed = 0;
        GuessHi = false;
        GuessLo = false;
    }

    /// This method is called to turn off the cards
    private void TurnOffCards()
    {
        for (int i = 0; i < dealingLeftCard.Length; i++)
        {
            dealingLeftCard[i].SetActive(false);
            TurningRightCards[i].SetActive(false);
        }
    }
    /// This method is called to deal the cards
    public void DealingCards()
    {
        cardGenerateDealing = UnityEngine.Random.Range(0, 12);
        dealingLeftCard[cardGenerateDealing].SetActive(true);
        hiButton.SetActive(true);
        loButton.SetActive(true);
        dealButton.SetActive(false);
        dealtCardNumber = cardGenerateDealing;
        currentState = GameState.Guessing;
    }
}
