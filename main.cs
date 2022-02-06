using System;
using System.Collections.Generic;

class MainClass 
{
  static string [] instructionLine;
  static int choice = 1;
  static int maxSpaces = 25; 

  static Queue queue = new Queue(maxSpaces);

  static int pNum;
  static int rowSpace = 5;
  public static void Main (string[] args) 
  {
   while (choice == 1)
    {
    Console.Clear();

    int gNum;
    int o1;
    int o2;

    int tryNum = 3;


    Random random = new Random();
    gNum = random.Next(0, maxSpaces);
    pNum = random.Next(0, maxSpaces);
    o1 = random.Next(0, maxSpaces);
    o2 = random.Next(0, maxSpaces);


    
      while(gNum == pNum)
      {
        pNum = random.Next(0, maxSpaces);
        gNum = random.Next(0, maxSpaces);       
      }
    

    
      while(o1 == pNum)
      {
        pNum = random.Next(0, maxSpaces);
        o1 = random.Next(0, maxSpaces);        
      }
    

   
      while(o2 == pNum)
      {
        pNum = random.Next(0, maxSpaces);
        o2 = random.Next(0, maxSpaces);        
      }
    

    
      while(o1 == gNum)
      {
        gNum = random.Next(0, maxSpaces);
        o1 = random.Next(0, maxSpaces);
      }
    
   
      while(o2 == gNum)
      {
        gNum = random.Next(0, maxSpaces);
        o2 = random.Next(0, maxSpaces);        
      }

    
      while(o2 == o1)
      {
        o1 = random.Next(0, maxSpaces);
        o2 = random.Next(0, maxSpaces);        
      }
 
    queue.AssignSpaces(gNum, pNum);

    for (int i = 0; i < tryNum; i++)
    {
      Console.Clear();
      queue.DisplayQueue(maxSpaces, rowSpace, pNum, gNum, o1, o2);
       if (i > 0)
       {
         i = queue.Conclusion(gNum, pNum, o1, o2, i);
       }
      AskUser();
    

       while(!queue.IsEmpty())
       {
         pNum = queue.MoveP(queue.Dequeue(), pNum, rowSpace); 
         queue.AssignSpaces(gNum, pNum);
         queue.DisplayQueue(maxSpaces, rowSpace, pNum, gNum, o1, o2);
        i = queue.Conclusion(gNum, pNum, o1, o2, i);
       }
    }
    AskUserPlay();
   }
  }

  static public void AskUser()
  {
    Console.WriteLine("Enter instructions to reach goal. Press 'w' for up, press 's' for down, press 'a' for left, press 'd' for right. Seperate each instruction with a comma (ex: w,a,w,w): ");
    instructionLine = Console.ReadLine().Split(',');
     for (int i = 0; i < instructionLine.Length; i++)
    {
      queue.Enqueue(instructionLine[i]);
    }
  }

  static public void AskUserPlay()
  {
    Console.WriteLine("Thank you for playing. Do you want to play again? Press 1 if you want to play again");
    choice = Convert.ToInt32(Console.ReadLine());
  }
  
}
