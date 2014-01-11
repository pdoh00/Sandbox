using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDriver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var myImg = new Bitmap("C:\\Users\\phil.SONOCINE\\Pictures\\MyTest.jpg");
            
            //byte[] bytes = ImageReading.pixels(myImg);

            this.pictureBox1.Image = ImageReading.pixels(myImg); ;
            //grayscale
            //var gsBytes = new List<byte>();
            //for (int i = 0; i < bytes.Length; i+=3)
            //{
            //    var R = bytes[i];
            //    var G = bytes[i+1];
            //    var B = bytes[i+2];
            //    byte gs = (byte)(0.2989 * R + 0.5870 * G + 0.1140 * B);
            //    gsBytes.Add(gs);
            //}

            //using (var ms = new MemoryStream(bytes))
            //{
            //    try
            //    {
            //        ms.Seek(0, SeekOrigin.Begin);
            //        var bmp = Image.FromStream(ms);
            //        e.Graphics.DrawImage(bmp, 0, 0);
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
