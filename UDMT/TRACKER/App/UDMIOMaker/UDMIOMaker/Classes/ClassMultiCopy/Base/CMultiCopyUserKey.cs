using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.ClassMultiCopy
{
    public partial class CMultiCopyUserKey
    {

        protected string[] _Alphabet;
        protected string[] _Number;
        protected string[] _Funtion;
        protected string[] _Math;


        #region Initialize/Dispose

        public CMultiCopyUserKey()
        {
            string Alphabet = "A_B_C_D_E_F_G_H_I_J_K_L_M_N_O_P_Q_R_S_T_U_V_W_X_Y_Z";
            string Number = "1_2_3_4_5_6_7_8_9_0_F1_F2_F3_F4_F5_F6_F7_F8_F9_F10_F11_F12";
            string Math = "ADD_SUBTRACT_MULTIPLY_DIVIDE";
            string Funtion = "PrintScreen_INSERT_HOME_PageUP_DELETE_END_PageDown_TAB_CAPSLOCK_ENTER";

            MulciCopyKeyGenerator(Alphabet, Number, Math, Funtion);
        }

        #endregion

        #region Public Properites

        public string[] Alphabet
        {
            get { return _Alphabet; }
            set { _Alphabet = value; }
        }

        public string[] Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public string[] Funtion
        {
            get { return _Funtion; }
            set { _Funtion = value; }
        }

        public string[] Math
        {
            get { return _Math; }
            set { _Math = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Mehtods

        private void MulciCopyKeyGenerator(string Alphabet, string Number, string Math, string Funtion)
        {
            _Alphabet = Alphabet.Split('_');
            _Number = Number.Split('_');
            _Math = Math.Split('_');
            _Funtion = Funtion.Split('_');

        }

        #endregion
    }
}
