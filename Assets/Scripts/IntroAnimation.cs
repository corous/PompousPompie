using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    public List<string> messages = new List<string>();
    public TextFill textFillAnimator;
    public PompousPompie pompousPompie;
    public GameObject cage;
    public GameObject princess;
    public BlackPanel blackPanel;  

    public void OnIntroAnimationFinish()
    {
        StartCoroutine(WaitForMethod(1f, () => 
        {
            blackPanel.Animate(() => 
            {
                pompousPompie.gameObject.SetActive(true);
                princess.SetActive(true);
                cage.SetActive(true);
                textFillAnimator.gameObject.SetActive(true);
                pompousPompie.AnimatePompousPompie(true);      

                textFillAnimator.AddDialog("Oh no, the evil Lord Pompous Pompie has taken Princess TeeTee.", () => 
                {
                    textFillAnimator.AddDialog("He might be planning to eat the Princess.", () => 
                    {
                        textFillAnimator.AddDialog("We must save the Princess.", () => StartCoroutine(WaitForMethod(2f, () => blackPanel.Animate(() => gameObject.SetActive(false)))), 1f);
                    }, 1f);
                }, 1f);
            });          
        }));
    }

    private IEnumerator WaitForMethod(float time, System.Action method)
    {
        yield return new WaitForSeconds(time);
        method.Invoke();
    }

}
