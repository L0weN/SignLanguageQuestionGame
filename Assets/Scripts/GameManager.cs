using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    public Answer[] answers;
    private static List<Answer> unaskedAnswers;
    private Answer currentAnswer;
    [SerializeField] private RawImage questionImage;
    [SerializeField] private Text questionText;
    [SerializeField] private Text answerText;
    [SerializeField] private float timeBetweenQuestions = 1f;
    [SerializeField] private Text trueAnswerText;
    [SerializeField] private Text falseAnswerText;
    [SerializeField] Animator animator;
    private bool isTrue;
    private int randomQuestionIndex;
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
        if (Random.Range(0, 2) == 0)
        {
            currentAnswer = unaskedAnswers[randomQuestionIndex];
        }
        else
        {
            int randomAnswerIndex = Random.Range(0, unaskedAnswers.Count);
            currentAnswer = unaskedAnswers[randomAnswerIndex];
        }
        SetRandomQuestion();
    }
    void SetRandomQuestion()
    {
        questionImage.texture = currentQuestion.image;
        questionText.text = currentQuestion.question;
        answerText.text = currentAnswer.answer;
        CheckAnswer();
        if (isTrue)
        {
            trueAnswerText.text = "CORRECT";
            falseAnswerText.text = "WRONG";
        }
        else
        {
            trueAnswerText.text = "WRONG";
            falseAnswerText.text = "CORRECT";
        }
    }
    void CheckAnswer()
    {
        if (questionText.text == answerText.text)
        {
            isTrue = true;
        }
        else
        {
            isTrue = false;
        }
    }
    public void SelectTrueButton()
    {
        animator.SetTrigger("True");
        if (isTrue)
        {
            Debug.Log("Correct");
            
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void SelectFalseButton()
    {
        animator.SetTrigger("False");
        if (!isTrue)
        {
            Debug.Log("Correct");

        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);
        GetRandomQuestion();
    }
}
