using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    [SerializeField] public Image Easy, Normal, Hard, Back;
    [SerializeField] public Sprite EasySelect, NormalSelect, HardSelect, BackSelect;
    private float difficulty;
    
    public void OnEasyClick()
    {
        difficulty = 1f;
        Easy.sprite = EasySelect;
        PlayerPrefs.SetFloat("difficulty", difficulty);
        SceneManager.LoadScene("Level1");
    }

    public void OnNormalClick()
    {
        difficulty = 2f;
        Normal.sprite = NormalSelect;
        PlayerPrefs.SetFloat("difficulty", difficulty);
        SceneManager.LoadScene("Level1");
    }

    public void OnHardClick()
    {
        difficulty = 3f;
        Hard.sprite = HardSelect;
        PlayerPrefs.SetFloat("difficulty", difficulty);
        SceneManager.LoadScene("Level1");
    }

    public void OnBackClick()
    {
        Back.sprite = BackSelect;
        SceneManager.LoadScene("StartMenu");
    }
}
