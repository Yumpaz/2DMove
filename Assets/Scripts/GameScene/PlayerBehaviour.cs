using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour Instance;
    private string Status;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Status = GameManager.Instance.Get1Inventory();//Obtener el estado del jugador, con el primer item del inventario.
    }

    public string GetStatus()
    {
        return Status;
    }
}
