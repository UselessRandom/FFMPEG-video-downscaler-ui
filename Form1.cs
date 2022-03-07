using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFMPEG_video_downscaler_ui
{
    public partial class Form1 : Form
    {   
        private OpenFileDialog ofd;
        private SaveFileDialog sfd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Filter = "MP4 (*.mp4)|*.mp4|MOV (*.mov)|*.mov|AVI (*.avi)|*.avi|FLV (*.flv)|*.flv|MKV (*.mkv)|*.mkv";
            sfd = new SaveFileDialog();
            sfd.Filter = "MP4 (*.mp4)|*.mp4|MOV (*.mov)|*.mov|AVI (*.avi)|*.avi|FLV (*.flv)|*.flv|MKV (*.mkv)|*.mkv";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ofd.ShowDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo ofdInfo = new System.IO.FileInfo(ofd.FileName);
                if (ofdInfo.ToString().Any(Char.IsWhiteSpace) == true)
                {
                    MessageBox.Show("File name cannot have spaces", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.textBox1.Text = ofdInfo.ToString();
                }
            }
        }

        private void downscaleBtn_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;
                if (filePath.Any(Char.IsWhiteSpace) == true)
                {
                    MessageBox.Show("Output file name cannot have spaces", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    outputBox.Text = filePath;
                    string ffmpegCMD = $"/C ffmpeg -i {textBox1.Text} -vf scale={w.Text}:{h.Text} {outputBox.Text}";
                    System.Diagnostics.Process.Start("CMD.exe", ffmpegCMD);
                    Console.WriteLine(ffmpegCMD);
                }
            }
            
        }
    }
}
