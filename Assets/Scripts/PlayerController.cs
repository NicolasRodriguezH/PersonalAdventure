using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos el animator en Start por ser componente del Player
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // space = velocity * time;
        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f) 
        {
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal) * speed * Time.deltaTime, 0, 0));
        }
        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f) 
        {
            this.transform.Translate(new Vector3(0, Input.GetAxisRaw(vertical) * speed * Time.deltaTime, 0));
        }

        // Se asigna en Update el cambio de estado dependiendo del Input
        // Sincronizamos el movimineto que el jugador ejerce desde el Input Manager con el grafo de animaciones
        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));

        // Desde el animator desactivamos el Has Exit Time en cada transicion
        // para evitar que tenga que completarse para cambiar de estado
    }
}
