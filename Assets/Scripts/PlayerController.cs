using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float gravityValue;

    private ParticleSystem poeira;
    private Transform cameraMain;
    private Player playerInput;
    private CharacterController controller;
    private Animation animacao;

    private float playerMaxSpeed = 7.5f;
    private float turnSmoothVelocity;
    private float turnSmoothTime;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool canDoubleJump;

    void Awake()
    {
        playerInput = new Player();
        poeira = GetComponentInChildren<ParticleSystem>();
        controller = GetComponent<CharacterController>();
        animacao = GetComponentInChildren<Animation>();

        var em = poeira.emission;
        em.enabled = false;
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        cameraMain = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        Vector3 direction = new Vector3(movementInput.x, 0f, movementInput.y);
        move.y = 0f;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraMain.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        controller.Move(move * Time.deltaTime * playerSpeed);
        EmissaoPoeira();

        if (move != Vector3.zero && groundedPlayer)
        {
            gameObject.transform.forward = move;
            animacao.Blend("walk", 2f);

        }
        else if (move == Vector3.zero && groundedPlayer)
        {
            animacao.Blend("idle", 0.25f);
        }

        // Changes the height position of the player..
        if (playerInput.PlayerMain.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            canDoubleJump = true;
        }
        else if (playerInput.PlayerMain.Jump.triggered && canDoubleJump)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            canDoubleJump = false;
            animacao.Stop();
            animacao.Blend("jump", 0.25f);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void EmissaoPoeira()
    {
        if (controller.velocity.magnitude > playerMaxSpeed && groundedPlayer)
        {
            var em = poeira.emission;
            em.enabled = true;
        }
        else
        {
            var em = poeira.emission;
            em.enabled = false;
        }
    }
}
