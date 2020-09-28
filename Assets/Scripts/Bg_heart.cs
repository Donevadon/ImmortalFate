using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg_heart : MonoBehaviour
{


    [SerializeField] private Vector3 Strt_Vc;
    [SerializeField] private Vector3 End_Vc;

    private bool what_tix;

    void Start()
    {
        Strt_Vc = this.gameObject.GetComponent<Transform>().position;
        Invoke("Heart_one", 2f);
    }

    private void Heart_one () 
    {
        this.gameObject.transform.position = End_Vc;
        Invoke("Heart_two", 0.1f);
    }

    private void Heart_two () 
    {
        this.gameObject.transform.position = Strt_Vc;
        Invoke("Heart_one", 1.9f);
    }


}
