using UnityEngine;
using UnityEngine.InputSystem;

public class controller : MonoBehaviour
{
    [SerializeField] private AudioClips audioClipObject;
    [SerializeField] private Animator jumpAnimation = null;
    [SerializeField] private float MovementSpeed;
    public ParticleSystem particle;
    private Rigidbody rb;
    public Transform target;
    public Transform LookTarget;
    public Transform particlejump;
    private Vector3 fallDamageStart;
    private Vector3 fallDamageEnd;
    //public PlayerInput playerInput;
    private Vector2 move;
    PlayerInputActions playerActionMap;
    public ShakeCamera shakeCamera;
    public InputActionMap actionMap;
    public InputAction movementAction;
    private bool PlayerIsGrounded = true;
    private bool DoubleJump = true;
    private bool HasJumped = false;
    private bool canDig;
    private bool stompUsed = false;

    private void Awake()
    {
        playerActionMap = new PlayerInputActions();
        playerActionMap.Player.Jump.performed += OnJump;
        playerActionMap.Player.Stomp.performed += OnStomp;
        //movementAction.performed += ctx => { OnMove(ctx); };               
    }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerActionMap.Player.Enable();
        //movementAction.Enable();
    }

    private void OnDisable()
    {
        playerActionMap.Player.Disable();
        // movementAction.Disable();
    }

    private void Update()
    {
        move = playerActionMap.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(move.x, 0, move.y) * MovementSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    // Jump action.
    public void OnJump(InputAction.CallbackContext contex)
    {
        /// Jump
        if (PlayerIsGrounded)
        {
            HasJumped = true;
            DoubleJump = true;
            PlayerIsGrounded = false;
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            jumpAnimation.Play("jump", 0, 0.0f);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(audioClipObject.Jump);
            Debug.Log("Jump");
        }
        // DoubleJumps
        else if (PlayerIsGrounded == false && DoubleJump)
        {
            DoubleJump = false;
            PlayerIsGrounded = false;
            rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            jumpAnimation.Play("jump", 0, 0.0f);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(audioClipObject.JumpDouble);
            Debug.Log("Double Jump");
        }
    }

    // Stomp
    public void OnStomp(InputAction.CallbackContext contex)
    {
        if (PlayerIsGrounded == false)
        {
            stompUsed = true;
            DoubleJump = false;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rb.AddForce(new Vector3(0, -9, 0), ForceMode.Impulse);
            particlejump.position = target.position;
            particle.Play();
            AudioManager.Instance.PlaySound(audioClipObject.Stomp);
            Debug.Log("Stomp");
            transform.LookAt(LookTarget);
        }
    }

    public void OnDig(InputAction.CallbackContext contex)
    {
        if (canDig == true)
        {

        }
    }

    // Ground Check for Jumping.
    private void OnCollisionEnter(Collision collision)
    {
       // fallDamageEnd = transform.position;
       // Vector3 fallDamageResults = fallDamageStart - fallDamageEnd;
       // float dist = Vector3.Distance(fallDamageStart.position, fallDamageEnd.position);
        //Debug.Log("Distance " + dist);
        //if (fallDamageResults)
        if (collision.gameObject.tag == "Ground")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, 9500.0f))
            {
               // AudioManager.Instance.PlaySoundEffects(RayClip);
               // var hitpoint = Instantiate(HitPrefab, hit.point, SpawnLocation.rotation);
                //hitpoint.transform.parent = hit.transform;
            }
            PlayerIsGrounded = true;
            rb.constraints = RigidbodyConstraints.None;
            if (HasJumped == true)
            {
                HasJumped = false;
                AudioManager.Instance.PlaySound(audioClipObject.Land);
                particlejump.position = target.position;
                particle.Play();
            }
            if (stompUsed == true)
            {
                stompUsed = false;
                StartCoroutine(shakeCamera.Shake(.15f, .4f));
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        fallDamageStart = new Vector3(transform.position.x, transform.position.y, transform.position.z);
       // float dist = Vector3.Distance(fallDamageStart.position, fallDamageEnd.position);

    }
}
