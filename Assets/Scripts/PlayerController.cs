using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    //Holds list of NPCs near the player
    public List<GameObject> NPCList;

	//holds player transform
	private Transform myTransform;

	//Holds speed the the player moves per frame (Will be scaled to time.delt time)
	public float moveSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		//Initialises transform
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        CheckPlayerInteraction();
	}

	//handels player Movement
	void MovePlayer()
	{
        Vector3 tempPos = myTransform.position;

		if(Input.GetAxis("Horizontal") != 0)
		{
            tempPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            tempPos.z += Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        }

        myTransform.position = tempPos;
    }

    //Checks distance to NPCs
   void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "NPC")
        {
            NPCList.Add(coll.gameObject);
        }
    }

    //Removes NPCs that are too far to interact with
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "NPC")
        {
            NPCList.Remove(coll.gameObject);
        }
    }

    //Interaction
    void CheckPlayerInteraction()
    {
        if(Input.GetButtonDown("Submit"))
        {
            print("Registered 'A' press");

            print(FindClosestNPC());

            InteractWithNPC();
        }
    }

    public void InteractWithNPC()
    {
        //FindClosestNPC().GetComponent<NPC>().Interact();
        if(FindClosestNPC()!= null)
        {
            Fungus.Flowchart.BroadcastFungusMessage(FindClosestNPC().gameObject.name);
        }
       
    }


    //Checks player distance
    GameObject FindClosestNPC()
    {
        GameObject closestObject = null;
        float closestDistance = 1000000.0f;

        foreach (GameObject i in NPCList)
        {
            if(closestObject == null)
            {
                closestObject = i;
            } 
            else
            {
                if (Vector3.Distance(myTransform.position, i.transform.position) < closestDistance)
                {
                    closestObject = i;
                    closestDistance = Vector3.Distance(myTransform.position, i.transform.position);
                }
            }
            closestDistance = Vector3.Distance(myTransform.position, closestObject.transform.position);
        }
        return closestObject;
    }
}
