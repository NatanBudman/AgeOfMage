using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FraseWrite : MonoBehaviour
{
 
    public string[] Frase;
    public Text text;
    string NextFrase;
    public static int index;
    public static bool IsSelectOptions;
    public static bool IsCompleteDialogue;

    float TimerNextFrame;
    // Start is called before the first frame update
    private void Start()
    {
        StartDialogue();
    }
    //void awake()
    //{
    //    Frase = nextFrase;
    //    StartCoroutine(WordsWrite());
    //}

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if(Frase[index] == text.text && !IsSelectOptions) 
            {
                Frase[index + 1] = NextFrase;
                NextLine();
            }
        }
        if (Frase[index] == text.text)
        {
            TimerNextFrame += TimerNextFrame;

            if (TimerNextFrame >= 2f && !IsSelectOptions)
            {
                Frase[index + 1] = NextFrase;
                NextLine();
            }
            Frase[index + 1] = NextFrase;

        }
        else 
        {
            TimerNextFrame = 0;
        }
        if (Frase[index] == text.text) 
        {
            IsCompleteDialogue = true;

        }
        else
        {
            IsCompleteDialogue = false;

        }
  
    }
     public void StartDialogue() 
    {
        index = 0;
        StartCoroutine(WordsWrite());
    }
  IEnumerator WordsWrite() 
    {
       foreach (char character in Frase[index].ToCharArray()) 
       {
            
           text.text = text.text + character;
           yield return new WaitForSeconds(0.01f);
        }
    }
    public void NextLine() 
    {
        if (index < Frase.Length - 1)
        {
            
            index++;
            text.text = string.Empty;
            StartCoroutine(WordsWrite());
        }
        else 
        {
            gameObject.SetActive(false);
        }
    }
    public void SpeakCutScene(string text)
    {
        NextFrase = text;
    }
}
