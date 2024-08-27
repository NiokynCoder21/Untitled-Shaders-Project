using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; //reference player rigidbody
    public GameObject camHolder; //reference player game object 

    private Vector2 move, look; //for movement and looking 

    public bool grounded; //to check if the player grounded or not
    public float speed; //player movement speed

    public float sensitivity; //player mouse sensitity speed
    private float lookRotation; //keep track of current look rotation
    public float maxForce; //the max force that can be applied on the player

    public GameObject TerrainScannerPrefab;
    public float duration;
    public float size;
    public GameObject fire;

    public bool torch = false;
    public float fireTime = 10f;

    public void OnMove(InputAction.CallbackContext context)  
    {
       move = context.ReadValue<Vector2>(); //this detects input along the vector and allows movement 
    }

    public void OnLook(InputAction.CallbackContext context) //Uses the new input system to call function when button pressed
    {
        look = context.ReadValue<Vector2>(); //this detects input along the vector and allows look which controls where the player sees 
    }

    public void onScan(InputAction.CallbackContext context)
    {
        ScanTerrain();
    }

    public void onLight(InputAction.CallbackContext context)
    {
        LightTorch(fireTime);
    }
    //Potato Code. (2022, May 15). How to Make a Rigidbody Player Controller with Unity's Input System[Video]. Youtube. https://www.youtube.com/watch?v=1LtePgzeqjQ

    private void FixedUpdate()
    {
        if (grounded) //if the player is on the ground
        {
          Move();  //call the move function
        }        
    }

    private void Update()
    {
       
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor when the game begins
        Cursor.visible = false; //ensure the cursor is not visible 
    }

    private void Move()
    {
        Vector3 currentVelocity = rb.velocity; //find the players velocity
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y); //take our movement and turn it to vector to move our character
        targetVelocity *= speed; //this controls how fast the character moves

        targetVelocity = transform.TransformDirection(targetVelocity); //ensure the velocity is being applied in the correct direction

        Vector3 velocityChange = (targetVelocity - currentVelocity); //calculate the force that will applied on the player
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z); //apply the forces on the velocitychange for x and z

        Vector3.ClampMagnitude(velocityChange, maxForce); //limit the force that can be added on the player  
        rb.AddForce(velocityChange, ForceMode.VelocityChange); //applies force to the rigidbody ignoring its mass
    }

    void NormalLook()
    {
        transform.Rotate(Vector3.up * look.x * sensitivity); //turns the camera around at the sensitivity set 

        lookRotation += (-look.y * sensitivity); //ensure that the the player up and down look is at the sensitivity set
        lookRotation = Mathf.Clamp(lookRotation, -90, 90); //clamps the rotation to -90 and 90 so it restricted between these two values
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z); //this sets the rotatation of camera holder
                                                                                                                                           //so that it stays unchanged on the y and z and
                                                                                                                                           //only rotates on the x
    }

    void ScanTerrain()
    {
        GameObject terrainScanner = Instantiate(TerrainScannerPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
        ParticleSystem terrainScannerPS = terrainScanner.transform.GetChild(0).GetComponent<ParticleSystem>();

        if(terrainScannerPS != null)
        {
            var main = terrainScannerPS.main;
            main.startLifetime = duration;
            main.startSize = size;
        }

        else
        {
            print("No particle system");
        }

        Destroy(terrainScanner, duration + 1);
    }

    void LightTorch(float duration)
    {
        if(torch == true)
        {
            StartCoroutine(LightTorchWithTimer(duration));
        }
    }

    IEnumerator LightTorchWithTimer(float duration)
    {
        // Activate the fire
        fire.gameObject.SetActive(true);

        // Wait for the duration (countdown)
        yield return new WaitForSeconds(duration);

        // Deactivate the fire
        fire.gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        NormalLook(); //call the normal look function
    }

    public void SetGrounded(bool state) //this is used to allow me to check for grounded in a collsion script
    {
        grounded = state;
    }

    public void SetTorch(bool state) //this is used to allow me to check for grounded in a collsion script
    {
        torch = state;
    }
}
