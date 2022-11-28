using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace Synth_1
{
    /// <summary>
    /// 
    /// </summary>
    public class Carrier : Generator
    {

        #region Aggregations


        #endregion

        #region Compositions


        #endregion

        #region Attributes

        /// <summary>
        /// 
        /// </summary>
        private Modulator modulator;



        #endregion


        #region Public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Time"></param>
        /// <returns>short int</returns>
        public short[] GetOut(int Time)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modulator"></param>
        /// <returns></returns>
        public void SetModulator(Modulator modulator)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion


        #region Protected methods

        #endregion


        #region Private methods

        #endregion


    }
}
