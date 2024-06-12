using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class audzia_script : MonoBehaviour
{ 
    //public bool no_jump = false;
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void Start()
    {
       
    }
   
   public Vector2 direction = Vector2.zero;
    IEnumerator Go1(Vector2 direction1,Rigidbody2D rigidbody1)
    {
       
        
            direction = direction1;
            rigidbody1.AddForce(direction * 2.5f);
            
            yield return new WaitForSeconds(.1000f);
        

    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = transform.GetComponent<Rigidbody2D>();
        Collider2D collider = transform.GetComponent<Collider2D>();
        if (Input.GetKey(KeyCode.UpArrow)  /* && this.no_jump == false*/)
        {
            StartCoroutine(Go1(Vector2.up, rigidbody));
            //this.no_jump = true;




        }
        if (Input.GetKey(KeyCode.DownArrow))
            StartCoroutine(Go1(Vector2.down,rigidbody));
        {
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(Go1(Vector2.left,rigidbody));
           


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            StartCoroutine(Go1(Vector2.right,rigidbody));
        }

       // Debug.Log(this.no_jump.ToString());
        
       

    } 
    void OnCollisionEnter2D(Collision2D collision)
        {
       
        if (collision.gameObject.name == "boris1")
        {
            

            SceneManager.LoadScene("scene2");
        }
       /* else if (collision.gameObject.name == "cegly_dol")
        {


            this.no_jump = false;
        }*/

    }
}
