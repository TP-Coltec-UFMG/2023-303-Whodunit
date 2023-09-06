using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public TMP_Text speechText;
    public TMP_Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(string[] txt, string actorName){
        if(PlayerPrefs.GetInt("estaTocando")==0){
        PlayerPrefs.SetInt("estaTocando", 1);
        dialogueObj.SetActive(true);
        sentences=txt;
        actorNameText.text=actorName;
        StartCoroutine(TypeSentence());
        }
         Debug.Log(PlayerPrefs.GetInt("estaTocando"));
    }

    IEnumerator TypeSentence(){
        foreach(char letter in sentences[index].ToCharArray()){
            speechText.text+=letter;
            yield return new WaitForSeconds(this.typingSpeed);
        }
    }

    public void NextSentence(){
        if(speechText.text == sentences[index]){
            if(index<sentences.Length - 1){
                index++;
                speechText.text="";
                StartCoroutine(TypeSentence());
            }else{
                PlayerPrefs.SetInt("estaTocando", 0);
                Debug.Log(PlayerPrefs.GetInt("estaTocando"));
                speechText.text="";
                index=0;
                dialogueObj.SetActive(false);
            }
        }
    }

}