using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz quiz;
    CompleteCavas completeCavas;
    // Start is called before the first frame update
    private void Awake()
    {
        quiz = FindObjectOfType<Quiz>();
        completeCavas = FindObjectOfType<CompleteCavas>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        completeCavas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            completeCavas.gameObject.SetActive(true);
        }
    }

    public void OnReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
