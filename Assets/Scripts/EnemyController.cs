using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1f;
    private Rigidbody2D enemyRigidbody;
    private bool isMoving = false; // Por defecto es False
    // A continuacion el tiempo que tiene que pasar de un movimiento a otro
    public float timeBetweenSteps;
    // Variable interna para saber cuanto timpo ha pasado desde el ultimo movimiento
    private float timeBetweenStepsCounter;

    // Tiempo que tarda en hacer el paso de una celda a la siguiente
    public float timeToMakeStep;
    // Tiempo que ha pasado desde que inicio el movimiento
    private float timeToMakeStepCounter;
    // Direccion de movimiento con Vector2
    public Vector2 directionToMakeStep;
    // Para transmitir informacion al Animator, y que tranmita los parametros horizontal y vertical
    private Vector2 lastMovement = Vector2.zero;
    private Animator enemyAnimator;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";


    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos variables privadas de componente incluidas en nuestra clase
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        // Estos contadores serviran para decidir si toca hacer movimiento o estar quieto
        timeBetweenStepsCounter = timeBetweenSteps /* * Random.Range(0.5f, 1.5f) */;
        timeToMakeStepCounter = timeToMakeStep /* * Random.Range(0.5f, 1.5f) */;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            // Tiempo que tarda en hacer un paso
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRigidbody.velocity = directionToMakeStep;

            if(timeToMakeStepCounter < 0)
            {
                isMoving = false;
                // Tiempo que tarda en volver a hacer un paso, (reinicia el contador)
                timeBetweenStepsCounter = timeBetweenSteps;
                // Para el movimiento
                enemyRigidbody.velocity = Vector2.zero;
            }
        }
        else // Si no se esta moviendo
        {
            // Logica estar quieto
            timeBetweenStepsCounter -= Time.deltaTime;
            if(timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                directionToMakeStep = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * enemySpeed; 

                lastMovement = directionToMakeStep;
            }
        }
        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);

        if (lastMovement != Vector2.zero)
        {
            enemyAnimator.SetBool(walkingState, isMoving);
        }

        enemyAnimator.SetFloat(lastHorizontal, lastMovement.x);
        enemyAnimator.SetFloat(lastVertical, lastMovement.y);
    }
}
