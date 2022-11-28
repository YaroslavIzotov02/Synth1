using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace Synth_1
{
    /// <summary>
    /// 
    /// </summary>
    public enum WaveType
    {
        Sine,
        Square,
        Saw,
        Triangle,
        Noise
    }

    /// <summary>
    /// 
    /// </summary>
    public delegate short Out();


    /// <summary>
    /// 
    /// </summary>
    public class Generator
    {

        #region Aggregations


        #endregion

        #region Compositions


        #endregion

        #region Attributes
        /// <summary>
        /// 
        /// </summary>
        Dictionary<WaveType, Out> dic;

        /// <summary>
        /// 
        /// </summary>
        WaveType waveType;

        /// <summary>
        /// 
        /// </summary>
        private double Frequency;

        /// <summary>
        /// 
        /// </summary>
        private short Amplitude;  

        /// <summary>
        /// 
        /// </summary>
        private short Velocity;

        private double phaseAngle = 0;

        #endregion


        #region Public methods

        public Generator()
        {
            dic = new Dictionary<WaveType, Out>()
            {
                {WaveType.Sine, Sine},
                {WaveType.Saw, Saw},
                {WaveType.Square, Square},
                {WaveType.Triangle, Triangle},
                {WaveType.Noise, Noise}
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WaveType"></param>
        /// <returns></returns>
        public void SetWave(WaveType waveTypeIn)
        {
            waveType = waveTypeIn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Freq"></param>
        /// <returns></returns>
        public void SetFreq(double Freq)
        {
            Frequency = Freq;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Amp"></param>
        /// <returns></returns>
        public void SetAmplitude(short Amp)
        {
            Amplitude = Amp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>short int</returns>
        public short GetOut()
        {
            return dic[waveType]();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Velocity"></param>
        /// <returns></returns>
        public void SetVelocity(short Vel)
        {
            Velocity = Vel;
        }

        #endregion


        #region Protected methods

        #endregion


        #region Private methods
        private short Sine()
        {
            if (phaseAngle > 2 * Math.PI)
                phaseAngle -= 2 * Math.PI;

            phaseAngle += 2 * Math.PI * Frequency / 44100;

            return (short)(Amplitude * Math.Sin(phaseAngle));
        }

        private short Saw()
        {
            if (phaseAngle > 2 * Math.PI)
                phaseAngle -= 2 * Math.PI;

            phaseAngle += 2 * Math.PI * Frequency / 44100;

            return (short)(2 * Amplitude * Math.Asin(Math.Sin(phaseAngle)) / Math.PI);
        }

        private short Square()
        {
            if (phaseAngle > 2 * Math.PI)
                phaseAngle -= 2 * Math.PI;

            phaseAngle += 2 * Math.PI * Frequency / 44100;

            return (short)(Amplitude * Math.Sign(Math.Sin(phaseAngle)));
        }

        private short Triangle()
        {
            if (phaseAngle > 2 * Math.PI)
                phaseAngle -= 2 * Math.PI;

            phaseAngle += 2 * Math.PI * Frequency / 44100;

            return (short)(2 * Amplitude * (Math.PI / (2 - Math.Atan(Math.Tan(phaseAngle)))) / Math.PI);
        }

        private short Noise()
        {
            if (phaseAngle > 2 * Math.PI)
                phaseAngle -= 2 * Math.PI;

            phaseAngle += 2 * Math.PI * Frequency / 44100;

            return (short)(Amplitude * (short)new Random().Next());
        }
        #endregion
    }
}
