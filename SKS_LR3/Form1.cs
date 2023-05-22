using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace SKS_LR3
{

    public partial class Form1 : Form
    {
        
        View view = new View();
        private bool needreload = false;
        private int mode = -1;
        private System.Drawing.Color m_col = System.Drawing.Color.Black;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void handle_update()
        {
            float r = (float)Convert.ToInt32(m_col.R) / 255.0f;
            float g = (float)Convert.ToInt32(m_col.G) / 255.0f;
            float b = (float)Convert.ToInt32(m_col.B) / 255.0f;

            float x1 = (float)trackBar1.Value / 10;
            float x2 = (float)trackBar3.Value / 10;
            float x3 = (float)trackBar2.Value / 10;
            view.SetLightCoefs(x1, x2, x3, 512.0f);
            view.SetReflection((float)trackBar7.Value / 10);
            if (needreload = true)
            {
                needreload = false;

                switch (mode)
                {
                    case 0:
                        view.SetUpWallCoefs(r, g, b);
                        break;
                    case 1:
                        view.SetDownWallCoefs(r, g, b);
                        break;
                    case 2:
                        view.SetLeftWallCoefs(r, g, b);
                        break;
                    case 3:
                        view.SetRightWallCoefs(r, g, b);
                        break;
                    case 4:
                        view.SetBackWallCoefs(r, g, b);
                        break;
                    case 5:
                        view.SetBigSphereCoefs(r, g, b);
                        break;
                    case 6:
                        view.SetSmallSphereCoefs(r, g, b);
                        break;
                }
            }

            glControl2.Invalidate();
        }

        private void glControl2_Paint(object sender, PaintEventArgs e)
        {
            
            view.InitScreen();
            glControl2.SwapBuffers();
            GL.UseProgram(0);
        }

        private void glControl2_Load(object sender, EventArgs e)
        {
          
            view.Start();
        }

        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            handle_update();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = 0;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            needreload = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mode = 2;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            mode = 3; 
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            mode = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            mode = 5;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            mode = 6;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            needreload = true;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            needreload = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {

                m_col = colorDlg.Color;

            }

            handle_update();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            handle_update();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            handle_update();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            handle_update();
        }

        private void trackBar7_ValueChanged(object sender, EventArgs e)
        {
            handle_update();
        }
    }
}
