public class Field
{
    public Cell[,] cells = new Cell[3,3];
    
    public Field()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cells[i, j] = new Cell(); 
            }
        }
    }

    public void CurrentField()
    {
        Console.WriteLine(" | 1 | 2 | 3 |");
        Console.WriteLine("-+-----------|");
        for(int k = 0; k < 3; k++)
        {
            Console.Write($"{k+1}|");
            for(int l = 0; l < 3; l++)
            {
                Console.Write($" {cells[k,l].symbol} |");
            }
            Console.WriteLine();
            Console.WriteLine("-|---|---|---|");
        }
    }
}