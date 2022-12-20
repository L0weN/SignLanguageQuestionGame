using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public RawImage questionImage;
    public Text questionText;
    public Text answerText;

    public Text trueAnswerText;
    public Text falseAnswerText;

    public Text highScoreText;
    public Text scoreText;
    
    public Slider timeSlider;

    public void SetRandomQuestion()
    {
        questionImage.texture = GameManager.Instance.currentQuestion.image;
        questionText.text = GameManager.Instance.currentQuestion.question;
        answerText.text = GameManager.Instance.currentAnswer.answer;
    }

    public void SetTrueAnswer()
    {
        if (questionText.text == answerText.text)
        {
            trueAnswerText.text = "CORRECT";
            falseAnswerText.text = "WRONG";
            GameManager.isTrue = true;
        }
        else
        {
            trueAnswerText.text = "WRONG";
            falseAnswerText.text = "CORRECT";
            GameManager.isTrue = false;
        }
    }

    public void ActiveText()
    {
        trueAnswerText.enabled = true;
        falseAnswerText.enabled = true;
    }
    
    public void DeactiveText()
    {
        trueAnswerText.enabled = false;
        falseAnswerText.enabled = false;
    }
}
