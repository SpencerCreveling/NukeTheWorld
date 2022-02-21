using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Selectable
{
    [SerializeField] private GameObject missle;
    /*public void FireAt(Vector3 target){
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Missle createdMissle = GameObject.Instantiate(missle,startPos,Quaternion.identity).GetComponent<Missle>();
        createdMissle.target = target;
    }*/
}
