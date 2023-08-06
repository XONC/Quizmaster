using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 画布的库
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] TextMeshProUGUI textMeshProUGUI; //标题
    QuestionSO questionSO;
    [SerializeField] List<QuestionSO> questionSOList = new List<QuestionSO>();

    [Header("Button")]
    [SerializeField] GameObject[] answerButtonList;
    int answerIndex = -1; // 

    [Header("Sprite")]
    [SerializeField] Sprite defaultBtnImg;
    [SerializeField] Sprite correctBtnImg;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Integral")]
    [SerializeField] TextMeshProUGUI integralText;
    Interage interage;

    [Header("Progress")]
    [SerializeField] Slider progress;

    public bool isComplete = false;
    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        interage = FindObjectOfType<Interage>();
    }
    void Start()
    {

        progress.maxValue = questionSOList.Count;
        progress.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion)
        {
            if (progress.value == progress.maxValue)
            {
                isComplete = true;
                return;
            }
            GetNextQuesition();
            timer.loadNextQuestion = false;
        }
        if (timer.showingAnswer)
        {
            ShowCurrentAnswer(timer.alreadyAnswerQuestion ? answerIndex : -1);
        }


    }

    // 按钮点击事件
    public void onChangeCurrnetAnswer(int index)
    {
        answerIndex = index;

        // 设置问题之前先判断是否答对
        if (answerIndex == questionSO.getCurrentAnswerIndex())
        {
            interage.AdditionCurrentAnswerCount();
        }

        timer.ClearTimter();
    }

    // 进入下一个问题
    void GetNextQuesition()
    {
        if (questionSOList.Count != 0)
        {
            SetQuestionSO();

            SetButtonState(true);

            DisplayedButton();

            SetDefaultSprite();

            progress.value++;

        }
    }
    // 公布答案
    void ShowCurrentAnswer(int index)
    {
        // 修改真确的按钮的精灵图
        Image btnImg;
        int correctIndex = questionSO.getCurrentAnswerIndex();
        btnImg = answerButtonList[correctIndex].GetComponent<Image>();
        btnImg.sprite = correctBtnImg;
        // 根据是否答对修改文字标题
        textMeshProUGUI.text = index == correctIndex ? "correct!" : "error!; \nanswer is " + questionSO.getAnswer(correctIndex);
        integralText.text = "Scorus " + interage.GetInterage() + '%';
        SetButtonState(false);
    }

    // 随机选择问题
    void SetQuestionSO()
    {
        // 确定展示的问题

        int index = Random.Range(0, questionSOList.Count);
        questionSO = questionSOList[index];
        interage.AdditionQuestionSeen();


        // 移除展示的问题
        if (questionSOList.Contains(questionSO))
        {
            questionSOList.Remove(questionSO);
        }
        else
        {
            textMeshProUGUI.text = "end!";
        }
    }

    //设置按钮状态
    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtonList.Length; i++)
        {
            Button button = answerButtonList[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    // 设置当前的问题和答案
    void DisplayedButton()
    {
        textMeshProUGUI.text = questionSO.getQuestion();

        for (int i = 0; i < answerButtonList.Length; i++)
        {
            TextMeshProUGUI answerBtnText = answerButtonList[i].GetComponentInChildren<TextMeshProUGUI>();
            answerBtnText.text = questionSO.getAnswer(i);
        }
    }
    // 设置默认的按钮图
    void SetDefaultSprite()
    {
        for (int i = 0; i < answerButtonList.Length; i++)
        {
            Image btnImage = answerButtonList[i].GetComponent<Image>();
            btnImage.sprite = defaultBtnImg;
        }
    }
}
