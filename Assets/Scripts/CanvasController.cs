using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public GameObject shop;
    public Button btnShop;
    public Button btnBack;
    

    void Start()
    {
        btnShop.GetComponent<CanvasRenderer>().SetAlpha(0);
        //btnShop.onClick.AddListener(() => openShop());
        btnBack.onClick.AddListener(() => closeShop());

        shop.SetActive(false);
    }

    private void openShop(){
        shop.SetActive(true);
        StartCoroutine(FadeInShop());
    }

    private void closeShop(){
        StartCoroutine(FadeOutShop());
    }


    IEnumerator FadeInShop()
    {
        shop.GetComponent<CanvasGroup>().alpha = 0f;
        float fZwischenergebnis = 1;
        while (shop.GetComponent<CanvasGroup>().alpha < 1)
        {
            fZwischenergebnis -= Time.deltaTime * 1;
            shop.GetComponent<CanvasGroup>().alpha = 1 - fZwischenergebnis;
            yield return null;
        }
    }

    IEnumerator FadeOutShop()
    {
        while (shop.GetComponent<CanvasGroup>().alpha > 0)
        {
            shop.GetComponent<CanvasGroup>().alpha = shop.GetComponent<CanvasGroup>().alpha - Time.deltaTime * 1;
            yield return null;
        }

        shop.SetActive(false);
    }    
}
