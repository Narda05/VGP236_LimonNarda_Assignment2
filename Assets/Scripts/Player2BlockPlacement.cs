using UnityEngine;

public class Player2BlockPlacement : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab; 

   
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
           
            PlaceBox();
        }
    }

    void PlaceBox()
    {
       
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        Vector2 finalPosition = new Vector2(mousePos.x, mousePos.y);

        
        Instantiate(boxPrefab, finalPosition, Quaternion.identity);
    }
}