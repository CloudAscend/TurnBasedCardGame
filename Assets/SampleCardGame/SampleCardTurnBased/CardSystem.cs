using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    [SerializeField] private GameObject attackCards;
    [SerializeField] private GameObject cardPrefab;
    private void Start()
    {
        //Instantiate(cardPrefab, );
        StartCoroutine(SetCard());
    }

    private IEnumerator SetCard()
    {
        Animator anim = attackCards.GetComponent<Animator>();

        /*
        for (int i = 0; i < 5; i++)
        {
            cardPrefab[].SetActive(true)
            cardPrefab[]
        }
        */
        
        anim.enabled = true;

        yield return new WaitForSeconds(1.6f);

        anim.enabled = false;
    }
}
