using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIManager Instance;

    public Canvas ExpectationCanvas, PlayingCanvas, ResultCanvas;

    public void SetExpectation()
    {
        //Send input expectation to GameManager
    }

    public void UpdateScore()
    {
        //Print information in playing 
    }

    public void SetResult()
    {
        //Print result
    }

    public UIManager()
    {
        Instance = this;
    }
}
