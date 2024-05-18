using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TiempoFiguras : MonoBehaviour
{
   
[SerializeField] int min, seg;
[SerializeField] TextMeshProUGUI tiempo;

private float restante;
private bool enMarcha;

private void Awake() {

restante = (min * 60) + seg;
enMarcha = true;
}

// Update is called once per frame
void Update()
  {
    if (enMarcha)
    {
    restante -= Time.deltaTime;
        if (restante < 1)
        {
        enMarcha = false;
         SceneManager.LoadScene("GameOver");
        // MATAR AL PLAYER
        }
        int tempMin = Mathf. FloorToInt(restante / 60);
        int tempSeg = Mathf. FloorToInt(restante % 60);
        tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
    }
  }
}
