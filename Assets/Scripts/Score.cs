using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
     private float points;
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        points += Time.deltaTime;
        textMesh.text = "Puntos: " + points.ToString("0");
    }

    public void AddPoints(float initPoints){
        points += initPoints;
    }

}
