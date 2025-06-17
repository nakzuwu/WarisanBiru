using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition Instance;
    private Animator animator;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void FadeIn(Action callback=null)
    {
        StartCoroutine(FadeInCoroutine(callback));
    }

    public void FadeOut(Action callback=null)
    {
        StartCoroutine(FadeOutCoroutine(callback));
    }

    private IEnumerator FadeInCoroutine(Action callback)
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);
        callback?.Invoke();
    }

    private IEnumerator FadeOutCoroutine(Action callback)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);
        callback?.Invoke();
    }
}
