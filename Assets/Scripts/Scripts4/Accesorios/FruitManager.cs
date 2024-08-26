using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FruitManager : MonoBehaviour
{
    public int FrutasRecolectadas = 0;
    public PlayerHealthController Vitalidad;
    private void Update()
{
    allFruitsCollected();
}
    public void allFruitsCollected()
    {
        if(FrutasRecolectadas == 20)
        {
            PlayerHealthController.instance.AumentarVida();
            FrutasRecolectadas = 0;
        }

    }
}
