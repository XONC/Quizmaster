using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interage : MonoBehaviour
{
    int questionSeen;
    int currentAnswerCount;

    public int GetCurrentAnswerCount()
    {
        return currentAnswerCount;
    }
    public void AdditionCurrentAnswerCount()
    {
        currentAnswerCount++;
    }

    public int GetQuestionSeen()
    {
        return questionSeen;
    }
    public void AdditionQuestionSeen()
    {
        questionSeen++;
    }

    public int GetInterage()
    {
        return Mathf.RoundToInt(currentAnswerCount / (float)questionSeen * 100);
    }

}
