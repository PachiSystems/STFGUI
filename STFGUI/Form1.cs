using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STFGUI
{
    public partial class Form1 : Form
    {
        string tempFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout aboutForm = new frmAbout();
            aboutForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.pathToAtomicParsley == "" || Properties.Settings.Default.pathToHandbrake == "" || Properties.Settings.Default.pathToMP4Box == "")
            {
                frmOptions optionsForm = new frmOptions();
                optionsForm.ShowDialog();
            }

            frontPage.Show();
            subtitleOnly.Hide();
            subtitleWizPage.Hide();
            encodingOnly.Hide();
            encodingWizPage.Hide();
            metadataOnly.Hide();
            metadataWizPage.Hide();
            statusPage.Hide();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions optionsForm = new frmOptions();
            optionsForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frontPage.Hide();
            encodingWizPage.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.encodeFileInput = encodeFileInput.Text;
            Properties.Settings.Default.Save();
            encodingWizPage.Hide();
            subtitleWizPage.Show();            
        }

        private void appleTV2Preset_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.encodePreset = "HQ";
        }

        private void iPadPreset_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.encodePreset = "MQ";
        }

        private void iPhone4Preset_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.encodePreset = "LQ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.Filter = "All files (*.*)|*.*";
            fileDialog1.FilterIndex = 1;
            fileDialog1.RestoreDirectory = true;
            fileDialog1.Title = "Select a media file to convert...";
            if (fileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                encodeFileInput.Text = fileDialog1.FileName;
                Properties.Settings.Default.encodeFileInput = fileDialog1.FileName;
                tempFile = Path.ChangeExtension(fileDialog1.FileName, ".mp4");
                Properties.Settings.Default.encodeFileOutput = tempFile;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            subtitleWizPage.Hide();
            metadataWizPage.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog2 = new OpenFileDialog();
            fileDialog2.Filter = "SRT Subtitles (*.srt)|*.srt";
            fileDialog2.FilterIndex = 1;
            fileDialog2.RestoreDirectory = true;
            fileDialog2.Title = "Select a subtitle file to add...";
            if (fileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                subtitleFile.Text = fileDialog2.FileName;
                Properties.Settings.Default.subtitleInput = fileDialog2.FileName;
                tempFile = Path.ChangeExtension(fileDialog2.FileName, ".ttxt");
                Properties.Settings.Default.subtitleOutput = tempFile;
                System.Diagnostics.Process.Start(fileDialog2.FileName);
            }
        }

        private void subtitleLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (subtitleLang.SelectedText)
            {
                case "English":
                    Properties.Settings.Default.subtitleLang = "|lang=en";
                    break;
                case "Chinese (Simplified)":
                    Properties.Settings.Default.subtitleLang = "|lang=zh";
                    break;
                case "Chinese (Traditional)":
                    Properties.Settings.Default.subtitleLang = "|lang=zh";
                    break;
                case "Japanese":
                    Properties.Settings.Default.subtitleLang = "|lang=ja";
                    break;
                case "Korean":
                    Properties.Settings.Default.subtitleLang = "|lang=ko";
                    break;
                default:
                    Properties.Settings.Default.subtitleLang = "";
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            subtitleWizPage.Hide();
            metadataWizPage.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            metadataCopyright.Text = metadataCopyright.Text + button9.Text;
            metadataCopyright.Focus();
            metadataCopyright.SelectionStart = metadataCopyright.SelectionLength + 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            metadataCopyright.Text = metadataCopyright.Text + button10.Text;
            metadataCopyright.Focus();
            metadataCopyright.SelectionStart = metadataCopyright.SelectionLength + 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            metadataCopyright.Text = metadataCopyright.Text + button11.Text;
            metadataCopyright.Focus();
            metadataCopyright.SelectionStart = metadataCopyright.SelectionLength + 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.Filter = "JPG or PNG Image (*.jpg;*.png)|*.jpg;*.png";
            fileDialog1.FilterIndex = 1;
            fileDialog1.RestoreDirectory = true;
            fileDialog1.Title = "Select a cover image for the movie...";
            if (fileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Properties.Settings.Default.metadataArtwork = fileDialog1.FileName;
                artworkBox.ImageLocation = fileDialog1.FileName;
                artworkBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.metadataHD = "false";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.metadataHD = "true";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.metadataAdvisory = "clean";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.metadataAdvisory = "explicit";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.metadataCopyright = metadataCopyright.Text;
            Properties.Settings.Default.metadataDescription = metadataDescription.Text;
            Properties.Settings.Default.metadataGenre = metadataGenre.Text;
            Properties.Settings.Default.metadataTitle = metadataTitle.Text;
            Properties.Settings.Default.metadataYear = metadataYear.Text;
            Properties.Settings.Default.Save();
            metadataWizPage.Hide();
            statusPage.Show();
            
            statusText.Text = "Encoding movie in Handbrake for " + Properties.Settings.Default.encodePreset;
            
            //DO THE ENCODING HERE
            ProcessStartInfo startEncoding = new ProcessStartInfo();
            startEncoding.CreateNoWindow = false;
            startEncoding.UseShellExecute = false;
            startEncoding.FileName = Properties.Settings.Default.pathToHandbrake;
            startEncoding.WindowStyle = ProcessWindowStyle.Normal;
            if (Properties.Settings.Default.encodePreset == "HQ")
            {
                startEncoding.Arguments = "-i \"" + Properties.Settings.Default.encodeFileInput + "\" -o \"" + Properties.Settings.Default.encodeFileOutput + "\" -e x264 -f mp4 -q 20 -6 stereo -w 1024";
            }
            
            if (Properties.Settings.Default.encodePreset == "MQ")
            {
                startEncoding.Arguments = "-i \"" + Properties.Settings.Default.encodeFileInput + "\" -o \"" + Properties.Settings.Default.encodeFileOutput + "\" -e x264 -f mp4 -q 22 -6 stereo -w 480";
            }
            
            if (Properties.Settings.Default.encodePreset == "LQ")
            {
                startEncoding.Arguments = "-i \"" + Properties.Settings.Default.encodeFileInput + "\" -o \"" + Properties.Settings.Default.encodeFileOutput + "\" -e x264 -f mp4 -q 24 -6 stereo -w 320";
            }

            if (Properties.Settings.Default.encodePreset == "")
            {
                startEncoding.Arguments = "-i \"" + Properties.Settings.Default.encodeFileInput + "\" -o \"" + Properties.Settings.Default.encodeFileOutput + "\" -e x264 -f mp4 -q 20 -6 stereo -w 1024";
            }

            try
            {
                using (Process exeProcess = Process.Start(startEncoding))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                //ERROR
            }
            
            statusText.Text = "Adding subtitles...";
            statusBar.Value = 25;
            
            //ADD THE SUBTITLES
            ProcessStartInfo startSubbing = new ProcessStartInfo();
            startSubbing.CreateNoWindow = false;
            startSubbing.UseShellExecute = false;
            startSubbing.FileName = Properties.Settings.Default.pathToMP4Box;
            startSubbing.WindowStyle = ProcessWindowStyle.Normal;
            startSubbing.Arguments = "-add \"" + Properties.Settings.Default.subtitleInput +"\""+ Properties.Settings.Default.subtitleLang + " " +Properties.Settings.Default.encodeFileOutput + " -iPod";
            try
            {
                using (Process exeProcess2 = Process.Start(startSubbing))
                {
                    exeProcess2.WaitForExit();
                }
            }
            catch
            {
                //ERROR
            }
            
            statusText.Text = "Making subtitles compatible...";
            statusBar.Value = 50;
            
            //PATCH THE HEX
            // NEED TO FIGURE THIS PART OUT...
            // No need with MP4Box -iPod switch!

            statusText.Text = "Processing metadata...";
            statusBar.Value = 75;
            
            //ADD THE METADATA
            ProcessStartInfo startMetadata = new ProcessStartInfo();
            startMetadata.CreateNoWindow = false;
            startMetadata.UseShellExecute = false;
            startMetadata.FileName = Properties.Settings.Default.pathToAtomicParsley;
            startMetadata.WindowStyle = ProcessWindowStyle.Normal;
            startMetadata.Arguments = "\"" + Properties.Settings.Default.encodeFileOutput;
            startMetadata.Arguments += "\" --artist \"" + Properties.Settings.Default.metadataArtist;
            startMetadata.Arguments += "\" --artwork \"" + Properties.Settings.Default.metadataArtwork;
            startMetadata.Arguments += "\" --copyright \"" + Properties.Settings.Default.metadataCopyright;
            startMetadata.Arguments += "\" --longdesc \"" + Properties.Settings.Default.metadataDescription;
            // DO A TRIM FOR --description
            string shortDesc;
            shortDesc = Properties.Settings.Default.metadataDescription.Substring(0, 250);
            startMetadata.Arguments += "\" --description \"" + shortDesc;
            startMetadata.Arguments += "\" --genre \"" + Properties.Settings.Default.metadataGenre;
            startMetadata.Arguments += "\" " + Properties.Settings.Default.metadataRating + " ";
            startMetadata.Arguments += "--title \"" + Properties.Settings.Default.metadataTitle;
            startMetadata.Arguments += "\" --year \"" + Properties.Settings.Default.metadataYear;
            startMetadata.Arguments += "\" ";
            startMetadata.Arguments += "--stik \"Movie\" --purchaseDate timestamp --encodingTool \"Pachi System STFGUI\" --encodedBy \"Pachi Systems STFGUI\" --overWrite";
            try
            {
                using (Process exeProcess3 = Process.Start(startMetadata))
                {
                    exeProcess3.WaitForExit();
                }
            }
            catch
            {

            }
            statusText.Text = "Task finished.";
            statusBar.Value = 100;

            //OPEN FILE LOCATION
            Process.Start(Path.GetDirectoryName(Properties.Settings.Default.encodeFileOutput));
            File.Move(@Properties.Settings.Default.encodeFileOutput, @Path.ChangeExtension(Properties.Settings.Default.encodeFileOutput, "m4v"));
        }

        private void metadataRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metadataRating.SelectedItem.ToString())
            {
                case "Unrated (United States)":
                    Properties.Settings.Default.metadataRating = "--contentRating \"Unrated\"";
                    break;
                case "NC-17 (United States)":
                    Properties.Settings.Default.metadataRating = "--contentRating \"NC-17\"";
                    break;
                case "R (United States)":
                    Properties.Settings.Default.metadataRating = "--contentRating \"R\"";
                    break;
                case "PG-13 (United States)":
                    Properties.Settings.Default.metadataRating = "--contentRating \"PG-13\"";
                    break;
                case "PG (United States)":
                    Properties.Settings.Default.metadataRating = "--contentRating \"PG\"";
                    break;
                case "G (United States)":
                    Properties.Settings.Default.metadataRating = "--contentRating \"G\"";
                    break;
                case "R (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|R\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "R18 (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|R18\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "18 (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|18\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "15 (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|15\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "12 (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|12\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "12A (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|12A\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "PG (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|PG\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "U (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|U\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                case "E (Great Britain)":
                    Properties.Settings.Default.metadataRating = "--rDNSatom \"uk-movie|E\" name=iTunEXTC domain=com.apple.iTunes";
                    break;
                default:
                    Properties.Settings.Default.metadataRating = "";
                    break;
            }
        }

    }
}
