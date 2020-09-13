using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VecEditor
{
    public partial class Form1 : Form
    {
        Color CurrentColor = Color.Black;
        Color CurrentColor2 = Color.White;
        ColorDialog colorDialog = new ColorDialog();
        Controller controller;
        Graphics graphics;
        Bitmap bitmap;
        EditorFacade editorFacade = new EditorFacade();
        int t = 2, signal;
        bool isDraw = false, isCtrl = false, isEnter = false;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            controller = new Controller(editorFacade);
            controller.SetGraphicsParams(graphics);
            controller.SetPenParams(CurrentColor, t);
            controller.SetBrushParams(CurrentColor2);
            comboBox1.Focus();
        }


        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bitmap = null;
            pictureBox1.Image = null;
            controller.Clear();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            controller.SetGraphicsParams(graphics);
            controller.ChangeState(0);
            comboBox1.Focus();

        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            t = (int)numericUpDown1.Value;
            controller.SetPenParams(CurrentColor, t);
            comboBox1.Focus();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void цветЛинииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
                controller.SetPenParams(CurrentColor, t);
            }
            comboBox1.Focus();
        }

        private void цветЗаливкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog2.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                CurrentColor2 = colorDialog2.Color;
                controller.SetBrushParams(CurrentColor2);
            }
            comboBox1.Focus();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                isDraw = true;
                controller.MouseDown(e.Location);
            }
            else if (isCtrl && controller.TrySelect(e.Location))
            {
                controller.MouseDown(e.Location);
            }
            else if (signal == 3)
            {
                controller.ChangeState(1);
                controller.MouseDown(e.Location);
            }
            else
            {
                controller.MouseDown(e.Location);
            }

            controller.ReDraw();
            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                controller.MouseUp();
                comboBox1.SelectedItem = null;
                isDraw = false;
            }
            else
            {
                controller.MouseUp();
            }

            controller.ReDraw();
            pictureBox1.Image = bitmap;
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraw)
            {
                controller.MouseMove(e.Location);
            }
            else
            {
                controller.MouseMove(e.Location);
            }
            controller.ReDraw();
            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            controller.SetGraphicsParams(graphics);
            pictureBox1.Image = bitmap;
            comboBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    signal = 0;
                    break;
                case 1:
                    signal = 1;
                    break;
                case 2:
                    signal = 2;
                    break;
                case 3:
                    signal = 3;
                    break;
            }

            if (comboBox1.SelectedIndex > -1)
            {
                controller.ClearSelectionStore();
            }

            controller.SetSignal(signal);
            controller.ChangeState(1);

            if (comboBox1.SelectedItem == null)
            {
                controller.ChangeState(3);
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                controller.ClearSelectionStore();
            }

            if (e.KeyData == Keys.Delete)
            {
                controller.DeleteObject();
            }

            if (e.Control)
            {
                isCtrl = true;
                controller.SetIsCtrl(isCtrl);
            }
            if (e.KeyData == Keys.Enter)
            {
                isEnter = true;
                controller.SetisEnter(isEnter);
                signal = 4;
            }

            controller.ReDraw();
            pictureBox1.Image = bitmap;
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            isCtrl = false;
            controller.SetIsCtrl(isCtrl);
            isEnter = false;
            controller.SetisEnter(isEnter);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controller.UnGroup();
            controller.ReDraw();
            pictureBox1.Image = bitmap;
            comboBox1.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (controller.CheckSelectionStore())
            {
                controller.Group();
                controller.ReDraw();
                pictureBox1.Image = bitmap;
                comboBox1.Focus();
            }
        }
    }
}
