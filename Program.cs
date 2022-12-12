using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMarat
{
    class Program
    {
        const byte SIZE = 3;//размер поля
        static void showField(byte[,] field)
        {
            
            for (var i = 0; i < field.GetLength(0); i++)
            {
                for (var j = 0; j < field.GetLength(1); j++)
                    Console.Write(field[i, j] + " ");
                Console.WriteLine();
            }
        }

        static bool isGameOver(byte[,] field, byte player)
        {
            //проверка по вертикали и горизонтали
            for (var j = 0; j < SIZE; j++)
            {
                var kStr = 0;
                var kStlb = 0;
                for (var i = 0; i < SIZE; i++)
                {
                    if (field[j, i] == player)
                        kStr++;
                    if (field[i, j] == player)
                        kStlb++;
                }
                if (kStr == SIZE || kStlb == SIZE)
                {
                    Console.WriteLine(player);
                    return true;
                }
            }
            var kMain = 0;
            var kPob = 0;
            //проверка по диагонали
            for (var i = 0; i < SIZE; i++)
            {
                if (field[i, i] == player)
                    kMain++;
                if (field[i, SIZE - i - 1] == player)
                    kPob++;
            }
            if (kMain == SIZE || kPob == SIZE)
                return true;
            return false;
        }

        static bool isRightInput(out byte i, out byte j)
        {
            Console.WriteLine("Введите координаты х и у Вашего хода в одной строке через пробел:");
            var temp = Console.ReadLine().Split();
            var x = Convert.ToByte(temp[0]);
            var y = Convert.ToByte(temp[1]);
            if (x > 0 && x < 4 && y > 0 && y < 4)
            {
                
                i = (byte)(3 - y);
                j = (byte)(x - 1);
                return true;
            }
            i = Byte.MaxValue;
            j = Byte.MaxValue;
            return false;
        }

        static void Main(string[] args)
        {
            var field = new byte[3, 3];
            byte i, j;
            byte player = 2; 
            showField(field);
            
            while (!isGameOver(field, player))
            {
                if (isRightInput(out i, out j))
                {
                    if (field[i, j] == 0)
                    {
                        player = (byte)(player % 2 + 1);//переход хода
                        field[i, j] = player;
                        showField(field);
                        //player = (byte)(player % 2 + 1);//переход хода
                    }
                    else
                    {
                        Console.WriteLine("Поле занято!");
                        showField(field);
                    }
                }
                else
                {
                    Console.WriteLine("sssssss");
                }
            }
        }
    }
}
