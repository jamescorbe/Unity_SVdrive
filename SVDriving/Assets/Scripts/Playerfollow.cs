using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfollow : MonoBehaviour
{
    public GameObject Player;
    public GameObject cameraLook;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    private Vector3 offset; 
    public float speed;
    private void Awake()
    {
        offset = new Vector3(offsetX,offsetY);
        cameraLook = GameObject.Find("CameraObject").gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
  
    void FixedUpdate()
    {
        UpdateCamerapos();
    }
    private void UpdateCamerapos()
    {
        
       gameObject.transform.position = Vector3.Lerp(transform.position, cameraLook.transform.position+offset,Time.deltaTime * speed);
       gameObject.transform.LookAt(Player.gameObject.transform.position);
    }
 
}
