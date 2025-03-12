Cell[,] cells = new Cell[3,3];
bool MenuStatus = true, GameStatus = true;
int choice;

void FillArray()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            cells[i, j] = new Cell(); 
        }
    }
}

void Field()
{
    Console.WriteLine("\\| 1 | 2 | 3 |");
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

void Game()
{
    while(GameStatus)
    {
        
    }
}

while (MenuStatus)
{
    Console.WriteLine($"1 : Play");
    Console.WriteLine($"2 : Exit");
    choice = Convert.ToInt32(Console.ReadLine());

    switch(choice)
    {
        case 1:
            FillArray(); 
            Field();

            break;
        case 2: status = false;
            break;
    }
}