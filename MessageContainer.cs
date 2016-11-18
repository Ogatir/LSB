using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSB
{
    class MessageContainer
    {
        private int maskEnode = 0x80;
        private byte value;
        private string word;
        public string Word { get { return word; } }
        private BitArray bits { get; set; }
        private int bitsArrayCount;

        public MessageContainer(string word)
        {
            this.word = word;
            bits = new BitArray(word.Length * 8+16);
        }

        public void SetValue(int j)
        {
            maskEnode = 0x80;
            char letter = Convert.ToChar(word.Substring(j, 1));
            this.value = Convert.ToByte(letter);
            Console.WriteLine("letter[" + j + "] = " + letter + " byte number is "
                  + value + " binary is " + Convert.ToString(value, 2));
        }

        public void WriteBits()
        {
            foreach (bool b in bits)
                Console.Write(b ? 1 : 0);
            Console.WriteLine("\n");
        }

        public void FillMessageContainer()
        {
            word += "\\0";
            for (int j = 0; j < word.Length; j++)
            {
                SetValue(j);
                Write_Letter_In_Bit_Array();
            }
        }

        

        

        void Write_Letter_In_Bit_Array()
        {
            for (int i = 0; i < 8; i++)
            {
                int result = value & maskEnode;

                if (result == 0)
                {
                    bits[bitsArrayCount] = false;
                }
                else bits[bitsArrayCount] = true;
                bitsArrayCount++;
                maskEnode >>= 1;
            }
        }

        public bool getBit(int i)
        {
            return bits[i];
        }

        public int GetBitArrayLength()
        {
            return bits.Length;
        }
    }
}
