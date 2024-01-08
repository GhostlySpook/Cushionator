using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace Cushionator
{
    public partial class Form1 : Form
    {
        private const string SOUND_PATH_DUCK = @".\Resources\duck.wav";
        private const string SOUND_PATH_BANANA = @".\Resources\banana.wav";
        private const string SOUND_PATH_BONK = @".\Resources\bonk.wav";
        private const string SOUND_PATH_BOOM = @".\Resources\boom.wav";

        private const string SOUND_PATH_WHOOPIE = @".\Resources\whoopie.wav";
        private const string SOUND_PATH_WHOOPIE_MINUS_4 = @".\Resources\whoopie-4.wav";
        private const string SOUND_PATH_WHOOPIE_MINUS_3 = @".\Resources\whoopie-3.wav";
        private const string SOUND_PATH_WHOOPIE_MINUS_2 = @".\Resources\whoopie-2.wav";
        private const string SOUND_PATH_WHOOPIE_MINUS_1 = @".\Resources\whoopie-1.wav";
        private const string SOUND_PATH_WHOOPIE_PLUS_1 = @".\Resources\whoopie+1.wav";
        private const string SOUND_PATH_WHOOPIE_PLUS_2 = @".\Resources\whoopie+2.wav";
        private const string SOUND_PATH_WHOOPIE_PLUS_3 = @".\Resources\whoopie+3.wav";
        private const string SOUND_PATH_WHOOPIE_PLUS_4 = @".\Resources\whoopie+4.wav";
        private const string SOUND_PATH_WHOOPIE_PLUS_5 = @".\Resources\whoopie+5.wav";

        System.Media.SoundPlayer player_duck;
        System.Media.SoundPlayer player_banana;
        System.Media.SoundPlayer player_bonk;
        System.Media.SoundPlayer player_boom;

        System.Media.SoundPlayer player_whoopie;
        System.Media.SoundPlayer player_whoopie_minus_4;
        System.Media.SoundPlayer player_whoopie_minus_3;
        System.Media.SoundPlayer player_whoopie_minus_2;
        System.Media.SoundPlayer player_whoopie_minus_1;
        System.Media.SoundPlayer player_whoopie_plus_1;
        System.Media.SoundPlayer player_whoopie_plus_2;
        System.Media.SoundPlayer player_whoopie_plus_3;
        System.Media.SoundPlayer player_whoopie_plus_4;
        System.Media.SoundPlayer player_whoopie_plus_5;

        private String[] small_whoopie_array =
        {
            @".\Resources\small_whoopie+5.wav",
            @".\Resources\small_whoopie-4.wav",
            @".\Resources\small_whoopie-3.wav",
            @".\Resources\small_whoopie-2.wav",
            @".\Resources\small_whoopie-1.wav",
            @".\Resources\small_whoopie.wav",
            @".\Resources\small_whoopie+1.wav",
            @".\Resources\small_whoopie+2.wav",
            @".\Resources\small_whoopie+3.wav",
            @".\Resources\small_whoopie+4.wav"
        };

        private System.Media.SoundPlayer[] numberPlayers;

        private List<KeyHandler> keyHandlers;
        private Keys[][] keyArray = new Keys[][] {
            /*Esc col*/ /*new Keys[] { Keys.Escape, Keys.Oem5, Keys.Tab, Keys.CapsLock, Keys.Shift, Keys.LControlKey, Keys.LWin },*/
            /*1 col*/ new Keys[] { Keys.D1, Keys.Q, Keys.A, Keys.Z/*, Keys.Alt */},
            /*2 col*/ new Keys[] { Keys.D2, Keys.W, Keys.S, Keys.X },
            /*3 col*/ new Keys[] { Keys.D3, Keys.E, Keys.D, Keys.C },
            /*4 col*/ new Keys[] { Keys.D4, Keys.R, Keys.F, Keys.V },
            /*5 col*/ new Keys[] { Keys.D5, Keys.T, Keys.G, Keys.B },
            /*6 col*/ new Keys[] { Keys.D6, Keys.Y, Keys.H, Keys.N },
            /*7 col*/ new Keys[] { Keys.D7, Keys.U, Keys.J, Keys.M },
            /*8 col*/ new Keys[] { Keys.D8, Keys.I, Keys.K/*, Keys.Oemcomma, Keys.RMenu*/ },
            /*9 col*/ new Keys[] { Keys.D9, Keys.O, Keys.L/*, Keys.OemPeriod*/ },
            /*0 col*/ new Keys[] { Keys.D0, Keys.P/*, Keys.OemMinus*/ },
            /*' col*/ /*new Keys[] { Keys.Oemtilde, Keys.OemOpenBrackets },*/
            /*¿ col*/ /*new Keys[] { Keys.OemQuestion, Keys.Oemplus, Keys.OemCloseBrackets, Keys.Menu },*/
            /*Backspace col*/ new Keys[] { Keys.Back/*, Keys.Enter, Keys.RShiftKey, Keys.RControlKey*/ },
            /*Space col*/ new Keys[] { Keys.Space/*, Keys.Enter, Keys.RShiftKey, Keys.RControlKey*/ }
        };

        InputSimulator sim;

        public Form1()
        {
            player_duck = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_DUCK);
            player_banana = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BANANA);
            player_boom = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BOOM);

            //TO DO Add hooks for every key on the keyboard
            //1 - Define whoopie sounds
            player_whoopie = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE);
            player_whoopie_minus_4 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_MINUS_4);
            player_whoopie_minus_3 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_MINUS_3);
            player_whoopie_minus_2 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_MINUS_2);
            player_whoopie_minus_1 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_MINUS_1);
            player_whoopie_plus_1 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_PLUS_1);
            player_whoopie_plus_2 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_PLUS_2);
            player_whoopie_plus_3 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_PLUS_3);
            player_whoopie_plus_4 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_PLUS_4);
            player_whoopie_plus_5 = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_PLUS_5);

            numberPlayers = new System.Media.SoundPlayer[10];
            for(int i = 0; i < numberPlayers.Length; i++)
            {
                numberPlayers[i] = new System.Media.SoundPlayer(soundLocation: small_whoopie_array[i]);
            }

            player_bonk = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BONK);

            //2 - Add hooks to normal keys from a-z 0-9
            keyHandlers = new List<KeyHandler>();

            for(int i = 0; i < keyArray.Length; i++)
            {
                for(int j = 0; j < keyArray[i].Length; j++)
                {
                    KeyHandler ghk = new KeyHandler(keyArray[i][j], this);
                    ghk.Register();
                    keyHandlers.Add(ghk);
                }
            }

            //3 Get keyboard simulator
            sim = new InputSimulator();

            InitializeComponent();

            player_banana.Play();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            player_duck.Play();
            this.WindowState = FormWindowState.Minimized;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 /*WM_HOTKEY_MSG_ID*/)
            {
                Console.WriteLine("Key in message: " + (int)m.WParam);

                Keys keyId = (Keys)m.WParam;

                //Make sound depending of letter
                switch (keyId)
                {
                    case Keys.Q:
                    case Keys.A:
                    case Keys.Z:
                        player_whoopie_minus_4.Play();
                        break;
                    case Keys.W: 
                    case Keys.S:
                    case Keys.X:
                        player_whoopie_minus_3.Play();
                        break;
                    case Keys.E:
                    case Keys.D:
                    case Keys.C:
                        player_whoopie_minus_2.Play();
                        break;
                    case Keys.R:
                    case Keys.F:
                    case Keys.V:
                        player_whoopie_minus_1.Play();
                        break;
                    case Keys.T:
                    case Keys.G:
                    case Keys.B:
                        player_whoopie.Play();
                        break;
                    case Keys.Y:
                    case Keys.H:
                    case Keys.N:
                        player_whoopie_plus_1.Play();
                        break;
                    case Keys.U:
                    case Keys.J:
                    case Keys.M:
                        player_whoopie_plus_2.Play();
                        break;
                    case Keys.I:
                    case Keys.K:
                        player_whoopie_plus_3.Play();
                        break;
                    case Keys.O:
                    case Keys.L:
                        player_whoopie_plus_4.Play();
                        break;
                    case Keys.P:
                        player_whoopie_plus_5.Play();
                        break;
                    case Keys.Back:
                        player_bonk.Play();
                        break;
                    case Keys.Space:
                        player_boom.Play();
                        break;
                }

                //Make sound depending of number
                if((int)keyId >= 48 && (int)keyId <= 57)
                {
                    int numToPlay = (int)keyId - 48;
                    Console.WriteLine("Pos: " + numToPlay);
                    numberPlayers[numToPlay].Play();
                }

                //If it is a letter
                if ((int)keyId >= 65 && (int)keyId <= 90)
                {
                    KeyHandler found = keyHandlers.Find(x => x.key == (int)keyId);
                    found.Unregister();
                    sim.Keyboard.KeyPress((VirtualKeyCode)keyId);
                    //SendKeys.SendWait("+{" + (char)keyId + "}");
                    found.Register();
                }

                //Make sound depending of number
                if ((int)keyId >= 48 && (int)keyId <= 57)
                {
                    KeyHandler found = keyHandlers.Find(x => x.key == (int)keyId);
                    found.Unregister();
                    SendKeys.SendWait("+{" + (char)keyId + "}");
                    found.Register();
                }

                //Handle space
                else if ((int)keyId == (int)Keys.Space)
                {
                    KeyHandler found = keyHandlers.Find(x => x.key == (int)keyId);
                    found.Unregister();
                    SendKeys.SendWait(" ");
                    found.Register();
                }

                //Handle backspace
                else if((int)keyId == (int)Keys.Back)
                {
                    KeyHandler found = keyHandlers.Find(x => x.key == (int)keyId);
                    found.Unregister();
                    SendKeys.SendWait("{BACKSPACE}");
                    found.Register();
                }

            }
            base.WndProc(ref m);
        }
    }
}
