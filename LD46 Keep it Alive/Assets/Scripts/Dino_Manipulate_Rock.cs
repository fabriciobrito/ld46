using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_Manipulate_Rock : MonoBehaviour
{
    public float yOffsetRockCarrying = 0.7f;
    public float xOffsetRockCarrying = -0.7f;

    private GameObject rockOnRange;
    private GameObject rockHolding;

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
            }
            else
            {
                // Se houver uma pedra ao alcance
                if (rockOnRange != null)
                {
                    rockHolding = rockOnRange;
                    rockOnRange = null;
                }
            }
        }

        // Se estiver segurando a pedra, move junto com o personagem
        if (rockHolding)
        {
            rockHolding.transform.position = new Vector3(
                transform.position.x + xOffsetRockCarrying,
                transform.position.y + yOffsetRockCarrying,
                rockHolding.transform.position.z
                );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
        {
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
