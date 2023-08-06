using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] questionList = new string[4];
    [SerializeField] int currentAnswerIndex = 0;

    public string getQuestion()
    {
        return question;
    }
    public int getCurrentAnswerIndex()
    {
        return currentAnswerIndex;
    }
    public string getAnswer(int index)
    {
        return questionList[index];
    }

}
