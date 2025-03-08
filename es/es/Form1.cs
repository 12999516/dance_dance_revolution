using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.Asio;

namespace es
{
    public partial class Form1 : Form
    {
       

        int conteggio = 0;
        int quale;
        int cont = 0;
        Random random = new Random(Environment.TickCount);
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;
        string filePath;

        public Form1()
        {
            
            InitializeComponent();
            updateUI();
            // filePath = @"C:\Users\Sebastiano\Desktop\ddr-main\thunderstruck.mp3";
            string x = Directory.GetCurrentDirectory();
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "thunderstruck.mp3");

            PlayMusicInLoop(filePath);

        }


        private void PlayMusicInLoop(string filePath)
        { 
            waveOutDevice = new WaveOutEvent();
            audioFileReader = new AudioFileReader(filePath);

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();

        
            waveOutDevice.PlaybackStopped += HandlePlaybackStopped;
        }

        
        private void HandlePlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }

            
            waveOutDevice = new WaveOutEvent();

            string x = Directory.GetCurrentDirectory();
            audioFileReader = new AudioFileReader(filePath);

            //audioFileReader = new AudioFileReader("C:\\Users\\Sebastiano\\Desktop\\ddr-main\\thunderstruck.mp3");

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();


            waveOutDevice.PlaybackStopped += HandlePlaybackStopped;
        }




        protected void OnFormClosed(FormClosedEventArgs e)
        {
            waveOutDevice.Dispose();
            audioFileReader.Dispose();
            base.OnFormClosed(e);
        }
        private void Error()
        {
            btn_center.Text = "error";
            btn_down.Text = "error";
            btn_up.Text = "error";
            btn_right.Text = "error";
            btn_center.Text = "error";
        }
        private void btn_upp()
        {
            btn_center.BackColor = Color.White;
            btn_right.BackColor = Color.White;
            btn_left.BackColor = Color.White;
            btn_down.BackColor = Color.White;
            btn_up.BackColor = Color.Aquamarine;
        }

        private void btn_downn()
        {
            btn_center.BackColor = Color.White;
            btn_right.BackColor = Color.White;
            btn_left.BackColor = Color.White;
            btn_up.BackColor = Color.White;
            btn_down.BackColor = Color.Yellow;
        }

        private void btn_rightt()
        {
            btn_center.BackColor = Color.White;
            btn_down.BackColor = Color.White;
            btn_up.BackColor = Color.White;
            btn_left.BackColor = Color.White;
            btn_right.BackColor = Color.Violet;
        }

        private void btn_leftt()
        {
            btn_center.BackColor = Color.White;
            btn_down.BackColor = Color.White;
            btn_up.BackColor = Color.White;
            btn_right.BackColor = Color.White;
            btn_left.BackColor = Color.Blue;
        }

        private void btn_centerr()
        {
            btn_right.BackColor = Color.White;
            btn_left.BackColor = Color.White;
            btn_down.BackColor = Color.White;
            btn_up.BackColor = Color.White;
            btn_center.BackColor = Color.Gold;
        }
        private void btn_up_Click(object sender, EventArgs e)
        {
            if(btn_up.BackColor != Color.White)
            {
                conteggio += 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            else
            {
                conteggio -= 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            updateUI();
        }

        private void btn_left_Click(object sender, EventArgs e)
        {
            if (btn_left.BackColor != Color.White)
            {
                conteggio += 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            else
            {
                conteggio -= 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            
            updateUI();
        }

        private void btn_center_Click(object sender, EventArgs e)
        {
            if (btn_center.BackColor != Color.White)
            {
                conteggio += 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            else
            {
                conteggio -= 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            
            updateUI();
        }

        private void btn_right_Click(object sender, EventArgs e)
        {
            if (btn_right.BackColor != Color.White)
            {
                conteggio += 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            else
            {
                conteggio -= 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            
            updateUI();
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (btn_down.BackColor != Color.White)
            {
                conteggio += 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            else
            {
                conteggio -= 1;
                lbl_point.Text = $"i tui punti: \n {conteggio}";
            }
            updateUI();
        }

        private void updateUI()
        {

            if(cont == 0)
            {
                quale = random.Next(1, 6);

                switch (quale)
                {
                    case 1:
                        btn_upp();
                        break;

                    case 2:
                        btn_downn();
                        break;

                    case 3:
                        btn_rightt();
                        break;

                    case 4:
                        btn_leftt();
                        break;
                    case 5:
                        btn_centerr();
                        break;
                    default:
                        Error();
                        break;

                }
                cont += 1;
                prox_passo(ref quale);
            } else
            {
                switch (quale)
                {
                    case 1:
                        btn_upp();
                        break;

                    case 2:
                        btn_downn();
                        break;

                    case 3:
                        btn_rightt();
                        break;

                    case 4:
                        btn_leftt();
                        break;
                    case 5:
                        btn_centerr();
                        break;
                    default:
                        Error();
                        break;

                }
                cont += 1;
                prox_passo(ref quale);
            }

            
        }

        private void prox_passo(ref int quale)
        {
            quale = random.Next(1, 6);
            cambia_imm_prox(quale);
        }

        private void cambia_imm_prox(int quale)
        {
            switch (quale)
            {
                case 1:
                    pnl_prossimo_passo.BackgroundImage = Properties.Resources.up_removebg_preview;
                    pnl_prossimo_passo.BackgroundImageLayout = ImageLayout.Zoom;
                    break;

                case 2:
                    pnl_prossimo_passo.BackgroundImage = Properties.Resources.down_removebg_preview;
                    pnl_prossimo_passo.BackgroundImageLayout = ImageLayout.Zoom;
                    break;

                case 3:
                    pnl_prossimo_passo.BackgroundImage = Properties.Resources.right_removebg_preview;
                    pnl_prossimo_passo.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                    
                case 4:
                    pnl_prossimo_passo.BackgroundImage = Properties.Resources.left_removebg_preview;
                    pnl_prossimo_passo.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                case 5:
                    pnl_prossimo_passo.BackgroundImage = Properties.Resources.center_removebg_preview;
                    pnl_prossimo_passo.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                default:
                    Error();
                    break;
            }
        }

        private void pnl_prossimo_passo_Paint(object sender, PaintEventArgs e)
        {

        }

        /* int quale;
            Random random = new Random(Environment.TickCount);
            quale = random.Next(1, 6);

            switch (quale)
            {
                case 1:
                    btn_upp();
                    break;

                case 2:
                    btn_downn();
                    break;

                case 3:
                    btn_rightt();
                    break;

                case 4:
                    btn_leftt();
                    break;
                case 5:
                    btn_centerr();
                    break;
                default:
                    Error();
                    break;

            }*/
    }
}
