using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject cam;
    public float speed = 1.0f;
    void Start()
    {
        
    }

   
    void Update()
    {
        cam.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
