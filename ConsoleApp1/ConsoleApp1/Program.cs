// See https://aka.ms/new-console-template for more information
using System.Numerics;


Console.WriteLine("Hello, World!");
int[] confirm = new int[] { 0, 0, 0, 0, 0, 0,0 };
int[] refute = new int[] { 0, 0, 0, 0, 0, 0,0 };
int[] dice = new int[4];
int currentOutcome;
//*
for (int i = 1; i < 7; i++)
{
    dice[0] = i;
    for (int j = 1; j < 7; j++)
    {
        dice[1] = j;
        for (int k = 1; k < 7; k++)
        {
            dice[2] = k;
            for (int l = 1; l < 7; l++)
            {
                dice[3] = l;
            diceThing currentAssortment = new diceThing(dice);
            
            
            currentOutcome = currentAssortment.outcomeNumber();
            if (currentAssortment.isSuccess())
            {
                confirm[currentOutcome]++;
            }
            else
            {
                refute[currentOutcome]++;
            }
            }
        }
    }
}

Console.WriteLine("Confirmations: ");
for (int i = 1; i < 7; i++)
{
    Console.Write(confirm[i] + ", " );
}
Console.WriteLine("");
Console.WriteLine("Refutals: ");
for (int i = 1; i < 7; i++)
{
    Console.Write(refute[i] + ", " );
}
int glory = confirm[4] + confirm[5] + confirm[6] + refute[4] + refute[5] + refute[6];
int ruin = confirm[1] + confirm[2] + confirm[3] + refute[1] + refute[2] + refute[3];
Console.WriteLine("");
Console.WriteLine("Glory: " + glory);
Console.WriteLine("Ruin " + ruin);//*/
//*/
int[] kockak = { 1, 1, 1 };
diceThing Tester = new diceThing(kockak);
Console.WriteLine(Tester.isSuccess());
Console.WriteLine(Tester.outcomeNumber());
class diceThing {
    int[] dice;
    int diceNumber;
    public diceThing(int[] newDice)
    {
        dice = new int[6];
        diceNumber = newDice.Length;
        for (int i = 0; i < diceNumber; i++)
        {
            dice[i] = newDice[i];
        }
        
    }

    static int[] successNumbers = { 2, 3, 5, 7, 11, 13, 17 };
    int returnSum()
    {
        int sum = 0;
        for (int i = 0; i < diceNumber; i++)
        { 
            sum += dice[i];
        }
        return sum;
    }

    public bool isSuccess() //If the sum of the dice is one of the success numbers, it worked; otherwise it didn't
    {
        int sum = returnSum();
        int i = 0;
        do
        {
            if (sum == successNumbers[i])
            {
                return true;
            }
            i++;
        } while (i < 7);
        return false;
    }

    public int outcomeNumber()
    {

        int outcomeNumber = dice[1];
        if (isSuccess()) //we return the maximum of the individual dice if we succeeded
        {
            for (int i = 0; i < diceNumber; i++)
            {

                if (outcomeNumber < dice[i])
                {
                    outcomeNumber = dice[i];
                }
            }
        }
        else
        {
            for (int i = 1; i < diceNumber; i++) //we return the lowest dice if we failed
            {
                if (outcomeNumber > dice[i])
                {
                    outcomeNumber = dice[i];
                }
            }
        }
        return outcomeNumber;
    }
};

