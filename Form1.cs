using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSB
{
    public partial class Form1 : Form
    {
        string imageFile;

        public Form1()
        {
            
            InitializeComponent();
        }

        private void chooseImg_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.bmp)|*.bmp";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                imageFile = openDialog.FileName.ToString();
                pictureBox1.ImageLocation = imageFile;
                pictureBox1.Load();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (message_textBox.Text != "")
            {
                Bitmap img = new Bitmap(imageFile);
                Console.WriteLine("Width =" + img.Width + "\nHeight =" + img.Height);

                MessageEncoder me = new MessageEncoder(img, imageFile);
                MessageContainer mc = new MessageContainer(message_textBox.Text);
                mc.FillMessageContainer();
                Console.WriteLine("Bit array is ");
                mc.WriteBits();

                me.EncodeMessage(mc,message_textBox.TextLength );
              
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Image files (*.bmp)|*.bmp";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    imageFile = saveDialog.FileName.ToString();

                    img.Save(imageFile);
                }
            }
            else MessageBox.Show("Enter message");
        }

        private void Decode_btn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.bmp)|*.bmp";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                imageFile = openDialog.FileName.ToString();
            }

            Bitmap img = new Bitmap(imageFile);
            MessageDecoder md = new MessageDecoder(img, imageFile);
           string text= md.assembleMessage();
           text = text.Substring(0, text.Length - 2);
           MessageBox.Show(text);
           MessageBox.Show(text.Length.ToString());
           //Console.WriteLine(frase);

            
        }
        
        
    
    }
}
