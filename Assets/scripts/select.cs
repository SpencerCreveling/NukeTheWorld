using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    public List<GameObject> selected;
    // Start is called before the first frame update
    void Start()
    {
        selected = new List<GameObject>();
    }

    // Update is called once per frame

  
  void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(mouse,out hit)){  //confirmed somthing  was selected
                
                Selectable isvalid = hit.transform.gameObject.GetComponent<Selectable>();//comfirms selected was a valid object
                if(isvalid != null){
                    bool isSelected = false;
                    foreach(GameObject obj in selected){
                        if(hit.transform.gameObject == obj){
                            isSelected = true;
                            break;
                        }
                    }

                    if(!isSelected){
                        selected.Add(hit.transform.gameObject);
                        hit.transform.GetComponent<Renderer>().material.color =  new Color(255, 0, 0);
                    } else {
                        selected.Remove(hit.transform.gameObject);
                        hit.transform.GetComponent<Renderer>().material.color =  new Color(0, 0, 255);
                    }
                } else if(selected.Count != 0 && selected[0].GetComponent<Weapon>() != null) { //tageting nuke?
                    if(selected[0].GetComponent<Silo>()){
                        foreach(GameObject obj in selected){
                            if(obj.GetComponent<Silo>().MissleMode){
                                obj.GetComponent<Silo>().FireAt(hit.point);
                            }
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown("space")){
            foreach(GameObject obj in selected){
                obj.transform.GetComponent<Renderer>().material.color =  new Color(0, 0, 255);
            }
            selected = new List<GameObject>();
        }
        
        if (Input.GetKeyDown(KeyCode.X)){
            foreach(GameObject obj in selected){
                Silo selectedSilo = obj.gameObject.GetComponent<Silo>();
                if(selectedSilo != null){
                    selectedSilo.MissleMode = ! selectedSilo.MissleMode;
                }
            }
        }
    }
}


