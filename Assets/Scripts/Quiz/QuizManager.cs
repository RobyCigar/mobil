// QuizManager.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{

    // public QuizQuestion[] quizQuestions;
    public Transform car; // Assign your car object here
    public float redirectPositionZ = 100f;

    // Variable to track the last milestone reached
    private int lastMilestone = 0;

    void Update()
    {
        // Get the car's current position in the z-axis
        float zPosition = car.position.z;

        // Check if the car has reached the next milestone (multiples of 200)
        if ((int)zPosition / 200 > lastMilestone && (int)zPosition % 200 == 0)
        {
            lastMilestone = (int)zPosition / 200;
            RedirectToQuizScene();
        }
    }

    // Function to redirect to the Quiz scene
    void RedirectToQuizScene()
    {
        SceneManager.LoadScene("Quiz"); // Replace "Quiz" with your scene's name
    }

    // public QuizQuestion GetCurrentQuestion()
    // {
    //     return quizQuestions[GlobalVariables.currentQuestionIndex];
    // }
}
