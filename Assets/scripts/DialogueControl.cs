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
        dialogueObj.SetActive(true);
        sentences=txt;
        actorNameText.text=actorName;
        Debug.Log("speech");
        
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence(){
        foreach(char letter in sentences[index].ToCharArray()){
            speechText.text+=letter;
            yield return new WaitForSeconds(this.typingSpeed);
        }
    }

    public void NextSentence(){
        if(dialogueObj.GetComponentInChildren<TMP_Text>().text!=sentences[index]){
            speechText.text="";
            StopAllCoroutines();
            dialogueObj.GetComponentInChildren<TMP_Text>().text=sentences[index];
            index++;
        }else{
            Debug.Log("entrei");
        if(speechText.text == sentences[index]){
                StartCoroutine(TypeSentence());
            if(index<sentences.Length - 1){
                index++;
                Debug.Log(index);
                speechText.text="";
                Debug.Log("speech2");
            }else{
                Debug.Log("entrei aqui");
                speechText.text="";
                index=0;
                dialogueObj.SetActive(false);
            }
        }
            
        }
    }

}
