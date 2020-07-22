using System;
using System.IO;
using System.Text;
using System.Security.AccessControl;

namespace calisma09_FileStream
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // string yol = args[0];
            // FileStream fs = new FileStream(yol, FileMode.Open);

            // int okunanByte;
            // while ((okunanByte = fs.ReadByte()) != -1)
            // {
            //     Console.Write((char)okunanByte);
            // }

            // while (true)
            // {
            //     Console.WriteLine("\nDizin gir >> ");
            //     string dizin = Console.ReadLine().Trim();

            //     if (dizin.ToLower() == "q")
            //         break;
            // }
            // Console.Clear();

            if (args.Length != 2)
            {
                Console.WriteLine("Hatalı argüman...");
                return;
            }

            // string kaynak = "/Users/amorfati/Desktop/dotnet-deneme/Private/Private.pages";
            // // string kaynak ="Sifreli1.txt";
            // string hedef = "Sifreli1.txt";
            // // string hedef ="Orijinal.txt";

            // string hedef = "Orijinal.txt";
            // string sifre;
            // sifre="ABCD123";
            // Console.Write("Sifre :");
            // //sifre = Console.ReadLine().Trim();
            // Console.WriteLine(sifre);

            string kaynak = args[0];
            string hedef = args[1];
            string sifre;

            Console.Write("Sifre :");
            sifre = Console.ReadLine().Trim();



            int XOR = 0;
            for (int i = 0; i < sifre.Length; ++i)
            {
                XOR = XOR + (int)(sifre[i] * 10);
            }

            FileStream fsKaynak = new FileStream(kaynak, FileMode.Open);
            FileStream fsHedef = new FileStream(hedef, FileMode.CreateNew, FileAccess.Write);
            FileStream fsHedef1 = new FileStream("TextCopy.txt", FileMode.CreateNew, FileAccess.Write);


            int okunanByte1;
            byte sifreliByte;

            while ((okunanByte1 = fsKaynak.ReadByte()) != -1)
            {
                sifreliByte = (byte)((int)okunanByte1 ^ XOR);
                fsHedef.WriteByte(sifreliByte);
                fsHedef1.WriteByte((byte)(int)okunanByte1);

            }
            
            fsKaynak.Close();
            fsHedef1.Close();
            fsHedef.Close();

            //return;


            try
            {
                // Create a file and write data to it.

                // Create an array of bytes.
                byte[] messageByte = Encoding.ASCII.GetBytes("Here is some data.");

                // Create a file using the FileStream class.
                FileStream fWrite = new FileStream("test.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.None, 8, FileOptions.None);

                // Write the number of bytes to the file.
                fWrite.WriteByte((byte)messageByte.Length);

                // Write the bytes to the file.
                fWrite.Write(messageByte, 0, messageByte.Length);

                // Close the stream.
                fWrite.Close();

                // Open a file and read the number of bytes.

                FileStream fRead = new FileStream("test.txt", FileMode.Open);

                // The first byte is the string length.
                int length = (int)fRead.ReadByte();

                // Create a new byte array for the data.
                byte[] readBytes = new byte[length];

                // Read the data from the file.
                fRead.Read(readBytes, 0, readBytes.Length);

                // Close the stream.
                fRead.Close();

                // Display the data.
                Console.WriteLine(Encoding.ASCII.GetString(readBytes));

                Console.WriteLine("Done writing and reading data.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            Console.ReadLine();




        }
    }
}
