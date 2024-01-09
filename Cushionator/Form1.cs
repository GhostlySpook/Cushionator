using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private const string SOUND_PATH_TYPEWRITER_DING = @".\Resources\typewriter_ding.wav";
        private const string SOUND_PATH_HONK = @".\Resources\honk.wav";
        private const string SOUND_PATH_DOOM = @".\Resources\doom.wav";
        private const string SOUND_PATH_NO = @".\Resources\NO.wav";
        private const string SOUND_PATH_BABY_GASP = @".\Resources\baby_gasp.wav";
        private const string SOUND_PATH_CAMERA = @".\Resources\camera.wav";
        private const string SOUND_PATH_WHONK = @".\Resources\whonk.wav";
        private const string SOUND_PATH_MEOW = @".\Resources\meow.wav";
        private const string SOUND_PATH_BARK = @".\Resources\bark.wav";
        private const string SOUND_PATH_GNOME = @".\Resources\gnome.wav";
        private const string SOUND_PATH_SPLAT = @".\Resources\splat.wav";
        private const string SOUND_PATH_RIZZ = @".\Resources\rizz.wav";
        private const string SOUND_PATH_BOOWOMP = @".\Resources\boowomp.wav";
        private const string SOUND_PATH_STOP = @".\Resources\stop.wav";
        private const string SOUND_PATH_PIPE = @".\Resources\pipe.wav";

        private const string SOUND_PATH_OOF = @".\Resources\oof.wav";
        private const string SOUND_PATH_TADA = @".\Resources\tada.wav";
        private const string SOUND_PATH_LEGO = @".\Resources\lego.wav";
        private const string SOUND_PATH_SMASH = @".\Resources\smash.wav";
        private const string SOUND_PATH_POP = @".\Resources\pop.wav";

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

        private const string SOUND_PATH_WHOOPIE_REVERB = @".\Resources\whoopie_reverb.wav";

        System.Media.SoundPlayer player_duck;
        System.Media.SoundPlayer player_banana;
        System.Media.SoundPlayer player_bonk;
        System.Media.SoundPlayer player_boom;
        System.Media.SoundPlayer player_typewriter_ding;
        System.Media.SoundPlayer player_honk;
        System.Media.SoundPlayer player_doom;
        System.Media.SoundPlayer player_NO;
        System.Media.SoundPlayer player_baby_gasp;
        System.Media.SoundPlayer player_camera;
        System.Media.SoundPlayer player_whonk;
        System.Media.SoundPlayer player_meow;
        System.Media.SoundPlayer player_bark;
        System.Media.SoundPlayer player_gnome;
        System.Media.SoundPlayer player_splat;
        System.Media.SoundPlayer player_rizz;
        System.Media.SoundPlayer player_boowomp;
        System.Media.SoundPlayer player_stop;
        System.Media.SoundPlayer player_pipe;

        System.Media.SoundPlayer player_pop;
        System.Media.SoundPlayer player_oof;
        System.Media.SoundPlayer player_tada;
        System.Media.SoundPlayer player_lego;
        System.Media.SoundPlayer player_smash;

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

        System.Media.SoundPlayer player_whoopie_loud;

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

        private String[] function_sound_array =
        {
            @".\Resources\alert.wav", //Alert -------------
            @".\Resources\codec.wav", //Codec
            @".\Resources\ration.wav", //Ration
            @".\Resources\death.wav", //Death
            @".\Resources\mission_start.wav", //Mission start -----------------
            @".\Resources\thank_you.wav", // Thank you
            @".\Resources\heavy_machine_gun.wav", // Machine gun
            @".\Resources\mission_complete.wav", // Mission complete
            @".\Resources\hello.wav", //Hello -----------------
            @".\Resources\nose.wav", //Nose
            @".\Resources\whonk.wav", //Whonk
            @".\Resources\small_whoopie+2.wav" 
        };

        private System.Media.SoundPlayer[] numberPlayers;
        private System.Media.SoundPlayer[] functionPlayers;

        private List<KeyHandler> keyHandlers;
        private Keys[][] keyArray = new Keys[][] {
            /*F col*/ new Keys[] { Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12  },
            /*Esc col*/ new Keys[] { Keys.Escape, Keys.Tab, Keys.OemPipe /* Keys.Oem5, Keys.Tab, Keys.CapsLock, Keys.Shift, Keys.LControlKey, Keys.LWin*/ },
            /*1 col*/ new Keys[] { Keys.D1, Keys.Q, Keys.A, Keys.Z/*, Keys.Alt */},
            /*2 col*/ new Keys[] { Keys.D2, Keys.W, Keys.S, Keys.X },
            /*3 col*/ new Keys[] { Keys.D3, Keys.E, Keys.D, Keys.C },
            /*4 col*/ new Keys[] { Keys.D4, Keys.R, Keys.F, Keys.V },
            /*5 col*/ new Keys[] { Keys.D5, Keys.T, Keys.G, Keys.B },
            /*6 col*/ new Keys[] { Keys.D6, Keys.Y, Keys.H, Keys.N },
            /*7 col*/ new Keys[] { Keys.D7, Keys.U, Keys.J, Keys.M },
            /*8 col*/ new Keys[] { Keys.D8, Keys.I, Keys.K, Keys.Oemcomma/*, Keys.RMenu*/ },
            /*9 col*/ new Keys[] { Keys.D9, Keys.O, Keys.L, Keys.OemPeriod },
            /*0 col*/ new Keys[] { Keys.D0, Keys.P/*, Keys.OemMinus*/ },
            /*6 key group*/ new Keys[] { /*Keys.Oemtilde,*/Keys.Insert, Keys.Delete, Keys.Home, Keys.End, Keys.PageUp, Keys.PageDown },
            /*Numpad operator group*/ new Keys[] { Keys.Add, Keys.Subtract, Keys.Multiply, Keys.Divide, Keys.Decimal/*Keys.OemQuestion*//*, Keys.Oemplus, Keys.OemCloseBrackets, Keys.Menu*/ },
            /*Misc col*/ new Keys[] { Keys.Back, Keys.Enter, Keys.PrintScreen, Keys.Pause/*, Keys.RShiftKey, Keys.RControlKey*/ },
            /*Symbol group*/ new Keys[] { Keys.Space, Keys.OemMinus, Keys.Oemplus/*, Keys.RShiftKey, Keys.RControlKey*/ }
        };

        InputSimulator sim;
        bool canShow = true;

        public Form1()
        {
            player_duck = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_DUCK);
            player_banana = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BANANA);
            player_boom = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BOOM);
            player_typewriter_ding = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_TYPEWRITER_DING);
            player_honk = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_HONK);
            player_doom = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_DOOM);
            player_NO = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_NO);
            player_baby_gasp = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BABY_GASP);
            player_bonk = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BONK);
            player_camera = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_CAMERA);
            player_whonk = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHONK);
            player_meow = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_MEOW);
            player_bark = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BARK);
            player_gnome = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_GNOME);
            player_splat = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_SPLAT);
            player_rizz = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_RIZZ);
            player_boowomp = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_BOOWOMP);
            player_stop = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_STOP);
            player_pipe = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_PIPE);

            player_pop = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_POP);
            player_oof = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_OOF);
            player_tada = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_TADA);
            player_lego = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_LEGO);
            player_smash = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_SMASH);

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

            player_whoopie_loud = new System.Media.SoundPlayer(soundLocation: SOUND_PATH_WHOOPIE_REVERB);

            //Players for numbers
            numberPlayers = new System.Media.SoundPlayer[10];
            for(int i = 0; i < numberPlayers.Length; i++)
            {
                numberPlayers[i] = new System.Media.SoundPlayer(soundLocation: small_whoopie_array[i]);
            }

            //Player for functions
            functionPlayers = new System.Media.SoundPlayer[12];
            for (int i = 0; i < functionPlayers.Length; i++)
            {
                functionPlayers[i] = new System.Media.SoundPlayer(soundLocation: function_sound_array[i]);
            }

            //2 - Add hooks to keys
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
            player_honk.Play();
            //this.WindowState = FormWindowState.Minimized 
            Hide();
            notifyIcon1.Visible = true;

            //Send notification
            var imageUri = Path.GetFullPath(@"Resources\Moony.PNG");

            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText("Mwahahahaha!")
                .AddText("The cushionator has taken hold of your notification tray! So sneaky!")
                .AddAppLogoOverride(new Uri(imageUri))
                .Show();
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
                    case Keys.Oemcomma:
                        player_whoopie_plus_3.Play();
                        break;
                    case Keys.O:
                    case Keys.L:
                    case Keys.OemPeriod:
                        player_whoopie_plus_4.Play();
                        break;
                    case Keys.P:
                        player_whoopie_plus_5.Play();
                        break;
                    case Keys.Back:
                        player_bonk.Play();
                        break;
                    case Keys.Space:
                        player_doom.Play();
                        break;
                    case Keys.Enter:
                        player_typewriter_ding.Play();
                        break;
                    case Keys.Escape:
                        player_NO.Play();
                        break;
                    case Keys.Tab:
                        player_baby_gasp.Play();
                        break;
                    case Keys.OemMinus:
                        player_boom.Play();
                        break;
                    /*case Keys.Oemplus:
                        player_whonk.Play();
                        break;*/
                    case Keys.PrintScreen:
                        player_camera.Play();
                        break;
                    case Keys.Pause:
                        player_stop.Play();
                        break;
                    case Keys.Insert:
                        player_gnome.Play();
                        break;
                    case Keys.Delete:
                        player_splat.Play();
                        break;
                    case Keys.Home:
                        player_rizz.Play();
                        break;
                    case Keys.End:
                        player_boowomp.Play();
                        break;
                    case Keys.PageUp:
                        player_meow.Play();
                        break;
                    case Keys.PageDown:
                        player_bark.Play();
                        break;
                    case Keys.Add:
                        player_pop.Play();
                        break;
                    case Keys.Subtract:
                        player_oof.Play();
                        break;
                    case Keys.Multiply:
                        player_tada.Play();
                        break;
                    case Keys.Divide:
                        player_lego.Play();
                        break;
                    case Keys.Decimal: 
                        player_smash.Play();
                        break;
                    case Keys.OemPipe:
                        player_pipe.Play();
                        break;
                 }

                //Make sound depending of number
                if((int)keyId >= 48 && (int)keyId <= 57)
                {
                    int numToPlay = (int)keyId - 48;
                    //Console.WriteLine("Pos: " + numToPlay);
                    numberPlayers[numToPlay].Play();
                }

                //Make sound for function keys
                if ((int)keyId >= 112 && (int)keyId <= 123)
                {
                    int numToPlay = (int)keyId - 112;
                    functionPlayers[numToPlay].Play();
                }

                //RESEND LETTERS-------------------------------------------------------

                //If it is a letter or number
                if ( ((int)keyId >= 48 && (int)keyId <= 57) || 
                    ((int)keyId >= 65 && (int)keyId <= 90) ||
                    ((int)keyId >= 112 && (int)keyId <= 123))
                {
                    KeyHandler found = keyHandlers.Find(x => x.key == (int)keyId);
                    found.Unregister();
                    sim.Keyboard.KeyPress((VirtualKeyCode)keyId);
                    found.Register();
                }
                //Another kind of key
                else
                {
                    KeyHandler found;
                    Keys[] otherKeys = { Keys.OemPipe, Keys.Add, Keys.Subtract, Keys.Multiply, Keys.Divide, Keys.Insert, Keys.Delete, Keys.Home, Keys.End, Keys.PageUp, Keys.PageDown, Keys.PrintScreen, Keys.Pause, Keys.Oemplus, Keys.OemMinus, Keys.Tab, Keys.Space, Keys.Enter, Keys.Back, Keys.Oemcomma, Keys.OemPeriod, Keys.Escape };

                    if(Array.Find(otherKeys, x => x == keyId) != 0)
                    {
                        String keyToSend = "";

                        switch (keyId)
                        {
                            //Handle space
                            case Keys.Space:
                                keyToSend = " ";
                                break;

                            //Handle backspace
                            case Keys.Back:
                                keyToSend = "{BACKSPACE}";
                                break;

                            case Keys.Enter:
                                keyToSend = "{ENTER}";
                                break;

                            case Keys.Oemcomma:
                                keyToSend = ",";
                                break;

                            case Keys.OemPeriod:
                                keyToSend = ".";
                                break;

                            case Keys.Escape:
                                keyToSend = "{ESC}";
                                break;

                            case Keys.Tab:
                                keyToSend = "{TAB}";
                                break;

                            case Keys.Oemplus:
                                keyToSend = "{+}";
                                break;

                            case Keys.OemMinus:
                                keyToSend = "{-}";
                                break;

                            case Keys.PrintScreen:
                                keyToSend = "{PRTSC}";
                                break;

                            case Keys.Pause:
                                keyToSend = "{BREAK}";
                                break;

                            case Keys.Insert:
                                keyToSend = "{INSERT}";
                                break;

                            case Keys.Delete:
                                keyToSend = "{DELETE}";
                                break;

                            case Keys.Home:
                                keyToSend = "{HOME}";
                                break;

                            case Keys.End:
                                keyToSend = "{END}";
                                break;

                            case Keys.PageUp:
                                keyToSend = "{PGUP}";
                                break;

                            case Keys.PageDown:
                                keyToSend = "{PGDN}";
                                break;

                            case Keys.Add:
                                keyToSend = "{ADD}";
                                break;

                            case Keys.Subtract:
                                keyToSend = "{SUBTRACT}";
                                break;

                            case Keys.Multiply:
                                keyToSend = "{MULTIPLY}";
                                break;

                            case Keys.Divide:
                                keyToSend = "{DIVIDE}";
                                break;

                            case Keys.Decimal:
                                keyToSend = ".";
                                break;

                            case Keys.OemPipe:
                                keyToSend = "|";
                                break;
                        }

                        found = keyHandlers.Find(x => x.key == (int)keyId);
                        found.Unregister();
                        SendKeys.SendWait(keyToSend);
                        found.Register();
                    }
                }

            }
            base.WndProc(ref m);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (canShow)
            {
                Show();
                player_duck.Play();
                notifyIcon1.Visible = false;
            }
        }

        private void revealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            player_duck.Play();
            notifyIcon1.Visible = false;
        }

        private void selfDestructToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a timer with a two second interval.
            System.Timers.Timer aTimer = new System.Timers.Timer(3000);
            aTimer.Elapsed += closeFormEvent;

            player_whoopie_loud.Play();

            aTimer.Enabled = true;
            canShow = false;
            contextMenuStrip1.Enabled = false;
            //Close();
        }

        private void closeFormEvent(object sender, ElapsedEventArgs e)
        {
            Application.Exit();
        }
    }
}
