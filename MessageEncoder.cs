using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSB
{
    class MessageEncoder
    {
        private Bitmap img;
        private string imageFile;

        public MessageEncoder(Bitmap img, string imageFile)
        {
            this.img = img;
            this.imageFile = imageFile;
        }

        public void EncodeMessage(MessageContainer mc, int textLength) {

            int red, green, blue;
            int numberOfBits = mc.GetBitArrayLength();
            int numberOfPixels = textLength *3+6;
            int pixelCount = 0, bitCount = 0; 

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (pixelCount < numberOfPixels)
                    {
                        Color pixel = img.GetPixel(i, j);
                        Console.WriteLine(" pixel[" + i + "][" + j + "]: R=" + pixel.R + " G=" + pixel.G + " B=" + pixel.B);
      
                        red=setPixel(mc.getBit(bitCount),pixel.R);
                        bitCount++;

                        green = setPixel(mc.getBit(bitCount), pixel.G);
                        bitCount++;

                        if (((bitCount) % 8 != 0) || (pixelCount == 0))
                        {
                            blue = setPixel(mc.getBit(bitCount), pixel.B);
                            bitCount++;
                            Console.WriteLine("red=" + red + " green=" + green + " blue=" + blue);
                        }
                        else { blue = pixel.B; Console.WriteLine(" red=" + red + "green=" + green); }
                        
                        img.SetPixel(i, j, Color.FromArgb(red, green, blue));
                        //img.SetPixel(i, j, Color.FromArgb(0,0,0));
                        pixelCount++;
                    }
                }
            }
             
        }

        private int setPixel(bool currentBit, int pixel)
        {
            int newPixel;
            if (currentBit) { newPixel = pixel | 0x01; }
            else newPixel = pixel & 0xFE;
            return newPixel;
        }
    }
}
