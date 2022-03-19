using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public string charName;
    public AudioClip voice;
    public TMP_FontAsset font;
    [Header("Emotion Sprites")]
    public Sprite neutral;
    public Sprite happy;
    public Sprite embarassed;
    public Sprite shocked;
    public Sprite sad;
    [Header("Visual Stylings")]
    public Sprite backgroundImage;
    public Sprite frame;
    public Sprite continueArrow;
    public Color speechColor;
    public Color titleColor;
    public Color backgroundColor;
    
}
