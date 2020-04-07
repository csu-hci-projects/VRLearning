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
    private int currentCorrectAnswer;

    public TextMeshProUGUI questionText;
    public Image questionImage;

    public TextMeshProUGUI answerTriangleText;
    public TextMeshProUGUI answerDiamondText;
    public TextMeshProUGUI answerCircleText;
    public TextMeshProUGUI answerSquareText;

    void Start() {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
            unansweredQuestions = questions.ToList<Question>();
        }
        GetRandomQuestion();
    }

    void GetRandomQuestion() {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        currentCorrectAnswer = currentQuestion.correctAnswer;
        unansweredQuestions.RemoveAt(randomQuestionIndex);

        if (currentQuestion.question.Length == 0) {
            questionText.enabled = false;
            questionImage.sprite = currentQuestion.spriteQuestion;
        } else {
            questionText.text = currentQuestion.question;
        }

        answerTriangleText.text = currentQuestion.answerTriangle;
        answerDiamondText.text = currentQuestion.answerDiamond;
        answerCircleText.text = currentQuestion.answerCircle;
        answerSquareText.text = currentQuestion.answerSquare;
    }

    void UserSelectAnswer(int answerIndex) {
        if (currentCorrectAnswer == answerIndex) Debug.Log("CORRECT");
        else {
            if (answerIndex == 0) answerTriangleText.enabled = false;
            else if (answerIndex == 1) answerDiamondText.enabled = false;
            else if (answerIndex == 2) answerCircleText.enabled = false;
            else answerSquareText.enabled = false;
        }
    }

}
