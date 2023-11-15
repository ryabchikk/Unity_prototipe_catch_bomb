using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] private LeanTweenType inType;
    [SerializeField] private LeanTweenType outType;
    [SerializeField] private float duration;
    [SerializeField] private float delay;
    [SerializeField] private UnityEvent onCompleteCallback;
    public void OnEnable()
    {
        transform.localScale = new Vector3 (0f, 0f, 0f);
        LeanTween.scale(gameObject,new Vector3(1,1,1),duration).setDelay(delay).setOnComplete(OnComplete);
    }
    public void OnComplete()
    {
        if(onCompleteCallback != null) { 
            onCompleteCallback.Invoke();
        }
    }
}
