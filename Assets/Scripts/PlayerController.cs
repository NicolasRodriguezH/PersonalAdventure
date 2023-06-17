using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private bool walking = false;
    private Vector2 lastMovement = Vector2.zero;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";
    private Animator animator;
    private Rigidbody2D playerRigidbody;

    public static bool playerCreated; // Por defecto su valor sera false!

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos el animator en Start por ser componente del Player
        animator = GetComponent<Animator>();
        // Inicializamos el Rigidbody2D al ser componente de Player
        playerRigidbody = GetComponent<Rigidbody2D>();
        // 
        if(!playerCreated) 
        {
            playerCreated = true;
            // Se mantiene el objeto de una escena a otra
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;

        // space = velocity * time;
        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f) 
        {
            /* this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0)); */
            playerRigidbody.velocity = new Vector2(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, playerRigidbody.velocity.y);
            walking = true;
            // Se actualiza el Vector2 dependiendo de la entrada del Input
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), 0);
        }
        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f) 
        {
            /*  this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0)); */
            playerRigidbody.velocity = new Vector2( playerRigidbody.velocity.x, Input.GetAxisRaw(vertical) * speed * Time.deltaTime);
            walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(vertical));
        }

        if(!walking) 
        {
            playerRigidbody.velocity = Vector2.zero;
        }

        // Se asigna en Update el cambio de estado dependiendo del Input
        // Sincronizamos el movimineto que el jugador ejerce desde el Input Manager con el grafo de animaciones
        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));

        // Desde el animator desactivamos el Has Exit Time en cada transicion
        // para evitar que tenga que completarse para cambiar de estado

        // Tambien es recomendable desactivar el Fixed Duration en settings del nuevo estado
        // para que la transcicion sea lo mas rapida posible

        // En el Animator lo mas optimo es usar Blend Trees (Arboles de mezla)
        // ------
        // Luego se notifican los cambios al Animator para estar sincronizado con los movimientos del controlador
        animator.SetBool(walkingState, walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
