using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class CountdownController : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Reference to the TextMeshPro text
    public GameObject countdownCanvas; // Reference to the Countdown UI

    public IEnumerator StartCountdown(Action onCountdownComplete)
    {
        countdownCanvas.SetActive(true);

        // Countdown from 3 to 1
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        // Display "GO!!!"
        countdownText.text = "GO!!!";
        yield return new WaitForSecondsRealtime(1f);

        countdownCanvas.SetActive(false);

        // Trigger the callback
        onCountdownComplete?.Invoke();
    }
}
