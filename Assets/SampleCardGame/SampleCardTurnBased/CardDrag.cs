using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{
    public enum cardState { cancel, trash, attack }; // -> 부모 스크립트
    [SerializeField] private Transform mousePointer;
    [SerializeField] private Transform sampleCard;
    [SerializeField] private Color[] color;
    private Vector3 firstPos;
    private bool dragable = true;
    private cardState currentCardState = cardState.cancel;
    //TEST
    private GameObject whichEnemy;
    private void Start()
    {
        firstPos = transform.position;
        //thisCard = Random.Range -> 카드 속성과 내용 랜덤, 부모 스크립트 제작
    }

    //다시 코드 개설

    /*
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1);
        transform.position = new Vector3(-firstPos.x, 3.5f, 0);
        transform.parent = null;
        transform.position = mousePointer.position;
        transform.parent = mousePointer;
        dragable = false;
    }
    */

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1);
        transform.parent = null;
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.parent = sampleCard;
        dragable = true;

        if (currentCardState == cardState.cancel)
            transform.position = new Vector3(firstPos.x, -3.5f, 0);
        else if (currentCardState == cardState.trash)
            gameObject.SetActive(false);
        else if (currentCardState == cardState.attack)
        {
            whichEnemy.GetComponent<HPSystem>().HPDamage(1);
            gameObject.SetActive(false);
        }
        else
            transform.position = new Vector3(firstPos.x, -3.5f, 0);

        /*
        switch (currentCardState)
        {
            case cardState.trash:

        }
        */
    }

    private void OnMouseDrag()
    {
        transform.position = mousePointer.position;
    }

    //Use the -> OnTriggerStay()

    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();

        if (other.gameObject.CompareTag("Trash"))
        {
            sprite.color = color[0];
            //sprite.sortingLayerID = 5;
            currentCardState = cardState.trash;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            sprite.color = color[1];
            whichEnemy = other.gameObject;
            currentCardState = cardState.attack;
            //other.gameObject.GetComponent<HPSystem>().HPDamage(card[thisCard]);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();

        sprite.color = new Color(255, 255, 255, 255);
        //sprite.sortingOrder = 0;
        currentCardState = cardState.cancel;

        /*
        if (other.gameObject.CompareTag("Trash"))
        {
            sprite.color = new Color(255, 255, 255, 255);
            currentCardState = cardState.cancel;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            sprite.color = new Color(255, 255, 255, 255);
            currentCardState = cardState.cancel;
        }
        */
    }
}
