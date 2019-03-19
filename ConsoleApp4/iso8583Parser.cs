using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    class Iso8583Parser
    {
        Dictionary<int, string> FieldName =new Dictionary<int, string>();
        Dictionary<int, byte[]> fields =new Dictionary<int, byte[]>();
        byte[] bitmap = new byte[8];
        char[] bitmapBinary=new char[64];
        int[] bitmapInclude =new int[64] ;
        byte[] mti = new byte[2];
        public void FieldNameAdding()
        {
            FieldName.Add(1, "Bitmap");
            FieldName.Add(2, "Primary account number (PAN)");
            FieldName.Add(3, "Processing code");
            FieldName.Add(4, "Amount, transaction");
            FieldName.Add(5, "Amount, settlement");
            FieldName.Add(6, "Amount, cardholder billing");
            FieldName.Add(7, "Transmission date & time");
            FieldName.Add(8, "Amount, cardholder billing fee");
            FieldName.Add(9, "Conversion rate, settlement");
            FieldName.Add(10, "Conversion rate, cardholder billing");
            FieldName.Add(11, "System trace audit number (STAN)");
            FieldName.Add(12, "Time, local transaction (hhmmss)");
            FieldName.Add(13, "Date, local transaction (MMDD)");
            FieldName.Add(14, "Date, expiration");
            FieldName.Add(15, "Date, settlement");
            FieldName.Add(16, "Date, conversion");
            FieldName.Add(17, "Date, capture");
            FieldName.Add(18, "Merchant type/Merchant Category Code");
            FieldName.Add(19, "Acquiring institution country code");
            FieldName.Add(20, "PAN extended, country code");
            FieldName.Add(21, "Forwarding institution. country code");
            FieldName.Add(22, "Point of service entry mode");
            FieldName.Add(23, "Application PAN sequence number");
            FieldName.Add(24, "Function code");
            FieldName.Add(25, "Point of service condition code");
            FieldName.Add(26, "Point of service capture code");
            FieldName.Add(27, "Authorizing identification response length");
            FieldName.Add(28, "Amount, transaction fee");
            FieldName.Add(29, "Amount, settlement fee");
            FieldName.Add(30, "Amount, transaction processing fee");
            FieldName.Add(31, "Amount, settlement processing fee");
            FieldName.Add(32, "Acquiring institution identification code");
            FieldName.Add(33, "Forwarding institution identification code");
            FieldName.Add(34, "Primary account number, extended");
            FieldName.Add(35, "Track 2 data");
            FieldName.Add(36, "Track 3 data");
            FieldName.Add(37, "Retrieval reference number");
            FieldName.Add(38, "Authorization identification response");
            FieldName.Add(39, "Response code");
            FieldName.Add(40, "Service restriction code");
            FieldName.Add(41, "Card acceptor terminal identification");
            FieldName.Add(42, "Card acceptor identification code");
            FieldName.Add(43, "Card acceptor name/location");
            FieldName.Add(44, "Additional response data");
            FieldName.Add(45, "Track 1 data");
            FieldName.Add(46, "Additional data - ISO");
            FieldName.Add(47, "Additional data - national");
            FieldName.Add(48, "Additional data - private");
            FieldName.Add(49, "Currency code, transaction");
            FieldName.Add(50, "Currency code, settlement");
            FieldName.Add(51, "Currency code, cardholder billing");
            FieldName.Add(52, "Personal identification number data");
            FieldName.Add(53, "Security related control information");
            FieldName.Add(54, "Additional amounts");
            FieldName.Add(55, "ICC Data - EMV having multiple tags");
            FieldName.Add(56, "Reserved ISO");
            FieldName.Add(57, "Reserved national");
            FieldName.Add(58, "Reserved national");
            FieldName.Add(59, "Reserved national");
            FieldName.Add(60, "Reserved national");
            FieldName.Add(61, "Reserved private");
            FieldName.Add(62, "Reserved private");
            FieldName.Add(63, "Reserved private");
            FieldName.Add(64, "Message authentication code (MAC)");
            FieldName.Add(65, "Bitmap, extended");
            FieldName.Add(66, "Settlement code");
            FieldName.Add(67, "Extended payment code");
            FieldName.Add(68, "Receiving institution country code");
            FieldName.Add(69, "Settlement institution country code");
            FieldName.Add(70, "Network management information code");
            FieldName.Add(71, "Message number");
            FieldName.Add(72, "Message number, last");
            FieldName.Add(73, "Date, action (YYMMDD)");
            FieldName.Add(74, "Credits, number");
            FieldName.Add(75, "Credits, reversal number");
            FieldName.Add(76, "Debits, number");
            FieldName.Add(77, "Debits, reversal number");
            FieldName.Add(78, "Transfer number");
            FieldName.Add(79, "Transfer, reversal number");
            FieldName.Add(80, "Inquiries number");
            FieldName.Add(81, "Authorizations, number");
            FieldName.Add(82, "Credits, processing fee amount");
            FieldName.Add(83, "Credits, transaction fee amount");
            FieldName.Add(84, "Debits, processing fee amount");
            FieldName.Add(85, "Debits, transaction fee amount");
            FieldName.Add(86, "Credits, amount");
            FieldName.Add(87, "Credits, reversal amount");
            FieldName.Add(88, "Debits, amount");
            FieldName.Add(89, "Debits, reversal amount");
            FieldName.Add(90, "Original data elements");
            FieldName.Add(91, "File update code");
            FieldName.Add(92, "File security code");
            FieldName.Add(93, "Response indicator");
            FieldName.Add(94, "Service indicator");
            FieldName.Add(95, "Replacement amounts");
            FieldName.Add(96, "Message security code");
            FieldName.Add(97, "Amount, net settlement");
            FieldName.Add(98, "Payee");
            FieldName.Add(99, "Settlement institution identification code");
            FieldName.Add(100, "Receiving institution identification code");
            FieldName.Add(101, "File name");
            FieldName.Add(102, "Account identification 1");
            FieldName.Add(103, "Account identification 2");
            FieldName.Add(104, "Transaction description");
            FieldName.Add(105, "Reserved for ISO use");
            FieldName.Add(106, "Reserved for ISO use");
            FieldName.Add(107, "Reserved for ISO use");
            FieldName.Add(108, "Reserved for ISO use");
            FieldName.Add(109, "Reserved for ISO use");
            FieldName.Add(110, "Reserved for ISO use");
            FieldName.Add(111, "Reserved for ISO use");
            FieldName.Add(112, "Reserved for national use");
            FieldName.Add(113, "Reserved for national use");
            FieldName.Add(114, "Reserved for national use");
            FieldName.Add(115, "Reserved for national use");
            FieldName.Add(116, "Reserved for national use");
            FieldName.Add(117, "Reserved for national use");
            FieldName.Add(118, "Reserved for national use");
            FieldName.Add(119, "Reserved for national use");
            FieldName.Add(120, "Reserved for private use");
            FieldName.Add(121, "Reserved for private use");
            FieldName.Add(122, "Reserved for private use");
            FieldName.Add(123, "Reserved for private use");
            FieldName.Add(124, "Reserved for private use");
            FieldName.Add(125, "Reserved for private use");
            FieldName.Add(126, "Reserved for private use");
            FieldName.Add(127, "Reserved for private use");
            FieldName.Add(128, "Message authentication code");

        }
        public Iso8583Parser(byte[] message)
        {
            FieldNameAdding();
            Mtifind(message); //mti initialize
            BitmapParse(message); // taking bitmap from message (bitmap)
            BitmapToBinary(bitmap); //bitmap to binary array (bitmapBinary) and add contents to (bitmapInclude); 
            Fields(message);
            PrintFunc(bitmapInclude);
    
        }
        public void Mtifind(byte[] message)
        {
            Array.Copy(message, 0, mti, 0, 2);
        }

        //finding bitmap
        public void BitmapParse(byte[] message)
        {
            Array.Copy(message, 2, bitmap, 0, 8);
        }

        // bitmap to binary for find which fields are used
        public void BitmapToBinary(byte[] bitmap)
        {
            string[] asdq;
            asdq = bitmap.Select(x => Convert.ToString(x,2).PadLeft(8, '0')).ToArray();
            bitmapBinary = string.Join(string.Empty, asdq).ToCharArray();
            for (int i = 0, y = 0; i < bitmapBinary.Length; i++)
            {
                if (bitmapBinary[i] != '0')
                {
                    bitmapInclude[y++] = i+1;
                }
            }
        }

        public void Fields(byte[] message)
        {
            for(int i=1;i<65;i++)
                fields.Add(i, null);
            int offset = 10;
            if ((bitmap[0] & 128) > 0) fields[1] = ReadFixRaw(message, ref offset, 8);
            if ((bitmap[0] & 64) > 0) fields[2] = ReadVar2Packed(message, ref offset, 19);
            if ((bitmap[0] & 32) > 0) fields[3] = ReadFixPacked(message, ref offset, 6);
            if ((bitmap[0] & 16) > 0) fields[4] = ReadFixPacked(message, ref offset, 12);
            if ((bitmap[0] & 8) > 0) fields[5] = ReadFixPacked(message, ref offset, 12);
            if ((bitmap[0] & 4) > 0) fields[6] = ReadFixPacked(message, ref offset, 12);
            if ((bitmap[0] & 2) > 0) fields[7] = ReadFixPacked(message, ref offset, 10);
            if ((bitmap[0] & 1) > 0) fields[8] = ReadFixPacked(message, ref offset, 8);
            if ((bitmap[1] & 128) > 0) fields[9] = ReadFixPacked(message, ref offset, 8);
            if ((bitmap[1] & 64) > 0) fields[10] = ReadFixPacked(message, ref offset, 8);
            if ((bitmap[1] & 32) > 0) fields[11] = ReadFixPacked(message, ref offset, 6);
            if ((bitmap[1] & 16) > 0) fields[12] = ReadFixPacked(message, ref offset, 6);
            if ((bitmap[1] & 8) > 0) fields[13] = ReadFixPacked(message, ref offset, 4);
            if ((bitmap[1] & 4) > 0) fields[14] = ReadFixPacked(message, ref offset, 4);
            if ((bitmap[1] & 2) > 0) fields[15] = ReadFixPacked(message, ref offset, 4);
            if ((bitmap[1] & 1) > 0) fields[16] = ReadFixPacked(message, ref offset, 4);
            if ((bitmap[2] & 128) > 0) fields[17] = ReadFixPacked(message, ref offset, 4);
            if ((bitmap[2] & 64) > 0) fields[18] = ReadFixPacked(message, ref offset, 4);
            if ((bitmap[2] & 32) > 0) fields[19] = ReadFixPacked(message, ref offset, 3);
            if ((bitmap[2] & 16) > 0) fields[20] = ReadFixPacked(message, ref offset, 3);
            if ((bitmap[2] & 8) > 0) fields[21] = ReadFixPacked(message, ref offset, 3);
            if ((bitmap[2] & 4) > 0) fields[22] = ReadFixPacked(message, ref offset, 3);
            if ((bitmap[2] & 2) > 0) fields[23] = ReadFixPacked(message, ref offset, 3);
            if ((bitmap[2] & 1) > 0) fields[24] = ReadFixPacked(message, ref offset, 3);
            if ((bitmap[3] & 128) > 0) fields[25] = ReadFixPacked(message, ref offset, 2);
            if ((bitmap[3] & 64) > 0) fields[26] = ReadFixPacked(message, ref offset, 2);
            if ((bitmap[3] & 32) > 0) fields[27] = ReadFixPacked(message, ref offset, 1);
            if ((bitmap[3] & 16) > 0) fields[28] = ReadFixPacked(message, ref offset, 8);
            if ((bitmap[3] & 8) > 0) fields[29] = ReadFixPacked(message, ref offset, 8);
            if ((bitmap[3] & 4) > 0) fields[30] = ReadFixPacked(message, ref offset, 8);
            if ((bitmap[3] & 2) > 0) fields[31] = ReadFixPacked(message, ref offset, 8);
            if ((bitmap[3] & 1) > 0) fields[32] = ReadVar2Packed(message, ref offset, 11);
            if ((bitmap[4] & 128) > 0) fields[33] = ReadVar2Packed(message, ref offset, 11);
            if ((bitmap[4] & 64) > 0) fields[34] = (ReadVar2Raw(message, ref offset, 28));
            if ((bitmap[4] & 32) > 0) fields[35] = ReadVar2Raw(message, ref offset, 37);
            if ((bitmap[4] & 16) > 0) fields[36] = ReadVar3Raw(message, ref offset, 104); 
            if ((bitmap[4] & 8) > 0) fields[37] = (ReadFixRaw(message, ref offset, 12));
            if ((bitmap[4] & 4) > 0) fields[38] = (ReadFixRaw(message, ref offset, 6));
            if ((bitmap[4] & 2) > 0) fields[39] = (ReadFixRaw(message, ref offset, 2));
            if ((bitmap[4] & 1) > 0) fields[40] = (ReadFixRaw(message, ref offset, 3));
            if ((bitmap[5] & 128) > 0) fields[41] = (ReadFixRaw(message, ref offset, 16));
            if ((bitmap[5] & 64) > 0) fields[42] = (ReadFixRaw(message, ref offset, 30));
            if ((bitmap[5] & 32) > 0) fields[43] = (ReadFixRaw(message, ref offset, 80));
            if ((bitmap[5] & 16) > 0) fields[44] = ReadVar2Raw(message, ref offset, 25);
            if ((bitmap[5] & 8) > 0) fields[45] = ReadVar2Raw(message, ref offset, 76);
            if ((bitmap[5] & 4) > 0) fields[46] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[5] & 2) > 0) fields[47] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[5] & 1) > 0) fields[48] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[6] & 128) > 0) fields[49] = (ReadFixRaw(message, ref offset, 4));
            if ((bitmap[6] & 64) > 0) fields[50] = (ReadFixRaw(message, ref offset, 3));
            if ((bitmap[6] & 32) > 0) fields[51] = (ReadFixRaw(message, ref offset, 3));
            if ((bitmap[6] & 16) > 0) fields[52] = ReadFixRaw(message, ref offset, 8);
            if ((bitmap[6] & 8) > 0) fields[53] = ReadFixPacked(message, ref offset, 16);
            if ((bitmap[6] & 4) > 0) fields[54] = (ReadVar3Raw(message, ref offset, 120));
            if ((bitmap[6] & 2) > 0) fields[55] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[6] & 1) > 0) fields[56] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[7] & 128) > 0) fields[57] = ReadFixPacked(message, ref offset, 12);
            if ((bitmap[7] & 64) > 0) fields[58] = ReadFixPacked(message, ref offset, 12);
            if ((bitmap[7] & 32) > 0) fields[59] = ReadFixPacked(message, ref offset, 12);
            if ((bitmap[7] & 16) > 0) fields[60] = (ReadVar3Raw(message, ref offset, 1));
            if ((bitmap[7] & 8) > 0) fields[61] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[7] & 4) > 0) fields[62] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[7] & 2) > 0) fields[63] = ReadVar3Raw(message, ref offset, 999);
            if ((bitmap[7] & 1) > 0) fields[64] = ReadFixRaw(message, ref offset, 8);

        }


        #region Internal helpers
        
        byte[] B(byte[] buf, int off, int len)
        {
            byte[] a = new byte[len];
            Array.Copy(buf, off, a, 0, len);
            return a;
        }

    
        byte[] ReadFixRaw(byte[] buf, ref int offset, int len)
        {
            byte[] val = B(buf, offset, len/2);
            offset += len/2;
            return val;
        }

        byte[] ReadVar2Raw(byte[] buf, ref int offset, int unused)
        {
            int len = Convert.ToInt32(buf[offset].ToString("X2"));//(buf[offset] - 0x30) * 10 + buf[offset + 1] - 0x30;
            int oldoffset = offset;
            offset += (len + 3)/2;
            return B(buf, oldoffset+1, (len+2)/2);
        }

        byte[] ReadVar3Raw(byte[] buf, ref int offset, int unused)
        {
            int len = (Convert.ToInt32(buf[offset].ToString("X2")+ buf[offset + 1].ToString("X2")));
            int oldoffset = offset;
            offset += len + 2;
            return B(buf, oldoffset + 2, len);
        }

        byte[] ReadVar2Packed(byte[] buf, ref int offset, int unused)
        {
            int len = (buf[offset] - 0x30) * 10 + (buf[offset + 1] - 0x30);
            int bytes = (len + 1) / 2; // The +1 is so it rounds up
            byte b;
            byte[] a = new Byte[bytes];
            if (len % 2 == 0) // Even number of chars, so there's no padding at the end
            {
                for (int i = 0; i < bytes; i++)
                {
                    b = buf[offset + 2 + i];
                    a[i] = b;
                }
            }
            else
            {
                int i;
                for (i = 0; i < bytes - 1; i++)
                {
                    b = buf[offset + 2 + i];
                    a[i] = b;
                }
                a[i] =(buf[offset + 2 + i]); // Get the last char
            }
            offset += bytes;
            return a;
        } 
        byte[] ReadVar3Packed(byte[] buf, ref int offset, int unused)
        {
            int len = (buf[offset] - 0x30) * 100 + (buf[offset + 1] - 0x30) * 10 + (buf[offset + 2] - 0x30);
            int bytes = (len + 1) / 2; // The +1 is so it rounds up
            byte b;
            byte[] a = new Byte[bytes];
            if (len % 2 == 0) // Even number of chars, so there's no padding at the end
            {
                for (int i = 0; i < bytes; i++)
                {
                    b = buf[offset + 3 + i];
                    a[i] = b;

             
                }
            }
            else
            {
                int i;
                for (i = 0; i < bytes - 1; i++)
                {
                    b = buf[offset + 3 + i];
                    a[i] = b;
                }
                a[i] = buf[offset + 3 + i]; // Get the last char
            }
            offset += bytes + 3;
            return a;
        }
        
        byte[] ReadFixPacked(byte[] buf, ref int offset, int len)
        {
            int bytes = (len + 1) / 2; // The +1 is so it rounds up
            byte b;
            byte[] a = new Byte[bytes];
            if (len % 2 == 0) // Even number of chars, so there's no padding at the end
            {
                for (int i = 0; i < bytes; i++)
                {
                    b = buf[offset + i];
                    a[i] = b;
                }
            }
            else // Odd number
            {
                int i;
                a[0] = (buf[offset]); // Get the first char from the second nibble
                for (i = 1; i < bytes; i++)
                {
                    b = buf[offset + i];
                    a[i] = b;
                }
            }
            offset += bytes;
            return a;
        }
        #endregion
    
    public void PrintFunc(int[] bitmapInclude)
        {

            Console.WriteLine("MTI : "+ BitConverter.ToString(mti));
            Console.WriteLine("Bitmap : " + BitConverter.ToString(bitmap));

            for (int i = 0; i < bitmapInclude.Length; i++)
                if(bitmapInclude[i] != 0)
                    Console.WriteLine((bitmapInclude[i]).ToString() + "." + FieldName[bitmapInclude[i]] + " = " + BitConverter.ToString(fields[bitmapInclude[i]]).Replace("-",""));

    
        }
    }
}