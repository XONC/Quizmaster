using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    // 回答了问题
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion = false;
    public bool alreadyAnswerQuestion = false;
    public bool showingAnswer = false; // 正在展示答案
    public float fillFraction;

    float timeValue;

    /**
        update 函数会一直运行
    */
    void Update()
    {
        UpdateTimer();
    }

    public void ClearTimter()
    {
        timeValue = 0f;
        alreadyAnswerQuestion = true;
    }

    void UpdateTimer()
    {

        // 使用 timerValue 减去每一帧运行的时间，当timerValue小于0时，说明时间到了。
        timeValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            // 答题结束
            if (timeValue <= 0)
            {
                isAnsweringQuestion = false;
                showingAnswer = true;
                timeValue = timeToShowCorrectAnswer;
            }
            // 展示问题环节
            else
            {
                fillFraction = timeValue / timeToCompleteQuestion;
                showingAnswer = false;
            }
        }
        else
        {
            // 开始答题
            if (timeValue <= 0)
            {
                isAnsweringQuestion = true;
                loadNextQuestion = true;
                alreadyAnswerQuestion = false;
                showingAnswer = false;
                timeValue = timeToCompleteQuestion;
            }
            // 展示答案环节
            else
            {
                fillFraction = timeValue / timeToShowCorrectAnswer;
            }
        }
    }
}
