using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PlayingState
    {
        Expectation, Playing, Result
    }

    public static GameManager Instance;

    public int expectRed, expectBlue, resultRed, resultBlue, score;

    public void Init()
    {
        //Initialize Game
    }

    public void Expect(int red, int blue)
    {
        //Set expected result
    }

    public void Play()
    {
        //Play Game(Start race)
    }

    public void GetScore()
    {
        //Set play's result
    }

    public void ExitGame()
    {
        //Quit Game
    }

    public GameManager()
    {
        Instance = this;
    }
}
