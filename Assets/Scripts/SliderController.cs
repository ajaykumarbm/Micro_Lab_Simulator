using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderValueText;

    public GameObject inst;
    public GameObject finishBtn;

    [Header("Narration")]
    public NarrationManager narrationManager;

    [Header("Titration Narration")]
    public string[] titrationNarration;
    public AudioClip titrationAudio;

    [Header("Instrictions")]
    public GameObject instPanelObject;
    public Image panelImage;

    public GameObject instpanelText;
    public TextMeshProUGUI instText;

    public TextMeshProUGUI finalValueStoreText;

    public GameObject ResultColor;
    public GameObject cylinderLiquid;
    public GameObject flaskLiquid;

    private bool hasTriggered = false; 

    private void Start()
    {
          if (slider == null)
        {
            Debug.LogError("Slider not assigned!");
            return;
        }

        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    public float GetSliderValue()
    {
        return slider.value;
    }

    public float GetFinalValue()
    {
        return slider.value;
    }

    void OnSliderChanged(float v)
    {
        if (sliderValueText != null)
            sliderValueText.text = v.ToString("0.00");

        if (!hasTriggered)
        {
            if (panelImage != null) panelImage.enabled = false;
            if (instText != null) instText.enabled = false;
        }

        if (v >= 0.80f && !hasTriggered)
        {
            cylinderLiquid.SetActive(false);

            hasTriggered = true;

            if (panelImage != null) panelImage.enabled = true;
            if (instText != null) instText.enabled = true;

            if (inst != null) inst.SetActive(true);
            if (finishBtn != null) finishBtn.SetActive(true);

            if (narrationManager != null)
                narrationManager.PlayNarration(titrationNarration, titrationAudio);

            //if (finalValueStoreText != null)
            //    finalValueStoreText.text = v.ToString("0.00");

            ResultColor.SetActive(true);
        }
    }
}