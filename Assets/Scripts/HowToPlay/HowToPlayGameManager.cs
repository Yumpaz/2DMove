using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlayGameManager : MonoBehaviour
{
    [SerializeField] public Image Back, Next, Tutorial;
    public Sprite BackPressed, BackNormal, NextPressed, NextNormal, HUD, HowToMove, HowToDown, HowToDash, HowToAttack, EnemyCard;
    private int list;

    private void Awake()
    {
        list = 0;
    }

    public void OnBackClick()
    {
        Back.sprite = BackPressed;
        StartCoroutine(OnBackSecond());
        switch(list){
            case(0):
                SceneManager.LoadScene("StartMenu");
                break;
            case(1):
                list = 0;
                Tutorial.sprite = HUD;
                break;
            case (2):
                list = 1;
                Tutorial.sprite = HowToMove;
                break;
            case (3):
                list = 2;
                Tutorial.sprite = HowToDown;
                break;
            case (4):
                list = 3;
                Tutorial.sprite = HowToDash;
                break;
            case (5):
                list = 4;
                Tutorial.sprite = HowToAttack;
                break;
        }
    }

    public IEnumerator OnBackSecond()
    {
        yield return new WaitForSeconds(0.2f);
        Back.sprite = BackNormal;
    }

        public void OnNextClick()
    {
        Next.sprite = NextPressed;
        StartCoroutine(OnNextSecond());
        switch (list)
        {
            case (0):
                list = 1;
                Tutorial.sprite = HowToMove;
                break;
            case (1):
                list = 2;
                Tutorial.sprite = HowToDown;
                break;
            case (2):
                list = 3;
                Tutorial.sprite = HowToDash;
                break;
            case (3):
                list = 4;
                Tutorial.sprite = HowToAttack;
                break;
            case (4):
                list = 5;
                Tutorial.sprite = EnemyCard;
                break;
            case (5):
                SceneManager.LoadScene("SelectDifficulty");
                break;
        }
    }

    public IEnumerator OnNextSecond()
    {
        yield return new WaitForSeconds(0.2f);
        Next.sprite = NextNormal;
    }
}
