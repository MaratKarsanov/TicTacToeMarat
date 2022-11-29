using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMarat
{
    class Program
    {
        static void showField(byte[,] field)
        {
            
            for (var i = 0; i < field.GetLength(0); i++)
            {
                for (var j = 0; j < field.GetLength(1); j++)
                    Console.Write(field[i, j] + " ");
                Console.WriteLine();
            }
        }

        static bool isGameOver(byte[,] field)
        {
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
            showField(field);
            
            while (!isGameOver(field))
            {
                if (isRightInput(out i, out j))
                {
                    field[i, j] = 1;
                    showField(field);
                }
                else
                {
                    Console.WriteLine("sssssss");
                }
            }
        }
    }
}
