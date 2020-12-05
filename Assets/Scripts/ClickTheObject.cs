using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ClickTheObject : MonoBehaviour
{
    
   //private Collider col;
    private bool isUp = false;
    public SwapManager swapManager;

   // public Color color;

   
    void Start()
    {
        DOTween.Init();
        //col = GetComponent("Collider") as Collider;
        //gameObject.GetComponent<MeshRenderer>().material.color = color;
    }


    private void OnMouseDown()
    {
        //transform.DOMoveY(startPoint.y, 1);//.OnStart(()=>Swap());//.OnStart(() => { col.enabled = false; }).OnComplete(() => { col.enabled = true; });

       //swapManager.renkEsitligi(gameObject);
       swapManager.kaldir(gameObject); 
    }

  
}