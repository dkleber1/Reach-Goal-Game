using System;
using System.Collections.Generic;

class Queue
{
  
  private int size;
  private string [] queue;
  private int gInd;
  private static int pInd;
  private int o1Ind;
  private int o2Ind;

  private List <string> instructions = new List<string>();

  public Queue(int maxSize)
  {
    size = 0;
    queue = new string[maxSize];
  }

  public int GetPInd()
  {
    return pInd;
  }

  public void Enqueue(string instruction)
  {
    instructions.Add(instruction);
  }

 
public string Dequeue()
  {
    string result = null;

    //Only remove an Item if possible
    if (instructions.Count > 0)
    {
      result = instructions[0];
      instructions.RemoveAt(0);
    }
    return result;
  }

  public string Peek()
  {
    string result = null;

    //Only retrieve the Item if possible
    if (instructions.Count > 0)
    {
      result = instructions[0];
    }

    return result;
  }

  //Pre: None
  //Post: Returns the current size of the queue
  //Description: Returns the current number of elements in the queue
  public int Size()
  {
   // return queue.Count;
   return instructions.Count; 
  }

  //Pre: None
  //Post: Returns true if the size of the queue is 0, false otherwise
  //Description: Compare the size of the queue against 0 to determine its empty status
  public bool IsEmpty()
  {
    return instructions.Count == 0; 
  }

  public void DisplayQueue(int maxSize, int rowSpace,int pInd, int gInd, int o1Ind, int o2Ind)
  {
    Console.Clear();
    Console.WriteLine("-------------------");
    int g = (rowSpace - 1);
   
      for (int i = 0; i < queue.Length; i++)
       {
        if (pInd == o1Ind)
        {
          queue[pInd] = "O";
        }
        if (pInd == o2Ind)
        {
          queue[pInd] = "O";
        }
        if (i != pInd && i != gInd && i != o1Ind && i != o2Ind)
         {
         queue[i] = " ";
         }
         else
         {
         }
      if (g == i)
      {
        Console.WriteLine(queue[i] + " | ");
        g += rowSpace;
        Console.WriteLine("-------------------");
      }
      else
      {
        Console.Write(queue[i] + " | ");
      }
      } 
  }

  public void AssignSpaces(int gInd, int pInd)
  {
    queue[gInd] = "G";
    queue[pInd] = "P";
  }

  public int MoveP(string moveNum, int pInd, int rowSpace)
  {
    int g = rowSpace - 1;
    
    if (moveNum == "w")
    {
      if (pInd > 4)
     {
       pInd = pInd - 5;
     }
    }

    if (moveNum == "s")
    {
      if (pInd < 20)
     {
       pInd = pInd + 5;
     }
    }

    if (moveNum == "a")
    {
      if (pInd % 5 != 0)
     {
       pInd = pInd - 1;
     }
    }

    if (moveNum == "d")
    {
      if (pInd != g && pInd != (g + rowSpace) && pInd != (g + (rowSpace * 2)) && pInd != (g + (rowSpace * 3))  && pInd != (g + (rowSpace * 3)) && pInd != (g + (rowSpace * 4)))
      {
       pInd = pInd + 1; 
      }
    }
    
    return pInd;
  }

  

 
  public int Conclusion(int gInd, int pInd, int o1Ind, int o2Ind, int tryNum)
  {
    tryNum = tryNum;
    
    if (pInd == o1Ind || pInd == o2Ind)
    {
      Console.WriteLine("Sorry an obstacle blocked you! You failed.");
    }
    else if (gInd == pInd)
    {
      Console.WriteLine("Congrats you won!");
      tryNum = 3;
    }
    else
    {
      Console.WriteLine("Did not reach goal point, you failed.");
    }

    return tryNum;
  }
}
