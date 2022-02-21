using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silo : MonoBehaviour
{
    [SerializeField] private GameObject missle;
    [SerializeField] private GameObject antiMissle;
    [SerializeField] GameObject antiair;
    public bool isSelected;
    public int health = 3;
    GameObject antiAirMode;
    public bool MissleMode = true;
    float antiAirCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(0,0,255);
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        antiAirMode = GameObject.Instantiate(antiair,currentPos,Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        antiAirMode.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
        antiAirMode.GetComponent<MeshRenderer>().enabled = !MissleMode;
        this.GetComponent<MeshRenderer>().enabled = MissleMode;

        if(!MissleMode){
            if(antiAirCooldown <= 0){
                antiAirCooldown = 3;
                Collider[] inrange = Physics.OverlapSphere(transform.position,50);
                if(inrange.Length != 0){
                    foreach(Collider colision in inrange){
                        if(colision.gameObject.GetComponent<Missle>() != null){
                            Vector3 startPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                            AntiMissle createdAntiMissle = GameObject.Instantiate(antiMissle,startPos,Quaternion.identity).GetComponent<AntiMissle>();
                            createdAntiMissle.GetComponent<AntiMissle>().target = colision.gameObject;
                            break;
                        }
                    }
                }
            } else{antiAirCooldown -= Time.deltaTime;}
        }



    }

    public void Hit(){
        health -= 1;
        if (health ==  0){
            Destroy(this.gameObject,.5f);
            Destroy(antiAirMode,.5f);
        }
    }

    public void FireAt(Vector3 target){
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Missle createdMissle = GameObject.Instantiate(missle,startPos,Quaternion.identity).GetComponent<Missle>();
        createdMissle.target = target;
    }

    public void Switch(){

    }
}
