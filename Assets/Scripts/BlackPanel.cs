using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPanel : MonoBehaviour
{
    private System.Action onCompleteAnim;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Animate(System.Action onComplete)
    {
        onCompleteAnim = onComplete;
        animator.SetTrigger("BlackPanelAnim");
    }

    public void OnComplete()
    {
        onCompleteAnim?.Invoke();
    }
}
