using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiMissle : MonoBehaviour
{
    public bool smart = true;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            Transform targetPos = target.gameObject.GetComponent<Transform>();
            transform.LookAt(targetPos.position);
            transform.position += (targetPos.position - transform.position).normalized * 20 * Time.deltaTime;
        } else {
            Destroy(this.gameObject);
        }
        Collider[] inrange = Physics.OverlapSphere(transform.position,2);
            if(inrange.Length != 0){
                foreach(Collider colision in inrange){
                    if(colision.gameObject.GetComponent<Missle>() != null){
                        colision.gameObject.GetComponent<Missle>().Explode();
                }
            }
        }

    }
}
