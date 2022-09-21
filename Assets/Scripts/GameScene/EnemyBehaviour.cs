using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour Instance;
    private string Status,PStatus;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Status = "paper";
    }

    public void ReceiveDamage()
    {
        PStatus = PlayerBehaviour.Instance.GetStatus();
        switch (PStatus)
        {
            case ("rock"):

                break;
            case ("paper"):

                break;
            case ("scissors"):

                break;
        }
    }
}
