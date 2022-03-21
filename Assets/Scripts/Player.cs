using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;
    private Animator animator;
    private bool isHopping;
    private int score;
    private int leftSteps = 0;
    private int rightSteps = 0;
    public Transform target;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(verticalInput, 0, horizontalInput);
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isHopping)
        {
            score++;
            animator.SetTrigger("hop");
            isHopping = true;
            if (moveDirection.sqrMagnitude > 0.0024f)
            {
                var desiredRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * 60);
            }
            moveCharacter(new Vector3(1, 0, 0));

        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && !isHopping)
        {
            if (leftSteps <= 11)
            {
                leftSteps++;
                rightSteps--;
                if (moveDirection.sqrMagnitude > 0.001f)
                {
                    var desiredRotation = Quaternion.LookRotation(moveDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * 60);
                }
                moveCharacter(new Vector3(0, 0, 1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !isHopping)
        {
            if (rightSteps <= 11)
            {
                leftSteps--;
                rightSteps++;
                if (moveDirection.sqrMagnitude > 0.002f)
                {
                    var desiredRotation = Quaternion.LookRotation(moveDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * 60);
                }
                moveCharacter(new Vector3(0, 0, -1));
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isHopping && score != 0)
        {
            score--;
            if (moveDirection.sqrMagnitude > 0.00f)
            {
                var desiredRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * 60);
            }
            moveCharacter(new Vector3(-1, 0, 0));
        }
        if (score != 0)
        {
            scoreText.text = "" + score;
        }
        else
        {
            scoreText.text = "";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<MovingObject>() != null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }

    private void moveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.SpawnTerrain(false, transform.position);
    }

    public void FinishHop()
    {
        isHopping = false;
    }
}
