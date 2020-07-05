using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGrid
{
	
	private int bombCount;
	
	private int width, height;
	private Cell[,] gridArray;
	
	private System.Random rand = new System.Random();
	
	public CellGrid(int width, int height, int bombCount) 
	{
		this.width = width;
		this.height = height;
		this.bombCount = bombCount;
		
	}
	
	public int getWidth()
	{
		return width;
	}
	
	public int getHeight()
	{
		return height;
	}
	
	public Cell getCell(int x, int y)
	{
		return gridArray[x,y];
	}
	
	public void initBoard()
	{
		gridArray = new Cell[width, height];
		
		for(int i = 0; i < width; i++) 
		{
			for(int j = 0; j < height; j++) 
			{
				gridArray[i,j] = new Cell(i, j);
			}
		}
	
	}
	
	public void initBombs(int startX, int startY) 
	{	
		int randomX, randomY;
		
		for(int i = 0; i < bombCount; i++) 
		{	
	
			//massive condition not to spawn bombs next to the starting tile
			do
			{
				randomX = rand.Next(0, width);
				randomY = rand.Next(0, height);
			}
			while
			(gridArray[randomX,randomY].isBomb || 
				(randomX == startX && randomY == startY) ||
				(randomX == startX-1 && randomY == startY) ||
				(randomX == startX+1 && randomY == startY) ||
				(randomX == startX && randomY == startY-1) ||
				(randomX == startX && randomY == startY+1) ||
				(randomX == startX-1 && randomY == startY-1) ||
				(randomX == startX-1 && randomY == startY+1) ||
				(randomX == startX+1 && randomY == startY-1) ||
				(randomX == startX+1 && randomY == startY+1)
			);
			
			gridArray[randomX,randomY].isBomb = true;
		}
		
	}
	
	public void setFlagAt(int x, int y)
	{
		gridArray[x,y].setFlag();
	}
	
	public void revealCell(int x, int y)
	{
		
		if(!gridArray[x,y].revealed && !gridArray[x,y].flagSet)
		{
			gridArray[x,y].reveal();
			
			if(gridArray[x,y].bombsNearby == 0)
			{
				if(x - 1 >= 0)
				{
					revealCell(x-1,y);
				}
				if(y - 1 >= 0)
				{
					revealCell(x,y-1);
				}
				if(x + 1 < width)
				{
					revealCell(x+1,y);
				}
				if(y + 1 < height)
				{
					revealCell(x,y+1);
				}
				if((x - 1 >= 0) && (y - 1 >= 0))
				{
					revealCell(x-1,y-1);
				}
				if((x - 1 >= 0) && (y + 1 < height))
				{
					revealCell(x-1,y+1);
				}
				if((x + 1 < width) && (y + 1 < height))
				{
					revealCell(x+1,y+1);
				}
				if((x + 1 < width) && (y - 1 >= 0))
				{
					revealCell(x+1,y-1);
				}	
			}
		}
		
	}
	
	public void countBombs()
	{
		for(int x = 0; x < width; x++) 
		{
			for(int y = 0; y < height; y++) 
			{
				if(x - 1 >= 0)
				{
					if(gridArray[x-1,y].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
				if(y - 1 >= 0)
				{
					if(gridArray[x,y-1].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
				if(x + 1 < width)
				{
					if(gridArray[x+1,y].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
				if(y + 1 < height)
				{
					if(gridArray[x,y+1].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
				if((x - 1 >= 0) && (y - 1 >= 0))
				{
					if(gridArray[x-1,y-1].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
				if((x - 1 >= 0) && (y + 1 < height))
				{
					if(gridArray[x-1,y+1].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
				if((x + 1 < width) && (y + 1 < height))
				{
					if(gridArray[x+1,y+1].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
				if((x + 1 < width) && (y - 1 >= 0))
				{
					if(gridArray[x+1,y-1].isBomb)
					{
						gridArray[x,y].bombsNearby++;
					}
				}
			}
		}	
	}
	
	
}
