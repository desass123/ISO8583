using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] MessBytes;
            string mess = "02002020058020E0820A009800005615051F010200374824914751957018D210" +
                "4201000006830190003032303033393134303030544553543031303532383535000060317545202030302" +
                "057534354533530354F0000012030303031333720434131303931202020094901609F26085BD92B3E399233089F2701809" +
                "F101706011203A400120F0300000050000000000000A92FB4B79F3704C01E70629F360200DE950500800008009A031605139C01009F020600000" +
                "00000005F2A020949820239009F1A0207929F03060000000000009F3303E0F8C89F34034403025F3401" +
                "009F090200849F4104000056159F3501229F1E0830313035323835358407A00000000310109F1101099F5301520008000634360101" +
                "01000029002737353130414E000000000000000000000000003500000000000000";
            // Parse the bytes into an instance of the message class
            MessBytes = String_To_Bytes(mess);

            Iso8583Parser aytac = new Iso8583Parser(MessBytes);
            Console.ReadLine();
        }

        public static byte[] String_To_Bytes(string strInput)
        {
            // i variable used to hold position in string  
            int i = 0;
            // x variable used to hold byte array element position  
            int x = 0;
            // allocate byte array based on half of string length  
            byte[] bytes = new byte[(strInput.Length) / 2];
            // loop through the string - 2 bytes at a time converting it to decimal equivalent
            // and store in byte array  
            while (strInput.Length > i + 1)
            {
                long lngDecimal = Convert.ToInt32(strInput.Substring(i, 2), 16);
                bytes[x] = Convert.ToByte(lngDecimal);
                i = i + 2;
                ++x;
            }
            // return the finished byte array of decimal values  
            return bytes;
        }
    }
}
