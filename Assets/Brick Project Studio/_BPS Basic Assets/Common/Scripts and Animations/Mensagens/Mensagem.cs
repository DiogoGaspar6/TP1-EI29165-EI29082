using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mensagem : MonoBehaviour
{   
    public TextMeshProUGUI text;
    public GameObject player;

    private float distance = 2;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance){
            text.enabled=true;
        }else{
            text.enabled=false;
        }
    }
}
