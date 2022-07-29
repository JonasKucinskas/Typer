using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer
{
    internal class files
    {
        public static List<string> ReturnFileList(string path)
        {
            List<string> fileNames = Directory.EnumerateFiles(path).Select(p => System.IO.Path.GetFileNameWithoutExtension(p)).ToList();

            return fileNames;
        }

        public static void PlaySoundFile(string path)
        {
            WaveOutEvent outputDevice = new WaveOutEvent();
            AudioFileReader audioFile = new AudioFileReader(path);
            outputDevice.Init(audioFile);
            outputDevice.Play();
            
        }

        public static void StopSound(WaveOutEvent outputDevice)
        {
            outputDevice.Stop();
        }
    }
}
