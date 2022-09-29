using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameManager : MonoBehaviour
{
    [SerializeField] public Image Play, HowToPlay;
    public Sprite PlayPressed, HowToPlayPressed;
    
    public void OnPlayClick()
    {
        Play.sprite = PlayPressed;
        SceneManager.LoadScene("SelectDifficulty");
    }

    public void OnHowToPlayClick()
    {
        HowToPlay.sprite = HowToPlayPressed;
        SceneManager.LoadScene("HowToPlay");
    }
}
