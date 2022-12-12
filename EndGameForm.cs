using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class EndGameForm : Form
    {
        public EndGameForm()
        {
            InitializeComponent();
        }

        public EndGameForm(string[] names)
        {
            InitializeComponent();
            Label[] labels = new Label[] { 
                Player1, Player2, Player3, Player4
            };

            PictureBox[] pictureBoxes = new PictureBox[]{
                pictureBox1, pictureBox2, pictureBox3, pictureBox4
            };

            for (int i = 0; i < labels.Length; i++)
                labels[i].Visible = false;

            for (int i = 0; i < pictureBoxes.Length; i++)
                pictureBoxes[i].Visible = false;

            for (int i = 0; i < names.Length; i++)
            { 
                labels[i].Text = names[i];
                labels[i].Visible = true;
            }

            for (int i = 0; i < names.Length; i++)
            {
                pictureBoxes[i].Image = ImageInitialize(names[i]);
                pictureBoxes[i].Visible = true;
            }

        }

        private Image ImageInitialize(string name) {
            Image image = Resource1.missing_texture;
            switch (name) {
                case "Player1": return Resource1.RedIcon;
                case "Player2": return Resource1.BlueIcon;
                case "Player3": return Resource1.GreenIcon;
                case "Player4": return Resource1.YellowIcon;
            }

            return image;
        }

        private void EndGameForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
