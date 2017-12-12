using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public class CLogicStep
    {
        #region Member Variables

        private string _sCommand = "";
        private EMLadderBlockTpye _emBlockType = EMLadderBlockTpye.NONE;
        private List<CLogicBaseBlock> _lstLogicBlock = new List<CLogicBaseBlock>();
        private string _sStepString = "";
        private List<string> _lstData = new List<string>();
        private int _iStepNumber = 0;

        #endregion


        #region Properties

        public int StepIndexCount
        {
            get { return _lstLogicBlock.Count; }
        }

        public int StepNumber
        {
            get { return _iStepNumber; }
            set { _iStepNumber = value; }
        }

        public List<CLogicBaseBlock> BlockList
        {
            get { return _lstLogicBlock; }
            set { _lstLogicBlock = value; }
        }

        public string CommandString
        {
            get { return _sCommand; }
            set { _sCommand = value; }
        }

        public string StepString
        {
            get { return _sStepString; }
            set { _sStepString = value; }
        }

        public EMLadderBlockTpye StepType
        {
            get { return _emBlockType; }
            set { _emBlockType = value; }
        }

        #endregion



        #region Public Method

        public void MixAddress()
        {

        }
        
        public void CreateStepString()
        {
            if (_lstLogicBlock.Count == 0)
                return;

            if (_lstLogicBlock[0].BlockType == EMLadderBlockTpye.NONE)
                return;

            if (_lstLogicBlock[0].BlockType == EMLadderBlockTpye.COMMAND)
            {
                //체크 (인자 갯수가 맞는지...)

                string sFirst = "";
                string sSecond = "";
                string sThird = "";
                string s4Th = "";

                if (_iStepNumber == 650)
                {
                    int a = 0;
                }

                if (_lstLogicBlock.Count != _lstLogicBlock[0].FactorCount + 1)
                {
                    if (_lstLogicBlock[0].FactorCount == 1)
                    {
                        if (_lstLogicBlock.Count == 3)
                        {
                            string sBase = "";
                            if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.DOT && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT)
                                sBase = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                            else if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT)
                                sBase = _lstLogicBlock[1].ResultString + _lstLogicBlock[2].ResultString;
                            else if (_lstLogicBlock[1].ResultString.Contains("Z"))
                                sBase = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                            _sStepString = string.Format("{0},{1},,,,,", _lstLogicBlock[0].ResultString, sBase);
                        }
                        else
                        {
                            int a = 0;
                        }
                    }
                    else if (_lstLogicBlock[0].FactorCount == 2)
                    {
                        if (_lstLogicBlock.Count == 4)
                        {
                            if (_lstLogicBlock[1].ResultString.Contains("Z") && _lstLogicBlock[1].ResultString.Contains("ZR") == false &&
                                _lstLogicBlock[2].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[3].ResultString;
                            }
                            else if (_lstLogicBlock[2].ResultString.Contains("Z") && _lstLogicBlock[2].ResultString.Contains("ZR") == false &&
                                _lstLogicBlock[1].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[3].BlockType == EMLadderBlockTpye.OTHER)
                            {
                                sFirst = _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[3].ResultString + _lstLogicBlock[2].ResultString;
                            }
                            else
                            {
                                if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT)
                                    sFirst = _lstLogicBlock[1].ResultString + _lstLogicBlock[2].ResultString;
                                else
                                    sFirst = _lstLogicBlock[1].ResultString;
                                if (_lstLogicBlock[2].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT)
                                    sSecond = _lstLogicBlock[2].ResultString + _lstLogicBlock[3].ResultString;
                                else
                                    sSecond = _lstLogicBlock[3].ResultString;
                            }
                            _sStepString = string.Format("{0},{1},,,,,\r{2},,,,,", _lstLogicBlock[0].ResultString, sFirst, sSecond);
                        }
                        else if (_lstLogicBlock.Count == 5)
                        {
                            if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT &&
                                _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;
                            }
                            else if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT &&
                                _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[1].ResultString + _lstLogicBlock[2].ResultString;
                                sSecond = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;
                            }
                            else if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT &&
                                _lstLogicBlock[3].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[3].ResultString + _lstLogicBlock[4].ResultString;
                            }
                            else if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.OTHER &&
                                _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;
                            }
                            else if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT &&
                                _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.OTHER)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;
                            }
                            else if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.OTHER &&
                                _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.OTHER)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;
                            }
                            else
                            {
                                if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT)
                                    sFirst = _lstLogicBlock[1].ResultString + _lstLogicBlock[2].ResultString;
                                if (_lstLogicBlock[3].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT)
                                    sSecond = _lstLogicBlock[3].ResultString + _lstLogicBlock[4].ResultString;
                            }
                            _sStepString = string.Format("{0},{1},,,,,\r{2},,,,,", _lstLogicBlock[0].ResultString, sFirst, sSecond);
                        }
                        else if (_lstLogicBlock.Count == 6)
                        {
                            if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT &&_lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT &&
                                _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[5].BlockType == EMLadderBlockTpye.CONTACT )
                            {
                                sFirst = _lstLogicBlock[1].ResultString + _lstLogicBlock[3].ResultString + _lstLogicBlock[2].ResultString;
                                sSecond = _lstLogicBlock[5].ResultString + _lstLogicBlock[4].ResultString;
                            }
                            else if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT &&
                                _lstLogicBlock[3].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT && _lstLogicBlock[5].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[3].ResultString + _lstLogicBlock[5].ResultString + _lstLogicBlock[4].ResultString;
                            }
                            _sStepString = string.Format("{0},{1},,,,,\r{2},,,,,", _lstLogicBlock[0].ResultString, sFirst, sSecond);
                        }
                        else
                        {
                            int a = 0;
                        }
                    }
                    else if (_lstLogicBlock[0].FactorCount == 3)
                    {
                        
                        if (_lstLogicBlock.Count == 5)
                        {
                            if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[1].ResultString + _lstLogicBlock[2].ResultString;
                                sSecond = _lstLogicBlock[3].ResultString;
                                sThird = _lstLogicBlock[4].ResultString;
                            }
                            else if (_lstLogicBlock[2].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT)
                            {
                                sFirst = _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[2].ResultString + _lstLogicBlock[3].ResultString;
                                sThird = _lstLogicBlock[4].ResultString;
                            }
                            else
                            {
                                if (_lstLogicBlock[1].ResultString.Contains("Z") && _lstLogicBlock[1].ResultString.Contains("ZR") == false)
                                {
                                    sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                    sSecond = _lstLogicBlock[3].ResultString;
                                    sThird = _lstLogicBlock[4].ResultString;
                                }
                                else if (_lstLogicBlock[2].ResultString.Contains("Z") && _lstLogicBlock[2].ResultString.Contains("ZR") == false)
                                {
                                    sFirst = _lstLogicBlock[1].ResultString;
                                    sSecond = _lstLogicBlock[3].ResultString + _lstLogicBlock[2].ResultString;
                                    sThird = _lstLogicBlock[4].ResultString;
                                }
                                else if (_lstLogicBlock[3].ResultString.Contains("Z") && _lstLogicBlock[3].ResultString.Contains("ZR") == false)
                                {
                                    sFirst = _lstLogicBlock[1].ResultString;
                                    sSecond = _lstLogicBlock[2].ResultString;
                                    sThird = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;
                                }
                                else
                                {
                                    int a = 0;
                                }
                            }
                        }
                        else if (_lstLogicBlock.Count == 6)
                        {
                            if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT)
                                sFirst = _lstLogicBlock[1].ResultString + _lstLogicBlock[2].ResultString;
                            else if (_lstLogicBlock[1].ResultString.Contains("Z") && _lstLogicBlock[1].ResultString.Contains("ZR") == false)
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                            else
                                sFirst = _lstLogicBlock[1].ResultString;

                            if(_lstLogicBlock[3].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[4].BlockType == EMLadderBlockTpye.CONTACT)
                                sSecond = _lstLogicBlock[3].ResultString + _lstLogicBlock[4].ResultString;
                            else if (_lstLogicBlock[3].ResultString.Contains("Z") && _lstLogicBlock[3].ResultString.Contains("ZR") == false)
                                sSecond = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;

                            sThird = _lstLogicBlock[5].ResultString;
                        }
                        else
                        {
                            int a = 0;
                        }
                        _sStepString = string.Format("{0},{1},,,,,\r{2},,,,,\r{3},,,,,", _lstLogicBlock[0].ResultString, sFirst, sSecond, sThird);
                    }
                    else if (_lstLogicBlock[0].FactorCount == 4)
                    {
                        if (_lstLogicBlock.Count == 6)
                        {
                            if (_lstLogicBlock[1].ResultString.Contains("Z") && _lstLogicBlock[1].ResultString.Contains("ZR") == false)
                            {
                                sFirst = _lstLogicBlock[2].ResultString + _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[3].ResultString;
                                sThird = _lstLogicBlock[4].ResultString;
                                s4Th = _lstLogicBlock[5].ResultString;
                            }
                            else if (_lstLogicBlock[2].ResultString.Contains("Z") && _lstLogicBlock[2].ResultString.Contains("ZR") == false)
                            {
                                sFirst = _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[3].ResultString + _lstLogicBlock[2].ResultString;
                                sThird = _lstLogicBlock[4].ResultString;
                                s4Th = _lstLogicBlock[5].ResultString;
                            }
                            else if (_lstLogicBlock[3].ResultString.Contains("Z") && _lstLogicBlock[3].ResultString.Contains("ZR") == false)
                            {
                                sFirst = _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[2].ResultString;
                                sThird = _lstLogicBlock[4].ResultString + _lstLogicBlock[3].ResultString;
                                s4Th = _lstLogicBlock[5].ResultString;
                            }
                            else if (_lstLogicBlock[3].ResultString.Contains("Z") && _lstLogicBlock[3].ResultString.Contains("ZR") == false)
                            {
                                sFirst = _lstLogicBlock[1].ResultString;
                                sSecond = _lstLogicBlock[2].ResultString;
                                sThird = _lstLogicBlock[3].ResultString;
                                s4Th = _lstLogicBlock[5].ResultString + _lstLogicBlock[4].ResultString;
                            }
                            else
                            {
                                if (_lstLogicBlock[1].BlockType == EMLadderBlockTpye.OTHER && _lstLogicBlock[2].BlockType == EMLadderBlockTpye.CONTACT &&
                                    _lstLogicBlock[3].BlockType == EMLadderBlockTpye.CONTACT)
                                {
                                    sFirst = _lstLogicBlock[1].ResultString + _lstLogicBlock[2].ResultString;
                                    sSecond = _lstLogicBlock[3].ResultString;
                                    sThird = _lstLogicBlock[4].ResultString;
                                    s4Th = _lstLogicBlock[5].ResultString;
                                }
                            }
                        }
                        else if (_lstLogicBlock.Count == 7)
                        {

                        }
                        else
                        {
                            int a = 0;
                        }
                        _sStepString = string.Format("{0},{1},,,,,\r{2},,,,,\r{3},,,,,\r{4},,,,,", _lstLogicBlock[0].ResultString, sFirst, sSecond, sThird, s4Th);
                    }
                    else
                    {
                        if (_lstLogicBlock[0].FactorCount == 0 && _lstLogicBlock[0].ResultString == "SUB")
                            _sStepString = string.Format("{0},,,,,,,", _lstLogicBlock[1].ResultString);
                        else if (_lstLogicBlock[0].FactorCount == 0)
                            _sStepString = string.Format("{0},,,,,,,", _lstLogicBlock[0].ResultString);
                        else
                        {
                            int a = 0;
                        }
                    }
                }
                else
                {
                    _sStepString = string.Format("{0},", _lstLogicBlock[0].ResultString);
                    if (_lstLogicBlock.Count == 1)
                        _sStepString +=  ",,,,,";
                    else
                    {
                        for (int i = 1; i < _lstLogicBlock.Count; i++)
                            _sStepString += _lstLogicBlock[i].ResultString + ",,,,,\r";
                    }
                }

            }
            else
            {
                //Statement
                if (_lstLogicBlock.Count > 0)
                    _sStepString = string.Format("{0},,{1},,,,,", _iStepNumber, _lstLogicBlock[0].ResultString);
            }
        }

        #endregion
    }
}
