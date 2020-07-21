using System;
using System.IO;

namespace calisma09_FileStream
{
    class Program
    {
        static void Main(string[] args)
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
                return ;
            }
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

            int okunanByte1;
            byte SifreliByte;

            while ((okunanByte1 = fsKaynak.ReadByte()) != -1)
            {
                SifreliByte=(byte)((int)okunanByte1^XOR);
                fsHedef.WriteByte(SifreliByte);
            }
            fsKaynak.Close();
            fsHedef.Close();

            return ;
            
        }
    }
}
