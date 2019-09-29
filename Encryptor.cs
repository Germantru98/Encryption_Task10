using System.Text;

namespace Encryption_Task10
{
    public class Encryptor
    {
        private string newMessage(char[,] matrix)
        {
            var result = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j];
                }
            }
            return result;
        }

        private void swapColumns(char[,] message, int firstColumn, int secondColumn)
        {
            char tmp;
            for (int i = 0; i < message.GetLength(0); i++)
            {
                tmp = message[i, firstColumn];
                message[i, firstColumn] = message[i, secondColumn];
                message[i, secondColumn] = tmp;
            }
        }

        public string Encrypt(char[,] matrix, string key)
        {
            char[,] tmpMatrix = matrix;
            StringBuilder tmpKey = new StringBuilder(key);
            char temp;
            for (int i = 0; i < tmpKey.Length - 1; i++)
            {
                bool f = false;
                for (int j = 0; j < tmpKey.Length - i - 1; j++)
                {
                    if (tmpKey[j + 1] > tmpKey[j])
                    {
                        f = true;
                        temp = tmpKey[j + 1];
                        tmpKey[j + 1] = tmpKey[j];
                        tmpKey[j] = temp;
                        swapColumns(tmpMatrix, j + 1, j);
                    }
                }
                if (!f) break;
            }

            return newMessage(tmpMatrix);
        }

        public string Decrypt(char[,] matrix, string key)
        {
            return Encrypt(matrix, key);
        }
    }
}