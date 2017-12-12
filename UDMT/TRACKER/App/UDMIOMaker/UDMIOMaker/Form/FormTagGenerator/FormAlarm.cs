namespace NewIOMaker.Form.FormTagGenerator
{
    public partial class FormAlarm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        TagGrid _tagGrid;

        public FormAlarm(TagGrid tagGrid)
        {
            InitializeComponent();
            _tagGrid = tagGrid;
        }
    }
}