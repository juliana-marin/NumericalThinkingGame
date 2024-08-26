using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
   public Renderer espacio_2;
void Start()
{
}
void Update()
{
espacio_2.material.mainTextureOffset =
espacio_2.material.mainTextureOffset + new Vector2(0.02f,0) * Time.deltaTime;
}
}