using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using Vuforia;


public class controller : MonoBehaviour {
    bool is_run = false;
    public GameObject animation;
    List<ImageTargetBehaviour> cartas = new List<ImageTargetBehaviour>();

    ImageTargetBehaviour modo = null;
    void Start() {

    }
    // Update is called once per frame
    // Update is called once per frame
    void Update() {
        if (this.is_run)
        {
            foreach (ImageTargetBehaviour carta in this.cartas)
            {
                if (carta.TargetStatus.Status == Status.TRACKED || carta.TargetStatus.Status == TargetStatus.NotObserved.Status)
                {
                    //Debug.Log(carta.name);
                   // Debug.Log(carta.transform.position);
                }
            }
        }
    }
    public void Set_image_target(ImageTargetBehaviour target) {
        if (!this.cartas.Contains(target)) {
            this.cartas.Add(target);
        }
    }
    public void remove_image_target(ImageTargetBehaviour target)
    {
        if (!this.is_run) {
            this.cartas.Remove(target);
        }
    }
    public bool load_modo(ImageTargetBehaviour modo) 
    {
        if (modo != null) {
            this.modo = modo;
        }
        return this.modo != null; 
    }
    public void start()
    { 
        this.is_run = true;
        var animation_class = animation.GetComponent<Animation>();
        List<no_lista> noList =  retorna_cartas();
        animation_class.iniciar(noList);
    }
    public string get_modo()
    {
        return this.modo.name;
    
    }
    private List<no_lista> retorna_cartas()
    {
        List<no_lista> retorno = new List<no_lista>();

        if (this.cartas != null)
        {
            foreach (ImageTargetBehaviour carta in this.cartas)
            {
                no_lista no = gameObject.AddComponent<no_lista>();
                no.name = carta.name;
                no.postion = carta.transform.position;
                retorno.Add(no);
                no = null;
            }
        }
        else 
        {
            retorno = null;
        }
        return retorno;
    }
    
}