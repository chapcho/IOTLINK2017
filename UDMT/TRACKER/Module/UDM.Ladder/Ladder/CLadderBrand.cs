using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public class CLadderBrand
    {
        private MELSECCoil m_coilMELSEC = new MELSECCoil();
        private MELSECContact m_contactMELSEC = new MELSECContact();

        private CommonCoil m_coilCommon = new CommonCoil();
        private CommonContact m_contactCommon = new CommonContact();

        private CommonFuntionBlock m_FBcommon = new CommonFuntionBlock();


#if USE_AB
        private ABCoil m_coilAB= new ABCoil();
        private ABContact m_contactAB = new ABContact();
#endif
        
        private DateTime m_dtCoil = DateTime.MinValue;
        private DateTime m_dtContact = DateTime.MinValue;

        private bool m_bCoilValue = false;
        private bool m_bContactValue = false;

        private CCoil m_cCoil = null;
        private CContact m_cContact = null;
        private CFB_Info m_cFBInfo = null;
        
        private string m_sDateFormat = "";

        private EditorBrand m_eBrand = EditorBrand.MELSEC;

        private Pen m_pen = new Pen(Color.Black);

        private int m_nColumnOccupied = 1;

        private bool m_bUpdate = true;

        public EditorBrand Brand { get { return m_eBrand; } set { m_eBrand = value; Update(); } }
        public CCoil Coil { set { m_cCoil = value; Update(); } }
        public CContact Contact { set { m_cContact = value; Update(); } }
        public CFB_Info FBInfo { get { return m_cFBInfo; } set { m_cFBInfo = value; Update(); } }
        public bool CoilValue { set { m_bCoilValue = value; Update(); } }
        public bool ContactValue { set { m_bContactValue = value; Update(); } }
        public DateTime CoilDate { set { m_dtCoil= value; Update(); } }
        public DateTime ContactDate { set { m_dtContact = value; Update(); } }
        public string DateFormat { set { m_sDateFormat = value; Update(); } }
        public Pen Pen { set { m_pen = value; Update(); } }

        private void UpdateMELSEC()
        {
            // Coil
            m_coilMELSEC.Coil = m_cCoil;
            m_coilMELSEC.Value = m_bCoilValue;
            m_coilMELSEC.DateFormat = m_sDateFormat;
            m_coilMELSEC.Date = m_dtCoil;
            m_coilMELSEC.Pen = m_pen;

            // Contact
            m_contactMELSEC.Contact = m_cContact;
            m_contactMELSEC.Value = m_bContactValue;
            m_contactMELSEC.DateFormat = m_sDateFormat;
            m_contactMELSEC.Date = m_dtContact;
            m_contactMELSEC.Pen = m_pen;
            //m_contactMELSEC.FB_Info = m_cFBInfo;

            //FB
            m_FBcommon.FB_Info = m_cFBInfo;
            m_FBcommon.Pen = m_pen;
            m_FBcommon.Value = false;
            m_FBcommon.DateFormat = m_sDateFormat;
        }

        private void UpdateCommon()
        {
            // Coil
            m_coilCommon.Coil = m_cCoil;
            m_coilCommon.Value = m_bCoilValue;
            m_coilCommon.DateFormat = m_sDateFormat;
            m_coilCommon.Date = m_dtCoil;
            m_coilCommon.Pen = m_pen;

            // Contact
            m_contactCommon.Contact = m_cContact;
            m_contactCommon.Value = m_bContactValue;
            m_contactCommon.DateFormat = m_sDateFormat;
            m_contactCommon.Date = m_dtContact;
            m_contactCommon.Pen = m_pen;

            //FB
            m_FBcommon.FB_Info = m_cFBInfo;
            m_FBcommon.Pen = m_pen;
            m_FBcommon.Value = false;
            m_FBcommon.DateFormat = m_sDateFormat;
        }
        

#if USE_AB
        private void UpdateAB()
        {
            // Coil
            m_coilAB.Coil = m_cCoil;
            m_coilAB.Value = m_bCoilValue;
            m_coilAB.DateFormat = m_sDateFormat;
            m_coilAB.Date = m_dtCoil;
            m_coilAB.Pen = m_pen;

            // Contact
            m_contactAB.Contact = m_cContact;
            m_contactAB.Value = m_bContactValue;
            m_contactAB.DateFormat = m_sDateFormat;
            m_contactAB.Date = m_dtContact;
            m_contactAB.Pen = m_pen;
        }
#endif

        private void Update()
        {
            if (!m_bUpdate) { return; }

            switch (m_eBrand)
            {
                case EditorBrand.MELSEC: UpdateMELSEC(); return;
                case EditorBrand.AB: 
#if USE_AB
                    UpdateAB(); 
#endif
                case EditorBrand.Common: UpdateCommon(); return;

                    return;
            }
        }

        public void HoldUpdate() { m_bUpdate = false; }
        public void NowUpdate() { m_bUpdate = true; Update(); }

        public CLadderItem GetCoilLadderItem()
        {
            switch (m_eBrand)
            {
                case EditorBrand.MELSEC: return m_coilMELSEC as CLadderItem;
                case EditorBrand.Common: return m_coilCommon as CLadderItem;
                case EditorBrand.AB:
                    CLadderItem cLadderItem = null;
#if USE_AB
                    cLadderItem = m_coilAB as CLadderItem;

#endif
                    return cLadderItem;
            }

            return null;
        }

        public CLadderItem GetContactLadderItem()
        {
            switch (m_eBrand)
            {
                case EditorBrand.MELSEC: return m_contactMELSEC as CLadderItem;
                case EditorBrand.Common: return m_contactCommon as CLadderItem;
                case EditorBrand.AB:
                    CLadderItem cLadderItem = null;
#if USE_AB
                    cLadderItem = m_contactAB as CLadderItem;
#endif


                    return cLadderItem;
            }

            return null;
        }

        public CLadderItem GetFBLadderItem()
        {
            switch (m_eBrand)
            {
                case EditorBrand.MELSEC: return m_FBcommon as CLadderItem;
                case EditorBrand.Common: return m_FBcommon as CLadderItem;
                case EditorBrand.AB:
                    CLadderItem cLadderItem = null;
#if USE_AB
                    cLadderItem = m_contactAB as CLadderItem;
#endif


                    return cLadderItem;
            }

            return null;
        }
    }
}
