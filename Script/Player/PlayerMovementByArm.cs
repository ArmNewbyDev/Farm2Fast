using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyPlatformer;

public class PlayerMovementByArm : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    [SerializeField] BoxCollider2D playerNorth;
    [SerializeField] BoxCollider2D playerSouth;
    [SerializeField] BoxCollider2D playerWest;
    [SerializeField] BoxCollider2D playerEast;

    [SerializeField] Sprite MarkNorth;
    [SerializeField] Sprite MarkSouth;
    [SerializeField] Sprite MarkWest;
    [SerializeField] Sprite MarkEast;

    [SerializeField] SpriteRenderer sr; 
    public LayerMask whatStopMovement;

    [SerializeField] string horizontalAxis;
    [SerializeField] string verticalAxis;

    public Animator anim;
    
    

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw(horizontalAxis)) == 1)
            {
                if (Input.GetAxisRaw(horizontalAxis) == -1)
                {
                    
                    playerNorth.enabled = false;
                    playerSouth.enabled = false;
                    playerWest.enabled = true;
                    playerEast.enabled = false;

                    sr.sprite = MarkWest;
                }
                else if (Input.GetAxisRaw(horizontalAxis) == 1)
                {
                    playerNorth.enabled = false;
                    playerSouth.enabled = false;
                    playerWest.enabled = false;
                    playerEast.enabled = true;

                    sr.sprite = MarkEast;
                }
                //anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));


                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw(horizontalAxis), 0, 0), .2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw(horizontalAxis), 0,0);

                }
            }

            else if (Mathf.Abs(Input.GetAxisRaw(verticalAxis)) == 1)
            {
                
                if (Input.GetAxisRaw(verticalAxis) == -1)
                {
                    playerNorth.enabled = false;
                    playerSouth.enabled = true;
                    playerWest.enabled = false;
                    playerEast.enabled = false;

                    sr.sprite = MarkSouth;
                }
                else if (Input.GetAxisRaw(verticalAxis) == 1)
                {
                    playerNorth.enabled = true;
                    playerSouth.enabled = false;
                    playerWest.enabled = false;
                    playerEast.enabled = false;

                    sr.sprite = MarkNorth;
                }

                //anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw(verticalAxis), 0), .2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(0, Input.GetAxisRaw(verticalAxis), 0);

                }

            }

            SoundManager.instance.Play(SoundManager.SoundName.Walk);
            anim.SetBool("moving", false);

        }
        else
        {
            anim.SetBool("moving", true);
            

        }


    }//

    
    
}//
