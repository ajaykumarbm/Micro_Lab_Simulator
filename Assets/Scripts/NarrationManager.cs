using System.Collections;
using TMPro;
using UnityEngine;

public class NarrationManager : MonoBehaviour
{
    [Header("References")]
    public AudioSource audioSource;
    public TextMeshProUGUI instText;

    [Header("Typing Settings")]
    public float timeBtwnChars = 0.02f;
    public float timeBtwnWords = 1f;

    [Header("Welcome Narration")]
    public string[] welcomeNarration;
    public AudioClip welcomeAudio;

    Coroutine typingCoroutine;

    private void Start()
    {
        PlayNarration(welcomeNarration, welcomeAudio);
    }

    public void PlayNarration(string[] sentences, AudioClip clip)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

          instText.text = "";
        instText.maxVisibleCharacters = 0;
        instText.ForceMeshUpdate();

        Debug.Log("Playing Narration: " + (clip != null ? clip.name : "No Audio"));

         if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        typingCoroutine = StartCoroutine(TypeText(sentences));
    }

    IEnumerator TypeText(string[] sentences)
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            instText.text += (i == 0 ? "" : " ") + sentences[i];

            instText.ForceMeshUpdate();

            int totalCharacters = instText.textInfo.characterCount;
            int startChar = instText.maxVisibleCharacters;

            for (int j = startChar; j <= totalCharacters; j++)
            {
                instText.maxVisibleCharacters = j;
                yield return new WaitForSeconds(timeBtwnChars);
            }

            yield return new WaitForSeconds(timeBtwnWords);
        }
    }
}