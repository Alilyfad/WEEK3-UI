using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class week3_ui : MonoBehaviour
{

    public GameObject Test_UI;
    public Vector3 TargetPos;
    public Vector3 OriginalPos;
    public float TravelTime;
    public Image TargetImage;
    public float fadeDuration;
    public Vector3 targetRotation;
    public float rotateDuration;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SequenceTween()
    {
        Sequence sequence = DOTween.Sequence();
        //1st task
        sequence.Append(Test_UI.transform.DOLocalMove(TargetPos, TravelTime).SetEase(Ease.InOutElastic));
        //Delay for 2nd task
        sequence.AppendInterval(3);
        sequence.Append(Test_UI.transform.DOScale(Vector3.one, TravelTime).SetEase(Ease.InOutElastic));
        sequence.AppendInterval(3);
        sequence.Append(Test_UI.transform.DOLocalMove(OriginalPos, TravelTime).SetEase(Ease.InOutElastic));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTween()
    {
        Test_UI.transform.DOLocalMove(TargetPos, TravelTime).SetEase(Ease.InOutElastic).OnComplete(()=> ReturnPos());
    }

    public void ReturnPos()
    {
        Test_UI.transform.DOLocalMove(OriginalPos, TravelTime).SetEase(Ease.InOutElastic);
    }

    public void ScaleTween()
    {
        Test_UI.transform.DOScale(Vector3.zero, TravelTime).SetEase(Ease.InOutElastic);
    }

    public void FadeTween()
    {
        TargetImage.DOFade(0, fadeDuration);
    }

    public void Rotation()
    {
        TargetImage.transform.DOLocalRotate(targetRotation, rotateDuration).SetEase(Ease.InOutElastic).SetLoops(10, LoopType.Yoyo);
    }
}
