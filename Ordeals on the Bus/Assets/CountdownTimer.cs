using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public ButtonVR spawn;
    public float totalTime = 60f; // Total time for countdown in seconds
    private float timeRemaining; // Time remaining for countdown
    private bool isCountingDown = false; // Flag to check if countdown is active

    public Text countdownText; // Text component to display countdown
    public AudioSource audioSource; // Reference to AudioSource component for playing sound

    void Start()
    {
        timeRemaining = totalTime; // Initialize time remaining
        UpdateTimerDisplay(); // Update the timer display initially
        StartCountdown(); // Start the countdown when the script is enabled
    }

    void Update()
    {
        if (isCountingDown)
        {
            // Countdown the timer
            timeRemaining -= Time.deltaTime;

            // Update the timer display
            UpdateTimerDisplay();

            // Check if the countdown has finished
            if (timeRemaining <= 0)
            {
                timeRemaining = 0; // Ensure timer doesn't go negative
                isCountingDown = false; // Stop the countdown
                Debug.Log("Countdown Finished!"); // Output a message
                InvokeCountdownFinished(); // Invoke the event
            }
        }
    }

    // Start the countdown
    void StartCountdown()
    {
        isCountingDown = true;
    }

    // Update the timer display
    void UpdateTimerDisplay()
    {
        // Format the time remaining as minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update the UI text
        countdownText.text = timeString;
    }

    // Invoke the CountdownFinished event
    void InvokeCountdownFinished()
    {
        spawn.Spawn();
        // Play the sound
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}