Cell[,] cells = new Cell[3,3];
bool MenuStatus = true, GameStatus = true;
int choice;
int PosX , PosY;
bool MoveX = true;
char XorO = '#';

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
            if(cells[k,l].symbol == 'X')
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($" {cells[k,l].symbol} ");
                Console.ResetColor();
                Console.Write("|");
            } else if(cells[k,l].symbol == 'O')
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write($" {cells[k,l].symbol} ");
                Console.ResetColor();
                Console.Write("|");
            } else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write($" {cells[k,l].symbol} ");
                Console.ResetColor();
                Console.Write("|");
            }
        }
        Console.Write(" Y");
        Console.WriteLine();
        Console.WriteLine("-|---|---|---|");
    }
    Console.WriteLine("   X   X   X  ");
}

bool checkWinX()
{
    int XCount = 0;
    for(int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
        {
            if(cells[i,j].symbol == 'X')
            {
                XCount++;
            }
        }
        if(XCount == 3)
        {
            return true;
        } else
        {
            XCount = 0;
        }
    }

    for(int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
        {
            if(cells[j,i].symbol == 'X')
            {
                XCount++;
            }
        }
        if(XCount == 3)
        {
            return true;
        } else
        {
            XCount = 0;
        }
    }

    int k = 0;
    for(int j = 0; j < 3; j++)
    {
        if(cells[j,k].symbol == 'X')
        {
            XCount++;
        }
        k++;
    }
    if(XCount == 3)
    {
        return true;
    } else
    {
        XCount = 0;
    }

    k = 3;
    for(int j = 0; j < 3; j++)
    {
        if(cells[j,k].symbol == 'X')
        {
            XCount++;
        }
        k--;
    }
    if(XCount == 3)
    {
        return true;
    } else
    {
        XCount = 0;
    }

    return false;
}

bool checkWinO()
{
    int OCount = 0;
    for(int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
        {
            if(cells[i,j].symbol == 'O')
            {
                OCount++;
            }
        }
        if(OCount == 3)
        {
            return true;
        } else
        {
            OCount = 0;
        }
    }

    for(int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
        {
            if(cells[j,i].symbol == 'O')
            {
                OCount++;
            }
        }
        if(OCount == 3)
        {
            return true;
        } else
        {
            OCount = 0;
        }
    }

    int k = 0;
    for(int j = 0; j < 3; j++)
    {
        if(cells[j,k].symbol == 'O')
        {
            OCount++;
        }
        k++;
    }
    if(OCount == 3)
    {
        return true;
    } else
    {
        OCount = 0;
    }

    k = 3;
    for(int j = 0; j < 3; j++)
    {
        if(cells[j,k].symbol == 'O')
        {
            OCount++;
        }
        k--;
    }
    if(OCount == 3)
    {
        return true;
    } else
    {
        OCount = 0;
    }

    return false;
}

bool CheckForDraw()
{
    for(int q = 0; q < 3; q++)
    {
        for(int w = 0; w < 3; w++)
        {
            if(cells[q,w].symbol == '#')
            {
                return false;
            }
        }
    }
    return true;
}

void Winner()
{
    if(checkWinO())
    {
        Console.WriteLine("O WIN !");
        Field();
        FillArray();
        GameStatus = false;
    } 
    if(CheckForDraw())
    {
        Console.WriteLine("It`s a DRAW ! ");
        Field();
        FillArray();
        GameStatus = false;
    }
    if(checkWinX())
    {
        Console.WriteLine("X WIN !");
        Field();
        FillArray();
        GameStatus = false;
    } 
}

void Game()
{
    FillArray();
    do
    {
        try{
            Console.Write("Who will be first (X or O) : ");
            XorO = Convert.ToChar(Console.ReadLine());
            XorO = char.ToUpper(XorO);
        } catch(FormatException)
        {
            Console.WriteLine("Choose X or O!");
            Console.ReadKey();
        }
    } while(XorO != 'X' && XorO != 'O');

    if(XorO == 'X')
    {
        MoveX = true;
    } else if(XorO == 'O')
    {
        MoveX = false;
    }


    while(GameStatus)
    {
        Field();

        try
        {
            while(true)
            {
                Console.WriteLine("Choose the cell Cords ");
                Console.Write("Position X: ");
                PosX = int.Parse(Console.ReadLine());
                Console.Write("Position Y: ");
                PosY = int.Parse(Console.ReadLine());

                if(cells[PosY - 1, PosX - 1].symbol != '#')
                {
                    Console.WriteLine("Cell has already exist !");
                } else
                {
                    break;
                }

            }

            if(MoveX)
            {
                cells[PosY - 1, PosX - 1].SetX();
                MoveX = false;
            } else if(!MoveX)
            {
                cells[PosY - 1, PosX - 1].SetO();
                MoveX = true;
            }

            Winner();

        }catch(IndexOutOfRangeException)
        {
            Console.WriteLine("Set position inside the field !");
        }catch(FormatException)
        {
            Console.WriteLine("Please write correct numbers !");
        }
    }
}

while (MenuStatus)
{
    Console.WriteLine($"1 : Play");
    Console.WriteLine($"2 : Exit");
    Console.Write("Choose an option: ");
    choice = Convert.ToInt32(Console.ReadLine());

    switch(choice)
    {
        case 1:
            Game();
            break;
        case 2: MenuStatus = false;
            break;
    }
}