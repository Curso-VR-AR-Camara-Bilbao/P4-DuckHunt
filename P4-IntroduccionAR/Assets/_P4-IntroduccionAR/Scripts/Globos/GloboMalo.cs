using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloboMalo : Globo
{
  [SerializeField]
  private int Puntos;

  public override void Explotar()
  {
    base.Explotar();
    GameManager.Instance.ActualizarPuntuacion(-Puntos);
  }
}
