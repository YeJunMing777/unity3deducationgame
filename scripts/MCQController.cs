using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCQController : MonoBehaviour
{
    // 文本框和复选框的变量
    public Text questionText;
    public Toggle option1;
    public Toggle option2;
    public Toggle option3;
    public Toggle option4;
    public GameObject nextSceneButton; 
    // 提交按钮和得分文本框的变量
    public Button submitButton;
    public Text scoreText;

    // 问题和答案的列表
    private List<Question> questionList;
    private int currentQuestionIndex = 0;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 创建问题和答案列表
        questionList = new List<Question>();
        questionList.Add(new Question("What is the solution to the equation 2x + 3 = 9?", "x = 3", "x = 2", "x = 4", "x = 5", 1));
        questionList.Add(new Question("What is the value of x in the equation 4x - 7 = 17?", "x = 6", "x = 4", "x = 5", "x = 7", 1));
        questionList.Add(new Question("What is the solution to the equation 5x + 2 = 17?", "x = 5", "x = 2", "x = 4", "x = 3", 4));
        questionList.Add(new Question("What is the value of y in the equation 2y - 8 = y?", "y = 10", "y = 6", "y = 4", "y = 8", 4));
        questionList.Add(new Question("What is the solution to the equation 3x - 5 = 7?", "x = 3", "x = 4", "x = 2", "x = 5", 2));
        questionList.Add(new Question("What is the perimeter of a rectangle with length 5 and width 3?", "16", "10", "14", "8", 1));
        questionList.Add(new Question("What is the area of a square with side length 7?", "21", "49", "28", "14", 2));
        questionList.Add(new Question("What is the perimeter of a triangle with sides 6, 8, and 10?", "24", "18", "22", "26", 3));
        questionList.Add(new Question("What is the area of a circle with radius 4?", "16π", "8π", "32π", "64π", 1));
        questionList.Add(new Question("What is the perimeter of a regular hexagon with side length 9?", "54", "63", "72", "81", 2));
        // 其余的问题和答案在这里添加

        // 显示第一个问题
        ShowQuestion();

        // 添加提交按钮的监听器
        submitButton.onClick.AddListener(OnSubmit);
    }

    // 显示当前问题和选项
    void ShowQuestion()
    {
        // 获取当前问题
        Question currentQuestion = questionList[currentQuestionIndex];

        // 显示问题文本
        questionText.text = currentQuestion.question;

        // 显示选项文本
        option1.GetComponentInChildren<Text>().text = currentQuestion.option1;
        option2.GetComponentInChildren<Text>().text = currentQuestion.option2;
        option3.GetComponentInChildren<Text>().text = currentQuestion.option3;
        option4.GetComponentInChildren<Text>().text = currentQuestion.option4;

        // 重置所有复选框的状态
        option1.isOn = false;
        option2.isOn = false;
        option3.isOn = false;
        option4.isOn = false;
    }

    // 当用户提交答案时调用
    void OnSubmit()
    {
        // 获取当前问题和用户选择的答案
        Question currentQuestion = questionList[currentQuestionIndex];

        bool answer1 = option1.isOn;
        bool answer2 = option2.isOn;
        bool answer3 = option3.isOn;
        bool answer4 = option4.isOn;

        // 检查每个选项是否被选择，并确定用户的答案
        int userAnswer = 0;
        if (answer1 && !answer2 && !answer3 && !answer4)
        {
            userAnswer = 1;
        }
        else if (!answer1 && answer2 && !answer3 && !answer4)
        {
            userAnswer = 2;
        }
        else if (!answer1 && !answer2 && answer3 && !answer4)
        {
            userAnswer = 3;
        }
        else if (!answer1 && !answer2 && !answer3 && answer4)
{
userAnswer = 4;
}
    // 如果用户答对了，将得分加10分
    if (userAnswer == currentQuestion.correctAnswer)
    {
        score += 10;
        scoreText.text = "Your Score: " + score;
    }

    // 显示下一个问题或显示分数
    currentQuestionIndex++;
    if (currentQuestionIndex < questionList.Count)
    {
        ShowQuestion();
    }
    else
    {
        if(score>=60){
        questionText.text = "Game over. Congraduation you finish the test and you will back to your world. Your Final Score is：" + score;
        }
        if(score<60){
        questionText.text = "Game over. Unlucky you failed in the test but you can back now. Your Final Score is：" + score;
        }
        nextSceneButton.SetActive(true);
        option1.gameObject.SetActive(false);
        option2.gameObject.SetActive(false);
        option3.gameObject.SetActive(false);
        option4.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
    }
}

// 表示一个问题及其答案的类
class Question
{
    public string question;
    public string option1;
    public string option2;
    public string option3;
    public string option4;
    public int correctAnswer;

    public Question(string q, string o1, string o2, string o3, string o4, int ca)
    {
        question = q;
        option1 = o1;
        option2 = o2;
        option3 = o3;
        option4 = o4;
        correctAnswer = ca;
    }
}
}