using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
  [SerializeField]
  private GameObject Modelo;

  [SerializeField]
  private ParticleSystem Particulas;

  [SerializeField]
  private AudioSource AudioExplosion;

  [SerializeField]
  private float TiempoExplosion = 2;

  [SerializeField]
  private float Velocidad = 8;

  private void Update()
  {
    transform.position += Time.deltaTime * Vector3.up * Velocidad;
  }

  public virtual void Explotar()
  {
    StartCoroutine("CorrutinaExplotar");
  }

  public IEnumerator CorrutinaExplotar()
  {
    Velocidad = 0.0f;
    Modelo.SetActive(false);
    if (Particulas != null)
    {
      Particulas.Play();
    }
    if (AudioExplosion != null)
    {
      AudioExplosion.Play();
    }
    yield return new WaitForSeconds(TiempoExplosion);
    gameObject.SetActive(false);

  }
}
