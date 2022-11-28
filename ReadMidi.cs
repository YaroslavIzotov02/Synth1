using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Midi;

namespace Synth_1
{
    public class ReadMidi
    {
        MidiIn midiIn;
        public Dictionary<int, string> SelectDevice()
        {
            Dictionary<int, string> devs = new Dictionary<int, string>();
            for (int i = 0; i < MidiIn.NumberOfDevices; i++)
                devs.Add(i, MidiIn.DeviceInfo(i).ProductName);
            return devs;
        }

        public void InvokeMidiIn(int devNum)
        {
            midiIn = new MidiIn(devNum);
            midiIn.MessageReceived += MessageRecived;
            midiIn.Start();
        }

        private void MessageRecived(object sender, MidiInMessageEventArgs e) 
        {
            //Console.WriteLine(e.MidiEvent.CommandCode.ToString() + " " + e.Timestamp + " " + e.RawMessage + e.MidiEvent);

            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
            {
                (double f, int d, int v) = GetNote(e.RawMessage); 
                MainWindow.NoteOn(f, d);
            }
            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOff)
            {
                (double f, int d, int v) = GetNote(e.RawMessage);
                MainWindow.NoteOff(f, d);
            }
        }

        private (double, int, int) GetNote(int rm)
        {
            int data1 = (rm >> 8) & 0xFF;
            int data2 = (rm >> 16) & 0xFF;
            double d = (data1 - 69) / 12.0d;
            double freq = 440 * Math.Pow(2, d);
            int vel = data2;
            if (vel > 127)
            {
                vel = 127;
            }
            return (freq, data1, vel);
        }
    }
}
