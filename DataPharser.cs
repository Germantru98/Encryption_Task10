using System.IO;
using System.Text;

namespace Encryption_Task10
{
    internal class DataPharser
    {
        public string getKey()
        {
            using (StreamReader stream = new StreamReader("Key.txt", Encoding.Default))
            {
                return stream.ReadToEnd().ToUpper();
            }
        }

        public char[,] getMessage()
        {
            using (StreamReader stream = new StreamReader("Message.txt", Encoding.Default))
            {
                var message = stream.ReadToEnd().ToUpper();
                var key = getKey();
                int columnCount = key.Length;
                int lineCount = 0;
                while (lineCount * columnCount < message.Length)
                {
                    lineCount++;
                }
                char[,] resMatrix = new char[lineCount, columnCount];
                int flag = 0;
                for (int i = 0; i < lineCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        resMatrix[i, j] = message[flag];
                        if (flag < message.Length - 1)
                        {
                            flag++;
                        }
                        if (flag == message.Length - 1)
                        {
                            break;
                        }
                    }
                }
                return resMatrix;
            }
        }
    }
}