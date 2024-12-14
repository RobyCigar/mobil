// QuizSceneManager.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizSceneManager : MonoBehaviour
{
    // public Text questionText;
    // public Button[] choiceButtons; // Assign buttons for the choices
    // public QuizManager quizManager;

    // private void Start()
    // {
    //     LoadCurrentQuestion();
    // }

    // private void LoadCurrentQuestion()
    // {
    //     if (GlobalVariables.currentQuestionIndex >= quizManager.quizQuestions.Length)
    //     {
    //         // No more questions, end game or redirect
    //         Debug.Log("Quiz complete! Final score: " + GlobalVariables.score);
    //         return;
    //     }

    //     var currentQuestion = quizManager.GetCurrentQuestion();
    //     questionText.text = currentQuestion.question;

    //     for (int i = 0; i < choiceButtons.Length; i++)
    //     {
    //         choiceButtons[i].GetComponentInChildren<Text>().text = currentQuestion.choices[i];
    //         int choiceIndex = i; // Avoid closure issue
    //         choiceButtons[i].onClick.RemoveAllListeners();
    //         choiceButtons[i].onClick.AddListener(() => CheckAnswer(choiceIndex));
    //     }
    // }

    // private void CheckAnswer(int choiceIndex)
    // {
    //     var currentQuestion = quizManager.GetCurrentQuestion();

    //     // Check if the selected choice is correct
    //     if (currentQuestion.choices[choiceIndex] == currentQuestion.answer)
    //     {
    //         GlobalVariables.score++;
    //     }

    //     // Move to the next question
    //     GlobalVariables.currentQuestionIndex++;
    //     SceneManager.LoadScene("CurrentScene"); // Redirect back to the main scene
    // }
    // Variable to track the last milestone reached
    private int lastMilestone = 0;

    private void Awake()
    {
        // Ensure this object persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // Get the car's current position in the z-axis
        float zPosition = transform.position.z;

        // Check if the car has reached the next milestone (multiples of 200)
        if ((int)zPosition / 200 > lastMilestone && (int)zPosition % 200 == 0)
        {
            lastMilestone = (int)zPosition / 200;
            RedirectToQuizScene();
        }
    }
    void RedirectToQuizScene()
    {
        SceneManager.LoadScene("Quiz"); // Replace "Quiz" with your scene's name
    }
    public void RedirectToGame() {
        SceneManager.LoadScene("Game");
    }
}
