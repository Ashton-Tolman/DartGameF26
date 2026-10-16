namespace DartGameF26
{
    public partial class DartGameForm : Form
    {
        public DartGameForm()
        {
            InitializeComponent();
            this.KeyDown += DartGameForm_KeyDown;
         
        }








        //Event Handlers Below---------------------------------------------------------------------
        private void DartGameForm_KeyDown(object? sender, KeyEventArgs e)
        {

        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewRoundButton_Click(object sender, EventArgs e)
        {

        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {

        }
    }
}
