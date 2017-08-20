using System;

namespace Simple_encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
                codeit(Convert.ToInt16(Console.ReadLine()), Console.ReadLine(), Console.ReadLine());
            else
                codeit(Convert.ToInt16(args[0]), args[1], args[2]);
        }

        static void codeit(int code, string input, string output)
        {
            System.IO.FileStream fs = new System.IO.FileStream(input, System.IO.FileMode.Open);
            System.IO.FileStream ofs = new System.IO.FileStream(output, System.IO.FileMode.Create);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ofs);

            while (br.BaseStream.Position != br.BaseStream.Length)
                bw.BaseStream.WriteByte((byte)(br.BaseStream.ReadByte() ^ code));

            fs.Close(); ofs.Close(); br.Close(); bw.Close();
        }
    }
}
