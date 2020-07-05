using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRun : MonoBehaviour {
	
	private const int minesweeperWidth = 30;
	private const int minesweeperHeight = 16;
	private const int bombCount = 99;
	private const float size = Cell.size;
	
	public static bool started = false;
	public static bool ended = false;
	
	private Vector3 mousePos;
	private int clickX, clickY;
	
	private Camera mainCam;
	private Transform camPos;
	private static float camOffsetX, camOffsetY = 0;
	
	private float camSize;
	
	private CellGrid minesweeper;
	
    void Start()
    {
		
        minesweeper = new CellGrid(minesweeperWidth, minesweeperHeight, bombCount);
		initCam();
		minesweeper.initBoard();
    }

    void Update()
    {
		
		if(!ended) {
			if(!started)
			{
				if(Input.GetMouseButtonDown(0))
				{
					mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
					clickX = (int)Mathf.Floor(mousePos.x)/(int)size;
					clickY = (int)Mathf.Floor(mousePos.y)/(int)size;
					minesweeper.initBombs(clickX, clickY);
					minesweeper.countBombs();
					minesweeper.revealCell(clickX, clickY);
					//minesweeper.applySprites();
					started = true;
					Debug.Log("game started");
				}
			} 
			else 
			{
				if(Input.GetMouseButtonDown(0))
				{
					mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
					clickX = (int)Mathf.Floor(mousePos.x)/(int)size;
					clickY = (int)Mathf.Floor(mousePos.y)/(int)size;
					minesweeper.revealCell(clickX, clickY);
				}
				
				if(Input.GetMouseButtonDown(1))
				{
					
					Debug.Log("1");
					mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
					clickX = (int)Mathf.Floor(mousePos.x)/(int)size;
					clickY = (int)Mathf.Floor(mousePos.y)/(int)size;
					
					if(!minesweeper.getCell(clickX, clickY).revealed)
					{
						Debug.Log("2");
						minesweeper.setFlagAt(clickX, clickY);
					}	
				}
			}
		} else
		{
			GameOver();
		}
		
		
    }
	
	private void initCam()
	{
		
		mainCam = Camera.main;
		camPos = mainCam.transform;
		
		camSize = (minesweeperHeight/2 + 1.0f);
		
		camOffsetX = (minesweeperWidth * Cell.size)/2;
		camOffsetY = (minesweeperHeight * Cell.size)/2;
		mainCam.transform.position = new Vector3(camPos.position.x + camOffsetX, camPos.position.y + camOffsetY, -1.0f);
		mainCam.orthographicSize = camSize;
		
	}
	
	private void GameOver()
	{
		for(int i = 0; i < minesweeperWidth; i++)
		{
			for(int j = 0; j < minesweeperHeight; j++)
			{
				if(minesweeper.getCell(i,j).isBomb && !minesweeper.getCell(i,j).flagSet)
				{
					minesweeper.getCell(i,j).changeSprite(Cell.bombSprite);
				}
				
				if(!minesweeper.getCell(i,j).isBomb && minesweeper.getCell(i,j).flagSet)
				{
					minesweeper.getCell(i,j).changeSprite(Cell.noBomb);
				}
				
			}
		}
	}
	
}
