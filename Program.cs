using System;

namespace Encryption_Task10
{
    internal class Program
    {
        private static void showMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Main(string[] args)
        {
            Encryptor encryptor = new Encryptor();
            DataPharser dp = new DataPharser();
            var test = dp.getMessage();
            showMatrix(test);
            Console.WriteLine(encryptor.Encrypt(test, dp.getKey()));
            showMatrix(test);
            Console.WriteLine(encryptor.Decrypt(test, dp.getKey()));
        }
    }
}