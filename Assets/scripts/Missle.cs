using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public Vector3 target;
    public Vector3 start;
    public Vector3 control;

    [SerializeField] float speed;
    [SerializeField] private GameObject exposion;
    float distance;    
    float currentDuration; 
    
    public void Start(){
        start = transform.position;
        control.y = 80;
        control.x = (start.x+(target.x * 1.5f))/2;
        control.z = (start.z+(target.z * 1.5f))/2;
        distance = Mathf.Sqrt((Mathf.Pow(start.x - target.x, 2) + Mathf.Pow(start.z - target.z, 2)));
        Debug.Log(distance);
    }
    
    public void Update(){
        if(target != null){
            this.transform.position = CalculateBezierPoint(currentDuration/distance*speed,start,target,control);
            currentDuration += Time.deltaTime;
        }

        if((transform.position - target).magnitude < .1 ){
            Explode();
        }
                
    }

    private Vector3 CalculateBezierPoint (float t, Vector3 startPosition, Vector3 endPosition, Vector3 controlPoint) {
         float u = 1 - t;
 
         Vector3 point = (u*u) * startPosition;
         point += 2 * u * t * controlPoint;
         point += t * t * endPosition;
 
         return point;
     }

    public void Explode(){
        GameObject.Instantiate(exposion,transform.position,Quaternion.identity);
                Destroy(this.gameObject);
    }
}



