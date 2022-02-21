using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float growthRate;
    public float MaxSize = 20;
    
    void Start()
    {
        transform.localScale = new Vector3(.1f,.1f,.1f);
        Collider[] hits = Physics.OverlapSphere(transform.position,MaxSize/2);
        foreach(Collider col in hits){
                Silo siloHit = col.gameObject.GetComponent<Silo>();
                if (siloHit != null){
                    siloHit.Hit();
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < MaxSize){
            transform.localScale += Vector3.one *  growthRate * Time.deltaTime;
        }
        else{
            Destroy(this.gameObject);
        }
    }
}
