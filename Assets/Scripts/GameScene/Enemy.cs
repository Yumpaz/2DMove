using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int xrandom;
    private string Status;
    public Sprite rock, paper, scissors, empty;
    public GameObject StatusCard;
    private Rigidbody2D rb;
    public static Enemy Instance;

    private void Awake()
    {
        SetEnemyStatus();
        HideStatus();
        rb = this.GetComponent<Rigidbody2D>();
        Instance = this;
    }

    private void Update()
    {
        rb.velocity = new Vector3(0, -PlayerPrefs.GetFloat("difficulty"), 0);
    }

    private void SetEnemyStatus()
    {
        xrandom = Random.Range(0, 3);
        switch (xrandom)
        {
            case (0):
                Status = "rock";
                break;
            case (1):
                Status = "paper";
                break;
            case (2):
                Status = "scissors";
                break;
        }
    }

    public void ShowStatus()
    {
        switch (Status)
        {
            case ("rock"):
                StatusCard.GetComponent<SpriteRenderer>().sprite = rock;
                break;
            case ("paper"):
                StatusCard.GetComponent<SpriteRenderer>().sprite = paper;
                break;
            case ("scissors"):
                StatusCard.GetComponent<SpriteRenderer>().sprite = scissors;
                break;
        }
    }

    public IEnumerator HideEnemyStatus()
    {
        yield return new WaitForSeconds(0.2f);
        HideStatus();
        yield return new WaitForSeconds(0.2f);
        ShowStatus();
        yield return new WaitForSeconds(0.2f);
        HideStatus();
        yield return new WaitForSeconds(0.2f);
        ShowStatus();
        yield return new WaitForSeconds(0.2f);
        HideStatus();
    }

    public void HideStatus2()
    {
        StartCoroutine(HideEnemyStatus());
    }

    public void HideStatus()
    {
        StatusCard.GetComponent<SpriteRenderer>().sprite = empty;
    }

    public string GetEnemyType()
    {
        return Status;
    }
}
