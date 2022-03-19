using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Speech : MonoBehaviour
{
    bool isTextAtEnd;
    string textToLoadIn;
    int currentLine = 0;

    public UnityEvent onEndSpeech;
    public GameObject speechUIObj;
    public Image background;
    public Image portrait;
    public TextMeshProUGUI title;
    public TextMeshProUGUI content;
    public Image contarrow;

    public enum Emotion { NEUTRAL, HAPPY, EMBARASSED, SHOCKED, SAD };
    [System.Serializable]
    public class SpeechLine
    {
        public Character character;
        public string text;
        public Emotion emotion;
        [Tooltip("Use this to trigger functions or animations or music or whatever really!")]
        public UnityEvent lineEvent;
    }
    public SpeechLine[] lines;

    private void Start()
    {
        ResetObjs();
    }
    void ResetObjs()
    {
        speechUIObj.SetActive(false);
        currentLine = 0;
    }
    float time;
    [Range(0.2f, 0.01f)] public float textSpeed;
    int tracker;
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= textSpeed)
        {
            if (content.maxVisibleCharacters != content.text.Length)
            {
                content.maxVisibleCharacters++;
            }
            time = 0;
        }

        if (content.maxVisibleCharacters == content.text.Length)
        {
            contarrow.gameObject.SetActive(true);
        }

        if(speechUIObj.activeSelf && Input.GetMouseButtonDown(0) && currentLine >0)
        {
            OnInteract();
        }
    }
    public void Speak() //maybe make setup more efficient somehow?
    {
        if (currentLine == 0 || currentLine != lines.Length)
        {
            content.maxVisibleCharacters = 0;
            contarrow.gameObject.SetActive(false);

            Character character = lines[currentLine].character;
            background.color = character.backgroundColor;
            if (character.backgroundImage != null) { background.sprite = character.backgroundImage; } //need to add elses to these to revert to a default
            if (character.continueArrow != null) { contarrow.sprite = character.continueArrow; }

            switch (lines[currentLine].emotion)
            {
                case Emotion.NEUTRAL:
                    portrait.sprite = character.neutral;
                    break;
                case Emotion.HAPPY:
                    portrait.sprite = character.happy;
                    break;
                case Emotion.SAD:
                    portrait.sprite = character.sad;
                    break;
                case Emotion.EMBARASSED:
                    portrait.sprite = character.embarassed;
                    break;
                case Emotion.SHOCKED:
                    portrait.sprite = character.shocked;
                    break;
                default:
                    portrait.sprite = character.neutral;
                    break;
            }

            title.text = character.charName;
            title.color = character.titleColor;
            if (character.font != null) { content.font = character.font; }
            content.text = lines[currentLine].text;
            content.color = character.speechColor;

            if (!speechUIObj.activeSelf) 
            {
                speechUIObj.SetActive(true);
            }

            currentLine++;
        }
        else
        {
            ResetObjs();
        }
    }

    public void OnInteract()
    {
        if (content.maxVisibleCharacters < content.text.Length)
        {
            content.maxVisibleCharacters = content.text.Length;
            contarrow.gameObject.SetActive(true);
        }
        else
        {
            Invoke("Speak", 0.2f);
        }
    }
}
