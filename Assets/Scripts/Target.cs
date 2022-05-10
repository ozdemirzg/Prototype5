using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;

    private float minSpeed=12;
    private float maxSpeed=16;
    private float maxTorque=10;
    private float xRange=4;
    private float ySpawnPos=-2;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        //GameM. objesi i�inde ki game manager scriptini �a��rd�k.
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        //h�z i�in
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        //D�nmesi i�in
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);;
        //posizyon 
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        //oyun devam ediyorsa t�klay�p yok edebil diye if i�ine ald�k daha �nce yazd�klar�m�z�.
        if(gameManager.isGameActive)
        {
         Destroy(gameObject);
         Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
         //score herbir targete t�klad���m�zda artt�r�yor.
          gameManager.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        Destroy (gameObject);
        //Burada gameOver � yazarsak trigger ile temasta game over yazar ekrana.
        //gameManager.GameOver();
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
    Vector3 RandomForce()
    {
        //bunu asl�nda yukar�da method yerine yazm��t�k.D�zenlemeler iler buraya ald�k. 
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
