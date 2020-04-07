using TMPro;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;

    public TextMeshProUGUI questionText;
    public Image questionImage;
    public TextMeshProUGUI answerOneText;
    public TextMeshProUGUI answerTwoText;
    public TextMeshProUGUI answerThreeText;
    public TextMeshProUGUI answerFourText;

    void Start() {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
            unansweredQuestions = questions.ToList<Question>();
        }
        GetRandomQuestion();
    }

    void GetRandomQuestion() {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        unansweredQuestions.RemoveAt(randomQuestionIndex);

        if (currentQuestion.question.Length == 0) {
            questionText.enabled = false;
            questionImage.sprite = currentQuestion.spriteQuestion;
        } else {
            questionText.text = currentQuestion.question;
        }

        answerOneText.text = currentQuestion.answerOne;
        answerTwoText.text = currentQuestion.answerTwo;
        answerThreeText.text = currentQuestion.answerThree;
        answerFourText.text = currentQuestion.answerFour;
    }

}
