using UnityEditor;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Question {

    public string question;
    public int correctAnswer;
    public Sprite spriteQuestion;
    public string answerTriangle, answerDiamond, answerCircle, answerSquare;
    
}