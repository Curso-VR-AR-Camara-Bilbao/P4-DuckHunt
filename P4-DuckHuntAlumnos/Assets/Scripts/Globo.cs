using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
  // He utilizado SerializeField para que Unity pueda ver variables privadas
  [SerializeField]
  private float Velocidad = 8.0f;

  [SerializeField]
  private float TiempoExplosion = 2.0f;

  // Referencias necesarias (le explicamos a Unity dónde está cada cosa)
  [SerializeField]
  private GameObject Modelos;

  [SerializeField]
  private AudioSource AudioExplosion;

  [SerializeField]
  private ParticleSystem Particulas;




  private void Update()
  {
    // En cada fotograma, el globo sube un poco
    Subir();

    // Vamos a comprobar si hemos pulsado en ESPACIO
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Explotar();
    }
  }

  /// <summary>
  /// Función que hace subir el globo
  /// </summary>
  private void Subir()
  {
    transform.position = transform.position + Time.deltaTime * Velocidad * Vector3.up;

    // Es lo mismo que 
    //transform.position += Time.deltaTime * Velocidad * Vector3.up;
  }

  /// <summary>
  /// Función que se ocupa de hacer explotar el globo
  /// </summary>
  public void Explotar()
  {
    // Paramos el objeto
    Velocidad = 0.0f;

    // Hacemos desaparecer los modelos
    Modelos.SetActive(false);

    // Reproducimos la animación de explosión
    Particulas.Play();

    // Reproducimos el sonido de explosión
    AudioExplosion.Play();

    Invoke("DestruirGlobo", TiempoExplosion);
  }
  
  public void DestruirGlobo()
  {
    // Destruimos el GameObject del globo
    Destroy(gameObject);
  }
}
