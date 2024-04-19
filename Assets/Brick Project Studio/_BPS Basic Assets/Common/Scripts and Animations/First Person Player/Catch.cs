using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public int distance = 15;
    public LayerMask layer;

    public List<string> tagsObjects;

    public List<Transform> handPosition;

    public bool catch_ = false;
    private bool alreadyCatch = false;
    private List<Transform> object_ = new List<Transform>();

    // Update is called once per frame
    void Update()
    {   
        if(catch_){
            if(Input.GetKeyDown(KeyCode.E)){
                catch_ = false;
                alreadyCatch = false;
                object_.Clear();
            }
            int index = 0;
            foreach(Transform objs in object_){
                objs.position = handPosition[index].position;
                objs.rotation = handPosition[index].rotation;
            }
        }
        RaycastHit[] hit = new RaycastHit[8];
        int numHits = Physics.RaycastNonAlloc(transform.position, transform.forward, hit, distance, layer, QueryTriggerInteraction.Ignore);
        if(numHits > 0){
            if(Input.GetKeyDown(KeyCode.E)){
                object_.Clear();
                for(int i = 0; i < numHits; i++){
                    string tag = tagsObjects.Find((tag) => {
                        if(hit[i].transform.gameObject.tag == tag){
                            alreadyCatch = true;
                            return true;
                        }else{
                            return false;
                        }
                    });
                    if(tag != null){
                        object_.Add(hit[i].transform);

                        RaycastHit hitAbove;
                        if(Physics.Raycast(hit[i].point + Vector3.up, Vector3.down, out hitAbove, Mathf.Infinity, layer, QueryTriggerInteraction.Ignore)){
                            string tagAbove = tagsObjects.Find((tag) => tag == hitAbove.transform.gameObject.tag);
                            if(tagAbove != null){
                                object_.Add(hit[i].transform);
                            }
                        }
                    }
                }
            }
                if(object_.Count > 0){
                    catch_ = true;
                }
            }
        }

}
