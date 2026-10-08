using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(Animator)  ) ]
public class MainCharacterScript : MonoBehaviour
{


    private Animator animator;

    private InputAction moveAction;
    private InputAction sadAction;
    private InputAction fightAction;


    private CharacterController characterController;
    private Vector2 move;

    private float sad;
    private float fight;

    [SerializeField]
    private float speed = 5f;


    void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Player/Move");
        sadAction = InputSystem.actions.FindAction("Player/SadIdle");
        fightAction = InputSystem.actions.FindAction("Player/FightIdle");
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }


    void moveCamera()
    {
        
    }

    // every frame see if the character does a move action and if they do move in the direction based on x and y
    void Update()
    {
        move = moveAction.ReadValue<Vector2>(); 
        sad = sadAction.ReadValue<float>();
        fight = fightAction.ReadValue<float>();
        

        // adjust the animator parameters based on the input values
        animator.SetBool("IsSad", sad == 0f ? false : true);
        animator.SetBool("IsFight", fight == 0f ? false : true);
        animator.SetFloat("Speed", move.magnitude > 0.1f ? move.magnitude : 0f);



        Vector3 direction = new Vector3(move.x, 0f, move.y);
        Vector3 deltaMove = direction * speed * Time.deltaTime;

        characterController.Move(deltaMove);
        
    }
}
