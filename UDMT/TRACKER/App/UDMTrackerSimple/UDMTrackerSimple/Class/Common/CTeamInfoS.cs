using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using UDM.Common;

namespace UDMTrackerSimple
{
    /// <summary>
    /// Key = TeamName
    /// </summary>
    [Serializable]
    public class CTeamInfoS : Dictionary<string, CTeamInfo>
    {
        protected CTeamInfoS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        private CTagS m_cRecipeWordS = new CTagS();
        private CTag m_cSelectRecipeWord = null;

        public CTagS RecipeWordS
        {
            get { return m_cRecipeWordS; }
            set { m_cRecipeWordS = value; }
        }

        public CTag SelectRecipeWord
        {
            get { return m_cSelectRecipeWord; }
            set { m_cSelectRecipeWord = value; }
        }

        public CTeamInfoS()
        {
            
        }

        public CTeamInfo GetTeamInfo(DateTime dtTime)
        {
            CTeamInfo cInfo = null;
            string sHour = dtTime.ToString("HH");

            int iHour = Convert.ToInt16(sHour);//dtTime.Hour;
            int iMinute = dtTime.Minute;

            int iFromHour = 0;
            int iToHour = 0;

            foreach (var who in this)
            {
                //if (who.Value.From.Hour > who.Value.To.Hour && (who.Value.To.Hour >= 0 && who.Value.To.Hour < 12))
                //    iToHour = 24;
                //else
                iFromHour = who.Value.From.Hour;
                iToHour = who.Value.To.Hour;

                
                if (who.Value.From.Hour <= iHour && iToHour > iHour)
                {
                    cInfo = who.Value;
                    break;
                }
                else if (iFromHour > iToHour)
                {
                    cInfo = who.Value;
                    break;
                }
            }

            return cInfo;
        }

    }
}
