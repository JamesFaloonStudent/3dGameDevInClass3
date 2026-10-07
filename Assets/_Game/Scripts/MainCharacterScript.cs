using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MainCharacterScript : MonoBehaviour
{
    private InputAction moveAction;
    private CharacterController characterController;
    private Vector2 move;

    [SerializeField]
    private float speed = 5f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Player/Move");
        characterController = GetComponent<CharacterController>();
        
    }

    // every frame see if the character does a move action and if they do move in the direction based on x and y
    void Update()
    {
         move = moveAction.ReadValue<Vector2>();

        Vector3 direction = new Vector3(move.x, 0f, move.y);
        Vector3 deltaMove = direction * speed * Time.deltaTime;

        characterController.Move(deltaMove);
        
    }
}
