using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    float MoveSpeed = 4;
    float MaxDist = 10;
    float MinDist = 5;
 
 
 
 
    void Start () {
    
    }
    
    void Update () {
        transform.LookAt(Player);
        if(Vector3.Distance(transform.position,Player.position) >= MinDist){
            transform.position += transform.forward*MoveSpeed*Time.deltaTime;
            if(Vector3.Distance(transform.position,Player.position) <= MaxDist){
                    //Here Call any function U want Like Shoot at here or something
            }   
        }
    }
}
