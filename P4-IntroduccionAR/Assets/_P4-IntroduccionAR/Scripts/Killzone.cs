using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    Globo globo = other.gameObject.GetComponent<Globo>();
    if (globo != null)
    {
      Destroy(globo.gameObject);
    }
  }
}
