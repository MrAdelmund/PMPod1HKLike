using Unity.Mathematics;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float spinSpeed;
   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);

        
    }
}

