using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance = null;

  public int Puntuacion;

  public float TiempoPartida;

  public TextMeshProUGUI txtPuntuacion;

  public GameObject Mirilla;

  private void Awake()
  {
    /////// SINGLETON /////////
    /// Copiar esto
    // Comprueba si existe una instancia de GameManager
    if (Instance == null)
    {
      Instance = this; //Si no existe la asignamos a esta
    }
    else if (Instance != this) //Si ya hay una destruye esta
    {
      Destroy(gameObject);
    }
    ////////////////////////////
  }

  private void Update()
  {
    if (Mirilla != null)
    {
      Mirilla.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward*5;
    }

    if (Input.GetMouseButtonDown(0))
    {
      Ray Rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit Impacto;
      Physics.Raycast(Rayo.origin, Rayo.direction, out Impacto, Mathf.Infinity);
      if (Impacto.collider != null)
      {
        Globo GloboColisionado = Impacto.collider.gameObject.GetComponent<Globo>();
        if (GloboColisionado != null)
        {
          GloboColisionado.Explotar();
        }
      }
    }
  }

  public int ActualizarPuntuacion(int inc)
  {
    Puntuacion += inc;
    if (Puntuacion < 0)
    {
      Puntuacion = 0;
    }

    if(txtPuntuacion != null)
    {
      txtPuntuacion.text = Puntuacion.ToString();
    }
    return Puntuacion;
  }
}
