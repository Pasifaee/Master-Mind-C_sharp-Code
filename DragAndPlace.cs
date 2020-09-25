using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class DragAndPlace : MonoBehaviour
{
    //This code controls dragging, destroying and placing the balls

    
    //Dragging

    // The plane the object is currently being dragged on
    private Plane dragPlane;

    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    private Vector3 offset;
    private Vector3 startPosition;
    private Camera myMainCamera;

    public GameObject ballToDestroy;

    void Start() {

        myMainCamera = Camera.main; 
    }

    void Update()
    {
        if (ballToDestroy != null)
        {
            Destroy(ballToDestroy, 0.001f);
            ballToDestroy = null;
        }
    }

    void OnMouseDown() {

        startPosition = transform.position;

        dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        offset = transform.position - camRay.GetPoint(planeDist);
    }

    void OnMouseDrag() {

        Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        dragPlane.Raycast(camRay, out planeDist);
        transform.position = camRay.GetPoint(planeDist) + offset;

        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "OverBalls";
    }

    void OnMouseUp() {

        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Balls";
        transform.position = startPosition;
    }
    
    //Placing 
    void OnCollisionExit2D(Collision2D collision) { //This code runs when the ball is dropped while it's on a hemisphere

        if (Input.GetMouseButton(0)==false) {

            if (collision.gameObject.name.StartsWith("Ball"))
            {
                ballToDestroy = collision.gameObject;
            }
            if (collision.gameObject.name.StartsWith("Hemisphere"))
            {

                if (RowButton.justChangedRow == false)
                {
                    //creating new ball when exiting collision with Hemisphere
                    GameObject Ball = Instantiate(Resources.Load("Prefabs/Colour Balls/Ball 1", typeof(GameObject))) as GameObject;
                    Ball.transform.position = collision.gameObject.transform.position;
                
                    Ball.tag = "Row " + RowButton.currentRowNumber.ToString();

                    //changing color of the ball
                    SpriteRenderer spriteRenderer = Ball.GetComponent<SpriteRenderer>();
                    spriteRenderer.color = gameObject.GetComponent<SpriteRenderer>().color;
                    

                    //destroy gameObject after put in Hemisphere if a normal ball (after moving a normal ball into Hemisphere)
                    if (gameObject.tag != "Untagged") Destroy(gameObject, 0.001f);

                    //creating the colour table
                    RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = spriteRenderer.color.ToString();

                    switch (RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48])
                    {
                        case "RGBA(1.000, 1.000, 1.000, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "white";
                            break;

                        case "RGBA(0.349, 0.349, 0.349, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "black";
                            break;

                        case "RGBA(1.000, 0.259, 0.459, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "pink";
                            break;

                        case "RGBA(1.000, 0.146, 0.146, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "red";
                            break;

                        case "RGBA(1.000, 0.484, 0.000, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "orange";
                            break;

                        case "RGBA(1.000, 0.868, 0.000, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "yellow";
                            break;

                        case "RGBA(0.011, 1.000, 0.000, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "green";
                            break;

                        case "RGBA(0.000, 0.836, 1.000, 1.000)":
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "blue";
                            break;

                        default:
                            RowButton.colorTable[RowButton.currentRowNumber, (int)collision.gameObject.name[11]-48] = "undefined colour";
                            break;
                    }

                }
                
            }
            
        }
        
    }

    //Destroying a ball with right-click
    void OnMouseOver()
    {
        if (Input.GetMouseButton(1) && gameObject.tag!="Untagged") DestroyImmediate(gameObject);
    }
    

}
