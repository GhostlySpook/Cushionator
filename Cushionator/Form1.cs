using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cushionator
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player_duck;
        System.Media.SoundPlayer player_banana;

        public Form1()
        {
            player_duck = new System.Media.SoundPlayer(soundLocation: @".\Resources\duck.wav");
            player_banana = new System.Media.SoundPlayer(soundLocation: @".\Resources\banana.wav");

            InitializeComponent();

            player_banana.Play();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player_duck.Play();
        }
    }
}
