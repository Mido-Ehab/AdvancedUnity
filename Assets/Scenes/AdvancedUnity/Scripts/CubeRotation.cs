using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public GameObject Sphere;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

 
    void Update()
    {
    }

  
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject == Sphere)
        {
            gameObject.transform.Rotate(20, 30, 5);
        }
    }
}
