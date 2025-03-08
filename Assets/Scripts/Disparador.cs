using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    [SerializeField] GameObject disparo;
    [SerializeField] int cantidadDisparos;
    [SerializeField] List<GameObject> listaDisparos;

    private void Start()
    {
        for (int i = 0; i < cantidadDisparos; i++)
        {
            GameObject objetoDisparo = Instantiate(disparo, this.transform);
            objetoDisparo.SetActive(false);
            listaDisparos.Add(objetoDisparo);
        }
    }

    public GameObject Disparar()
    {
        for (int i = 0; i < listaDisparos.Count; i++)
        {
            if (!listaDisparos[i].activeInHierarchy)
            {
                listaDisparos[i].SetActive(true);
                return listaDisparos[i];
            }
        }

        return null;
    }
}

