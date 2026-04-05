using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIbuttons : MonoBehaviour
{
    [Header("Start Button Objects")]
    public List<GameObject> startBtnOffObjects;
    public List<GameObject> startBtnOnObjects;

    [Header("Fill Button Objects")]
    public List<GameObject> fillBtnOffObjects;
    public List<GameObject> fillBtnOnObjects;

    [Header("Finish Button Objects")]
    public List<GameObject> finishBtnOffObjects;
    public List<GameObject> finishBtnOnObjects;

    [Header("Narration")]
    public NarrationManager narrationManager;

    [Header("Start Button Narration (Fill Step)")]
    public string[] fillStepNarration;
    public AudioClip fillStepAudio;

    [Header("Titration Narration")]
    public string[] titrationNarration;
    public AudioClip titrationAudio;

    [Header("Final Narration")]
    public string[] finalNarration;
    public AudioClip finalAudio;

    public SliderController sliderController;
    public TextMeshProUGUI finalValue;

    public void StartButton()
    {
        ToggleObjects(startBtnOffObjects, false);
        ToggleObjects(startBtnOnObjects, true);

        narrationManager.PlayNarration(fillStepNarration, fillStepAudio);
    }

    public void FillBurette()
    {
        ToggleObjects(fillBtnOffObjects, false);
        ToggleObjects(fillBtnOnObjects, true);

        narrationManager.PlayNarration(titrationNarration, titrationAudio);
    }

    void ToggleObjects(List<GameObject> list, bool state)
    {
        foreach (GameObject obj in list)
        {
            if (obj != null)
                obj.SetActive(state);
        }
    }

    public void FinishButton()
    {
        ToggleObjects(finishBtnOffObjects, false);
        ToggleObjects(finishBtnOnObjects, true);

        float finalVal = sliderController.GetFinalValue();

        finalValue.text = finalVal.ToString("0.00");

        narrationManager.PlayNarration(finalNarration, finalAudio);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}