using UnityEngine;

public class GlobalVariables : MonoBehaviour
{

    [System.Serializable]
    public class QuizQuestion
    {
        public string question;
        public string[] choices;
        public string answer;
    }
    public static int score = 0; // Global score
    public static int currentQuestionIndex = 0; // Track the current question

}