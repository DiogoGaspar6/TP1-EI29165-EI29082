using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class Request : MonoBehaviour
{  
    public string[] order;
    public BoxCollider trigger;
    public GameObject player;
    public GameObject register;
    public GameObject box;
    public TextMeshProUGUI pedidos;
    public TextMeshProUGUI scoreText;
    private List<string> randomOrder;
    // public List<string> tags;
    public LayerMask layer;
    public int score;


    void Start(){
        trigger.enabled = true;
        pedidos.enabled = true;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.B)){
            float distance = Vector3.Distance(player.transform.position, register.transform.position);
            if(distance <= 1){
                getObjects();
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "trigger"){
            Debug.Log("O trigger ativou");
            trigger.enabled = false;
            randomOrder = GenerateOrder();
            string orderString = "Pedido: ";
            foreach (string item in randomOrder)
            {
                orderString += item + ", ";
            }
            Debug.Log(orderString.TrimEnd(',', ' '));
            pedidos.text = orderString.TrimEnd(',', ' ');

            
        }
    }

    List<string> GenerateOrder(){
        int numItens = Random.Range(2, 4);
        List<string> itens = new List<string>();

        for(int i = 0; i < numItens; i++){
            int index = Random.Range(0, order.Length);
            itens.Add(order[index]);
        }

        return itens;
    }
    void getObjects(){
        RaycastHit[] hits = Physics.SphereCastAll(box.transform.position, 0.5f ,Vector3.up, Mathf.Infinity, layer);
        Debug.Log("produto: " + hits.Length);
        List<string> objects = new List<string>();
        foreach(RaycastHit hit in hits){
            string productName = hit.collider.gameObject.tag;
            objects.Add(productName);
        }

        checkOrder(objects);
    }
    void checkOrder(List<string> detectedProducts){
        bool isCorrect = true;
        List<GameObject> deliveredObjects = new List<GameObject>();

        foreach(string item in randomOrder){
            if(!detectedProducts.Contains(item)){
                isCorrect = false;
            }
        }
        if(isCorrect){
            score += 100;
            scoreText.SetText("Pontuação: " + score);
            Debug.Log("pedido correto");

            foreach(string item in detectedProducts){
                GameObject obj = GameObject.FindGameObjectWithTag(item);
                if(obj != null) {
                    deliveredObjects.Add(obj);
                }
            }
            foreach(GameObject obj in deliveredObjects){
                Destroy(obj);
            }
            
        }else {
            score -= 50;
            scoreText.SetText("Pontuação: " + score);
            Debug.Log("pedido errado");
        }
    }
}

