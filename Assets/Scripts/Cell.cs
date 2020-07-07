using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell {
	 

	private static Sprite redBombSprite = Resources.Load<Sprite>("bombRed") as Sprite;
	private static Sprite revealedCell = Resources.Load<Sprite>("revealedCell") as Sprite;
	private static Sprite flag = Resources.Load<Sprite>("flag") as Sprite;
	private static Sprite one = Resources.Load<Sprite>("one") as Sprite;
	private static Sprite two = Resources.Load<Sprite>("two") as Sprite;
	private static Sprite three = Resources.Load<Sprite>("three") as Sprite;
	private static Sprite four = Resources.Load<Sprite>("four") as Sprite;
	private static Sprite five = Resources.Load<Sprite>("five") as Sprite;
	private static Sprite six = Resources.Load<Sprite>("six") as Sprite;
	private static Sprite seven = Resources.Load<Sprite>("seven") as Sprite;
	private static Sprite eight = Resources.Load<Sprite>("eight") as Sprite;
	
	public static Sprite cellDown = Resources.Load<Sprite>("cellDown") as Sprite;
	public static Sprite cellSprite = Resources.Load<Sprite>("cell") as Sprite;
	public static Sprite bombSprite = Resources.Load<Sprite>("bomb") as Sprite;
	public static Sprite noBomb = Resources.Load<Sprite>("bombMiss") as Sprite;
	
	public const float size = 1f;
	
	private GameObject cellObject;
	public SpriteRenderer spriteRenderer;
	private int x, y;
	
	public bool revealed = false;
	public bool isBomb = false;
	public bool flagSet = false;
	public int bombsNearby = 0;
	
	public Cell(int x, int y)
	{
		
		this.x = x;
		this.y = y;
		cellObject = new GameObject();
		cellObject.AddComponent<SpriteRenderer>();
		cellObject.AddComponent<BoxCollider2D>();
		
		cellObject.GetComponent<BoxCollider2D>().size = new Vector2(size, size);
		
		spriteRenderer = cellObject.GetComponent<SpriteRenderer>();
		changeSprite(cellSprite);
		
		cellObject.transform.position = new Vector3((x * size) + 0.5f, (y * size) + 0.5f, 0f);
		
	}
	
	public int getX()
	{
		return x;
	}
	
	public int getY()
	{
		return y;
	}
	
	public void reveal()
	{
		revealed = true;
		Debug.Log("(" + x + ", " + y + ")" + "  (" + bombsNearby + ")");
		
		if(flagSet)
		{
			return;
		}
		
		if(!isBomb)
		{
			switch(bombsNearby)
			{
				case 0:
					changeSprite(revealedCell);
					break;
				case 1:
					changeSprite(one);
					break;
				case 2:
					changeSprite(two);
					break;
				case 3:
					changeSprite(three);
					break;
				case 4:
					changeSprite(four);
					break;
				case 5:
					changeSprite(five);
					break;
				case 6:
					changeSprite(six);
					break;
				case 7:
					changeSprite(seven);
					break;
				case 8:
					changeSprite(eight);
					break;
				default:
					break;
			}
		} else
		{
			isBomb = false;
			changeSprite(redBombSprite);
			OnRun.ended = true;
		}
		
	}
	
	public void changeSprite(Sprite targetSprite) 
	{
		spriteRenderer.sprite = targetSprite;
	}
	
	public void setFlag()
	{
		if(!flagSet)
		{
			flagSet = true;
			changeSprite(flag);
		}
		else
		{
			flagSet = false;
			changeSprite(cellSprite);
		}
		
		Debug.Log("flag set " + flagSet);
	}
	
}