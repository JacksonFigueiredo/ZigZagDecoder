// C# Program for above approach
using System;

public class GFG
{


    static int GetIndexNextChar(int currentCharInStr, int rowNumber, int fenceHeight)
    {
        if (fenceHeight == 0 || fenceHeight == 1)
            return 1;
        else if (rowNumber == 0 || rowNumber == fenceHeight - 1)
            return (fenceHeight - 1) * 2;
        else if (currentCharInStr % 2 == 0)
            return (fenceHeight - rowNumber - 1) * 2;
        return rowNumber * 2;
    }

    static string Decrypt(string ciphertext, int key)
    {
        int numericKey = key;
   
        if (numericKey == 0)
            numericKey = 1;

        int currentPos = 0;
        char[] plaintext = new char[ciphertext.Length];

        for (int rowNumber = 0; rowNumber < numericKey; rowNumber++)
        {
            for (int i = rowNumber, currentCharInStr = 0; i < ciphertext.Length;
                i += GetIndexNextChar(currentCharInStr, rowNumber, numericKey), currentCharInStr++)
            {
                plaintext[i] = ciphertext[currentPos++];
            }
        }
        return new string(plaintext);
    }


    // Driver Code
    static public void Main()
    {   
        Console.WriteLine(Decrypt("EATIASZOUIOESNSASNIDRASI", 3));
    }
}