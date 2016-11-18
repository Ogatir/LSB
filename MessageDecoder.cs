using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSB
{
    class MessageDecoder
    {
        private Bitmap img;
        private string imageFile;
        

        public MessageDecoder(Bitmap img, string imageFile)
        {
            this.img = img;
            this.imageFile = imageFile;
        }

        

    public int getBitFromPixel(int pixelColor)
        {
            int buf = 0;
            buf = pixelColor | 0xFE;
            if (buf == 255) { return 1; } else return 0;
        }

    public string assembleMessage() {

        char bufNew, bufOld=' ';
        string word = "", buf="";
        int j=0;

        for (int i = 0; i < img.Width; i++)
        {
            if (j == 0)
            {
                for (j=0; j < img.Height; j += 3)
                {
                    buf="";
                    bufNew = getLetter(i, j);
                    word += bufNew;
                    buf = String.Concat(bufOld, bufNew);
                    bufOld = bufNew;
                    if (String.Compare(buf, "\\0") == 0) { return word; };

                }
            }

            if (j - img.Height == 0) {
                for (j=1; j < img.Height; j += 3)
                {
                    buf="";
                    bufNew = getLetter(i, j);
                    word += bufNew;
                    buf =String.Concat( bufOld , bufNew);
                    if (String.Compare(buf, "\\0") == 0) return word;

                }
            }
            if (j - img.Height == 1)
            {
                for (j = 2; j < img.Height; j += 3)
                {
                    buf = "";
                    bufNew = getLetter(i, j);
                    word += bufNew;
                    buf = String.Concat(bufOld, bufNew);
                    if (String.Compare(buf, "\\0") == 0) return word;

                }
            }
        }
        return word; 
    }

    private char getLetter(int i, int j) {
        char letter;
        int pixelCount=0;
        int[] bitsArray = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int count = 0;

        if (j < img.Height-2)
        {
            for (int k = 0; k < 3; k++)
            {
                Color pixel = img.GetPixel(i, j+k);

                bitsArray[count] = getBitFromPixel(pixel.R);
                count++;
                bitsArray[count] = getBitFromPixel(pixel.G);
                count++;

                if (k != 2)
                {
                    bitsArray[count] = getBitFromPixel(pixel.B);
                    count++;
                }
            }
        }
        else if (img.Height - j == 2) {
            Color pixel = img.GetPixel(i, j);

            bitsArray[count] = getBitFromPixel(pixel.R);
            count++;
            bitsArray[count] = getBitFromPixel(pixel.G);
            count++;
            bitsArray[count] = getBitFromPixel(pixel.B);
            count++;

            Color pixel2 = img.GetPixel(i, j+1);

            bitsArray[count] = getBitFromPixel(pixel2.R);
            count++;
            bitsArray[count] = getBitFromPixel(pixel2.G);
            count++;
            bitsArray[count] = getBitFromPixel(pixel2.B);
            count++;

            Color pixel3 = img.GetPixel(i + 1, 0);

            bitsArray[count] = getBitFromPixel(pixel3.R);
            count++;
            bitsArray[count] = getBitFromPixel(pixel3.G);
            count++;
          
        }
        else if (img.Height - j == 1)
        {
            Color pixel = img.GetPixel(i, j);

            bitsArray[count] = getBitFromPixel(pixel.R);
            count++;
            bitsArray[count] = getBitFromPixel(pixel.G);
            count++;
            bitsArray[count] = getBitFromPixel(pixel.B);
            count++;

            Color pixel2 = img.GetPixel(i+1, 0);

            bitsArray[count] = getBitFromPixel(pixel2.R);
            count++;
            bitsArray[count] = getBitFromPixel(pixel2.G);
            count++;
            bitsArray[count] = getBitFromPixel(pixel2.B);
            count++;

            Color pixel3 = img.GetPixel(i + 1, 1);

            bitsArray[count] = getBitFromPixel(pixel3.R);
            count++;
            bitsArray[count] = getBitFromPixel(pixel3.G);
            count++;
           
        }
        byte b = (byte)((bitsArray[0] << 7)
      | (bitsArray[1] << 6)
      | (bitsArray[2] << 5)
      | (bitsArray[3] << 4)
      | (bitsArray[4] << 3)
      | (bitsArray[5] << 2)
      | (bitsArray[6] << 1)
      | (bitsArray[7] << 0));

        letter = Convert.ToChar(b);
        Console.WriteLine(letter);
        return letter;
    }

    }


}
