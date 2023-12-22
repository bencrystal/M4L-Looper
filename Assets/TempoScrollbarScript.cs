using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TempoScrollbarScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tempoText;

    [SerializeField]
    private Scrollbar tempoScrollbar;

    // Start is called before the first frame update
    void Start()
    {
        if (tempoText == null)
        {
            tempoText = GetComponentInChildren<TextMeshProUGUI>();
        }

        // Ensure that the Scrollbar is assigned
        if (tempoScrollbar != null)
        {
            // Add a listener to call textUpdate when the Scrollbar's value changes
            tempoScrollbar.onValueChanged.AddListener(textUpdate);

            // Initialize the text based on the current Scrollbar value
            textUpdate(tempoScrollbar.value);
        }
    }

    // This method will be called whenever the Scrollbar's value changes
    public void textUpdate(float value)
    {
        tempoText.text = Mathf.RoundToInt(value * 120 + 60) + " bpm";
    }
}
