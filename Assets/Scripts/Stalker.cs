using UnityEngine;

public class Stalker : MonoBehaviour
{

    
    public Transform target;
    public float speed = 3f;
    public float distanciaParar = 1.2f;
    private bool agarrou = false;

    void Start()
    {
        
    }

    void Update()
    {
        
        if (agarrou)
        {
            return;
        }
        Vector3 destino = new Vector3(target.position.x, transform.position.y, target.position.z);
        float distancia = Vector3.Distance(transform.position, destino);
        if (distancia <= distanciaParar)
        {
            agarrou = true;
            Debug.Log("Stalker te agarrou!");
            return;
        }
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, destino, step);
    }
}
