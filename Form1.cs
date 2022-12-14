using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;



namespace Lab_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Начальные настройки";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 2;
            numericUpDown2.Value = 10;

            checkBox1.Checked = Properties.Settings.Default.DevelopMode;

            button2.Enabled = Properties.Settings.Default.LoadGame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int player_count = (int)numericUpDown1.Value;
            Properties.Settings.Default.MoveSpeed = (int)numericUpDown2.Value;
            Properties.Settings.Default.DevelopMode = checkBox1.Checked;

            Properties.Settings.Default.Save();

            GameScence gameScence = new GameScence(player_count);
            gameScence.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataContractSerializer jsonF = new DataContractSerializer(typeof(SerializeGame));

            using (FileStream fileStream = new FileStream("GameSave.json", FileMode.Open))
            {
                SerializeGame loadgame = (SerializeGame)jsonF.ReadObject(fileStream);
                GameScence gameScence = new GameScence(loadgame);
                gameScence.Show();
                this.Hide();
            }

        }
    }
}
