using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour {

    [SerializeField]
    private CharacterController playerController;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private float jumpHeight = 3f;

    private bool isGrounded;
    private Vector3 playerVelocity = Vector3.zero;

    private void Update() {
        isGrounded = playerController.isGrounded;
    }

    public void ProcessMove(Vector2 input) {
        Vector3 moveVector = Vector3.zero;

        moveVector.x = input.x;
        moveVector.z = input.y;

        playerController.Move(speed * Time.deltaTime * transform.TransformDirection(moveVector));
        playerVelocity.y += (gravity * Time.deltaTime);

        if(isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -2f;
        }

        playerController.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump() {
        if(isGrounded) {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
}
