using TMPro;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public Button triangleButton;
    public Button diamondButton;
    public Button circleButton;
    public Button squareButton;

    public CanvasGroup Main;
    public CanvasGroup Answer;
    public TextMeshProUGUI answerText;

    public static int Score = 0;
    private static string questionLog = "";
    private static int count = 1;
    private int baseScore = 100;
    private float timeBetweenQuestion = 1f;

    void Start() {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
            unansweredQuestions = questions.ToList<Question>();
        }
        GetRandomQuestion();
    }

    void GetRandomQuestion() {
        currentQuestion = unansweredQuestions[0];
        currentCorrectAnswer = currentQuestion.correctAnswer;
        
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

    IEnumerator TransitionToNextQuestion() {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestion);
        Answer.alpha = 0;
        if (unansweredQuestions.Count > 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else { answerText.text = "FINISHED"; StartCoroutine(TransitionFinish()); }
    }

    IEnumerator TransitionAnswer() {
        yield return new WaitForSeconds(timeBetweenQuestion);
        Answer.alpha = 0;
    }

    IEnumerator TransitionFinish() {
        Answer.alpha = 1;
        CreateText();
        yield return new WaitForSeconds(timeBetweenQuestion);
        Application.Quit();
    }

    void UserSelectAnswer(int answerIndex) {
        if (currentCorrectAnswer == answerIndex) {
            GameManager.Score += baseScore;
            GameManager.questionLog += "Question " + (count++).ToString() + ": CORRECT\n";
            baseScore = 100;
            answerText.text = "CORRECT";
            Answer.alpha = 1;
            StartCoroutine(TransitionToNextQuestion());
        }
        else {
            if (baseScore == 100) {
                GameManager.questionLog += "Question " + (count++).ToString() + ": INCORRECT\n";
            }
            baseScore -= 25;
            answerText.text = "INCORRECT";
            Answer.alpha = 1;
            StartCoroutine(TransitionAnswer());
            if (answerIndex == 0) { answerTriangleText.enabled = false; triangleButton.enabled = false; }
            else if (answerIndex == 1) { answerDiamondText.enabled = false; diamondButton.enabled = false; }
            else if (answerIndex == 2) { answerCircleText.enabled = false; circleButton.enabled = false; }
            else { answerSquareText.enabled = false; squareButton.enabled = false; }
        }
    }

    void CreateText() {
        string path = Application.dataPath + "/Scores.txt";
        if (!File.Exists(path)) {
            File.WriteAllText(path, "");
        }
        File.AppendAllText(path, GameManager.questionLog);
        File.AppendAllText(path, GameManager.Score.ToString() + " - " + System.DateTime.Now + "\n########################################################################\n");
    }

}
