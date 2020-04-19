using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_Manipulate_Rock : MonoBehaviour
{
    public float yOffsetRockCarrying = 0.7f;
    public float xOffsetRockCarrying = -0.7f;

    public GameObject rockOnRange;
    public GameObject rockHolding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Se apertar a tecla de espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Se já estiver segurando uma pedra
            if (rockHolding != null)
            {
                // Solta habilitando ação da gravidade na pedra
                rockHolding.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                rockHolding = null;
                return;
            }
            
            // Se houver uma pedra ao alcance
            if (rockOnRange != null)
            {
                rockHolding = rockOnRange;
                rockOnRange = null;
            }
        }

        // Se estiver segurando a pedra, move junto com o personagem
        if (rockHolding)
        {
            // Verifica se o personagem está indo pra direita ou esquerda pra acertar o offset X
            float inv = GetComponent<SpriteRenderer>().flipX ? 1.0f : -1.0f;
            rockHolding.transform.position = new Vector3(
                transform.position.x + xOffsetRockCarrying*inv,
                transform.position.y + yOffsetRockCarrying,
                rockHolding.transform.position.z
                );
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
            if(collision.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic)
                if(collision.gameObject != rockHolding)
                    rockOnRange = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
            rockOnRange = null;
        }
    }
}
