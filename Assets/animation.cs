using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour{
    List<GameObject> cartas = null;
    string status = "nao iniciado";
    string estado = "nao iniciado";
    public GameObject instace_circuito;

    public void iniciar(List<no_lista> lista_cartas) { 
        if (montar(lista_cartas)) 
        {
            this.status = "iniciado";
            this.estado = "iniciado";
        }
    }
    private bool montar(List<no_lista> lista_cartas) {
        if (lista_cartas != null) {
            this.cartas = new List<GameObject>();
            foreach (no_lista carta in lista_cartas ) {
                GameObject instance = Instantiate(instace_circuito, carta.postion, transform.rotation);
                Vector3 position = instance.transform.position;
                position.z += 100;
                instance.transform.position = position;
                Debug.Log(instance.transform.position);
                cartas.Add(instance);
            }
        }  
        return false;
    }
    public void Start()
    {
        
    }


}