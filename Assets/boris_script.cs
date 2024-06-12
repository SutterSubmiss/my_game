using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class boris_script : MonoBehaviour
{
    List<int> moves = new List<int> { 1, 1, 1, 1, 2, 3, 4 };
    List<int> moves2 = new List<int> { 1, 2, 2, 2, 2, 3, 4 };
   

    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector2 direction = Vector2.zero;
    Vector2 direction2 = Vector2.zero;
    ColliderDistance2D distance = new ColliderDistance2D();
    //bool audzia_side = false;
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = transform.GetComponent<Rigidbody2D>();
        Collider2D collider = transform.GetComponent<Collider2D>();
        GameObject audzia = GameObject.Find("audzia1");
        var script1 = audzia.GetComponent<audzia_script>();
        //this.direction2.Distance(script1.direction,this.direction);
        IEnumerator Go1(Vector2 direction1, Rigidbody2D rigidbody1)
        {


            direction = direction1;
            rigidbody1.AddForce(direction * 2f);
            yield return new WaitForSeconds(.1000f);


        }
        ColliderDistance2D old_distance = this.distance;
        int rand = 0;
        if (audzia.transform.position.x > this.transform.position.x)
        {
            rand = this.moves[Random.Range(0, this.moves.Count - 1)];
        }
        else
        {
            rand = this.moves2[Random.Range(0, this.moves.Count - 1)];
        }
        if (rand == 1) {


            StartCoroutine(Go1(Vector2.right, rigidbody));

        }
        else if(rand == 2){

            StartCoroutine(Go1(Vector2.left, rigidbody));

        }
        else if(rand == 3){
            StartCoroutine(Go1(Vector2.up, rigidbody));

        }
         else {

            StartCoroutine(Go1(Vector2.down, rigidbody));

        }


        this.distance = collider.Distance(audzia.GetComponent<Collider2D>());
       if (old_distance.distance > this.distance.distance){
            if (audzia.transform.position.x > this.transform.position.x)
            {
                this.moves.Add(rand);
            }
            else
            {
                this.moves2.Add(rand);
            }


        }
       

    }
}
