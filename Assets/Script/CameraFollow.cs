using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public float cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        GameController.camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    void LateUpdate()
    {
        if(target != null)
        {
            if(transform.position != target.position)
            {
                //Vector3 targetPos = target.position;
                Vector3 targetPos = new Vector3(target.position.x, target.position.y + cameraOffset);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
