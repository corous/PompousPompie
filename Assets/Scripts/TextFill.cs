using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFill : MonoBehaviour
{
    public Text animationTextDialog;
    public float timePerCharacter = 0.1f;

    private string message;
    //private List<string> messages = new List<string>();
    //private int messageIndex = 0;
    private int charIndex = 0;
    private float timer = 0f;
    private bool active = false;

    private System.Action onComplete;

    public void AddDialog(string dialogTxt, System.Action onCompleteTextAnim, float delay = 0f)
    {
        StartCoroutine(AddDialogDelay(dialogTxt, onCompleteTextAnim, delay));
    }

    private IEnumerator AddDialogDelay(string dialogTxt, System.Action onCompleteTextAnim, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        active = true;
        animationTextDialog.text = "";
        onComplete = onCompleteTextAnim;
        message = dialogTxt;
    }

    private void Update()
    {
        if (!active) return;

        timer -= Time.deltaTime;

        while (timer <= 0f)
        {
            timer += timePerCharacter;
            charIndex++;

            string text = message.Substring(0, charIndex);
            text+= "<color=#00000000>" + message.Substring(charIndex) + "</color>";

            animationTextDialog.text = text;

            if (charIndex >= message.Length)
            {              
                charIndex = 0;
                active = false;
                onComplete?.Invoke();
                break;
            }
        }
    }
}
