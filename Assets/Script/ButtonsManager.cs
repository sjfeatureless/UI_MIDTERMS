using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    private bool isZoomOut = false;
    private bool isFlyOut = false;
    private Vector3 originalPosition;
    private bool isFlippedOut = false;
    public float speed;
    public float shakeDuration = 1f;
    public float shakeStrength = 10f;
    public float flashDuration = 0.2f;
    public int flashCount = 3;
    public Color flashColor = Color.white;
    private Color originalColor;
   


    public void Zoom()
    {
       

        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fading()
    {
       

        imageToScale.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
        imageToScale.CrossFadeAlpha(10f, 4f, false);
    }

    public void Fly()
    {
 

        Vector3 endPosition = isFlyOut ? originalPosition : originalPosition + new Vector3(600f, 0, 0);
        imageToScale.transform.DOLocalMove(endPosition, 0.1f);
        isFlyOut = !isFlyOut;
    }
    public void Flip()
    {
        

        if (isFlippedOut)
        {
            float targetRotation = isFlippedOut ? 2.5f : 0f;
            imageToScale.transform.DORotate(new Vector3(0f, targetRotation, 0f), 0.25f);
        }
        else
        {
            imageToScale.transform.DORotate(new Vector3(0.0f, 180.0f, 0.0f), 0.25f);
        }

        isFlippedOut = !isFlippedOut;
    }

    public void StartShake()
    {
        
        imageToScale.transform.DOShakePosition(shakeDuration, shakeStrength).OnComplete(() =>
         {
           imageToScale.transform.position = originalPosition;
         });
    }

    public void StartFlash()
    {
        Sequence flashSequence = DOTween.Sequence();
       
        for (int i = 0; i < flashCount; i++)
        {
           
            flashSequence.Append(imageToScale.DOColor(flashColor, flashDuration / 2f));
            
            flashSequence.Append(imageToScale.DOColor(originalColor, flashDuration / 2f));
        }

        
        flashSequence.OnComplete(() =>
        {
            imageToScale.color = originalColor;
        });

       
    }








}
