using UnityEngine;

public class DetectorStalker : MonoBehaviour
{
    public Transform stalker;
    public Camera cam;
    public float anguloVisao = 50f;
    public float distanciaMaxima = 25f;


    public float distancia;
    public bool stalkerVisivel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diracao = stalker.position - cam.transform.position;
        Vector3 noChao = new Vector3(stalker.position.x, transform.position.y, stalker.position.z);
        distancia = Vector3.Distance(transform.position, noChao);
        float angulo = Vector3.Angle(cam.transform.foward, diracao);
        stalkerVisivel = angulo <= anguloVisao && distancia <= distanciaMaxima;
        
    }
}
