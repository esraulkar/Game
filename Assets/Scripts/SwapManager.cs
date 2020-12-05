using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class SwapManager : MonoBehaviour
{

    public GameObject firstPiece;
    public GameObject secondPiece;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void kaldir(GameObject obj)
    {

        if (firstPiece == null)
        {
            firstPiece = obj;
            firstPiece.transform.DOMoveY(firstPiece.transform.position.y + 3, 1).OnStart(() => { firstPiece.GetComponent<BoxCollider>().enabled = false; }).SetEase(Ease.OutQuad).OnComplete(() => {firstPiece.GetComponent<BoxCollider>().enabled = true; }) ;


        }
        else if (obj == firstPiece)
        {
            indir(firstPiece);
            firstPiece = null;
            
        }
        else if (secondPiece==null)
        {
            secondPiece = obj;
            secondPiece.transform.DOMoveY(secondPiece.transform.position.y + 2, 1).OnStart(()=> { secondPiece.GetComponent<BoxCollider>().enabled = false; firstPiece.GetComponent<BoxCollider>().enabled = false; }).SetEase(Ease.OutQuad).OnComplete(() => {
                swap();
            });
        }
        
    }

    public void indir(GameObject go)
    {
        go.transform.DOMoveY(0, 1).OnStart(()=> { go.GetComponent<BoxCollider>().enabled = false; }).OnComplete(() => {
            go.GetComponent<BoxCollider>().enabled = true;
            renkEsitligi(go);
        });
       
    }

    public GameObject yandakiObjeyiBulma(GameObject obj)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("cube");
        GameObject nextObject = null;
        Vector3 position = obj.transform.position;
        foreach (GameObject go in gos)
        {
            double difz = go.transform.position.z - position.z;
            int diffz = (int)difz;
            if (go!=obj && diffz==0)
            {
                nextObject = go;
            }
        }
        
        return nextObject;
    }

    public void renkEsitligi(GameObject obj)
    {
        Color objPieceColor, nextPieceColorx;
        GameObject nextPiecex;
        
        //nextPiece = yandakiObjeyiBulma(obj);
        nextPiecex = yandakiObjex(obj);
        //nextPiecez = yandakiObjez(obj);
       // print(nextPiecex + " dnndamdm" + nextPiecez);
        objPieceColor = obj.GetComponent<Renderer>().material.GetColor("_Color");
        nextPieceColorx = nextPiecex.GetComponent<Renderer>().material.GetColor("_Color");
       // nextPieceColorz = nextPiecez.GetComponent<Renderer>().material.GetColor("_Color");
        if (objPieceColor.Equals(nextPieceColorx))
        {
            print(obj+"aynı renkteler"+nextPiecex);
        }
        else
        {
            print(obj+"aynı renkte değiller"+nextPiecex);
        }
      
    }
    public GameObject yandakiObjex(GameObject obj)
    {
        RaycastHit hit;
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("cube");
        GameObject nextPiece=null;
        foreach (GameObject go in gos)
        {
            if (Physics.Raycast(obj.transform.position, obj.transform.right, out hit, 8.46f))
            {
                if (hit.collider.gameObject==go)
                {

                    print("saginda"+go);
                    nextPiece = go;
                }

            }
            else if (Physics.Raycast(obj.transform.position, -obj.transform.right, out hit, 8.46f))
            {
                if (hit.collider.gameObject==go)
                {
                    print("solunda"+go);
                    nextPiece = go;  
                }

            }

        }
        return nextPiece;
    }
    /* public GameObject yandakiObjez(GameObject obj)
     {
         RaycastHit hit;
         GameObject[] gos;
         gos = GameObject.FindGameObjectsWithTag("cube");
         GameObject nextPiece = null;
         foreach (GameObject go in gos)
         {
            // print(go);
            // print(obj.transform.position);
             if (Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 4.00f))
             {
                 //print("ife girdi");
                 if (hit.collider.gameObject == go)
                 {

                     print("asagısında" + go);
                     nextPiece = go;
                 }

             }
             else if (Physics.Raycast(obj.transform.position, -obj.transform.forward, out hit, 4.00f))
             {
                 if (hit.collider.gameObject == go)
                 {
                     print("yukarısında" + go);
                     nextPiece = go;
                 }

             }

         }
         return nextPiece;
     }*/
    public void swap()
    {
        Vector3 temp;
        temp = firstPiece.transform.position;
        firstPiece.transform.DOMove(new Vector3(secondPiece.transform.position.x, firstPiece.transform.position.y, secondPiece.transform.position.z), 1).SetEase(Ease.OutSine);
        secondPiece.transform.DOMove(new Vector3(temp.x, secondPiece.transform.position.y, temp.z), 1).SetEase(Ease.OutSine).OnComplete(()=> {
            indir(firstPiece);
            indir(secondPiece);
            //renkEsitligi(firstPiece);
            //renkEsitligi(secondPiece);
            firstPiece = null;
            secondPiece = null;
        });
        
    }


}
