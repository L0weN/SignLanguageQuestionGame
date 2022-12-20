using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    [HideInInspector] public Question currentQuestion;
    
    public Answer[] answers;
    private static List<Answer> unaskedAnswers;
    [HideInInspector] public Answer currentAnswer;
    
    public float timeBetweenQuestions = 1f;

    public static bool isTrue;
    
    private int randomQuestionIndex;
    private int randomAnswerIndex;
    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        if (unaskedAnswers == null || unaskedAnswers.Count == 0)
        {
            unaskedAnswers = answers.ToList<Answer>();
        }
        GetRandomQuestion();
    }
    void GetRandomQuestion()
    {
        randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        GetRandomAnswer();
    }
    void GetRandomAnswer()
    {
        int random = Random.Range(0, 10);
        if (random < 8)
        {
            currentAnswer = unaskedAnswers[randomQuestionIndex];
        }
        else
        {
            randomAnswerIndex = Random.Range(0, unaskedAnswers.Count);
            currentAnswer = unaskedAnswers[randomAnswerIndex];
            
        }
        UIManager.Instance.SetRandomQuestion();
        UIManager.Instance.SetTrueAnswer();
        
    }

    public void TapTrue()
    {
        AnimationController.Instance.TrueButtonClicked();
        UIManager.Instance.ActiveText();
        StartCoroutine(TransitionToNextQuestion());
        if (isTrue)
        {
            AudioManager.Instance.CorrectAudio();
            TimeController.Instance.AddTime();
            ScoreController.Instance.AddScore();
        }
        else
        {
            AudioManager.Instance.WrongAudio();
        }   
    }
    
    public void TapFalse()
    {
        AnimationController.Instance.FalseButtonClicked();
        UIManager.Instance.ActiveText();
        StartCoroutine(TransitionToNextQuestion());
        if (!isTrue)
        {
            AudioManager.Instance.CorrectAudio();
            TimeController.Instance.AddTime();
            ScoreController.Instance.AddScore();
        }
        else
        {
            AudioManager.Instance.WrongAudio();
        }
    }
    
    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);
        UIManager.Instance.DeactiveText();
        GetRandomQuestion();
    }
}
