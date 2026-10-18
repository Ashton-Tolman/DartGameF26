namespace DartGameF26
{
    public partial class DartGameForm : Form
    {
        public DartGameForm()
        {
            InitializeComponent();
            DartPictureBox.Paint += DartPictureBox_Paint;

            //Startup label conditions 
            RoundLabel.Text = "Round: -";
            ThrowLabel.Text = "Darts: 0 / 3";
            ModeLabel.Text = "Mode: Play";

        }
        Point[] dartPositions = new Point[3];
        List<string> savedRounds = new List<string>();
        int roundNumber = 0;
        int throwCount = 0;
        bool reviewMode = false;
        bool roundStarted = false;

        // One Random for the whole program
        Random randy = new Random();

        //Filepath for Dartboard
        private Image theImage = Image.FromFile("..\\..\\..\\DartBoard.png");

        //Filepath for log page
        string logFile = Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", "..", "DartGame.log"));

        // Returns a random number between min and max, inclusive
        int GetNumberFrom(int max, int min = 0)
        {
            return randy.Next(min, max + 1);
        }

        // Draws one dart: a circle with a center mark
        void DrawDart(Graphics g, int x, int y)
        {
            Pen thePen = new Pen(Color.Green, 2);
            int size = 10;

            g.DrawEllipse(thePen, x - size / 2, y - size / 2, size, size);
            g.DrawLine(thePen, x - 10, y, x + 10, y);
            g.DrawLine(thePen, x, y - 10, x, y + 10);

            thePen.Dispose();
        }


        private void DartPictureBox_Paint(object? sender, PaintEventArgs e)
        {
            DrawDartBoard(e.Graphics);

            for (int i = 0; i < throwCount; i++)
            {
                int x = dartPositions[i].X;
                int y = dartPositions[i].Y;
                x = Math.Max(10, Math.Min(x, DartPictureBox.Width));
                y = Math.Max(10, Math.Min(y, DartPictureBox.Height));
                DrawDart(e.Graphics, x, y);
            }
        }

        void DrawDartBoard(Graphics g)
        {
            Rectangle bounds = new Rectangle(0, 0, 600, 600);
            g.DrawImage(theImage, bounds);

        }
        // Throws a dart at a random position on the PictureBox
        void ThrowDart()
        { 

            // Save again if the previous save failed
            if (throwCount == 3)
            {
                SaveRound();
                return;
            }

            int x = GetNumberFrom(DartPictureBox.ClientSize.Width - 1,1);
            int y = GetNumberFrom(DartPictureBox.ClientSize.Height - 1, 1);
            dartPositions[throwCount] = new Point(x, y);
            throwCount++;
            ThrowLabel.Text = $"Darts: {throwCount} / 3";
            DartPictureBox.Refresh();

            if (throwCount == 3)
            {
                SaveRound();
            }
        }
        

        // Puts everything into Play mode and clears the PictureBox
        void ThrowMode()
        {
            reviewMode = false;
            roundStarted = false;
            throwCount = 0;

            RoundListBox.Visible = false;
            ModeLabel.Text = "Mode: Play";
            ReviewButton.Text = "&Review";
            RoundLabel.Text = "Round: -";
            ThrowLabel.Text = "Darts: 0 / 3";

            DartPictureBox.Invalidate();
        }

        // Puts everything into Review mode and clears the PictureBox
        void ReviewMode()
        {
            reviewMode = true;
            roundStarted = false;
            throwCount = 0;

            RoundListBox.Visible = true;
            ModeLabel.Text = "Mode: Review";
            ReviewButton.Text = "&Back to Play";
            RoundLabel.Text = "Round: -";
            ThrowLabel.Text = "Darts: 0 / 3";

            LoadRounds();
            DartPictureBox.Invalidate();
        }

        // Loads all saved rounds from the log file into the ListBox
        void LoadRounds()
        {
            savedRounds.Clear();
            RoundListBox.Items.Clear();

            try
            {
                if (!File.Exists(logFile))
                {
                    File.WriteAllText(logFile, "");
                }

                string[] lines = File.ReadAllLines(logFile);
                List<int> roundNumbers = new List<int>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 7)
                    {
                        int[] numbers = new int[7];
                        bool valid = true;

                        for (int i = 0; i < 7; i++)
                        {
                            if (!int.TryParse(parts[i], out numbers[i]) || numbers[i] < 0)
                            {
                                valid = false;
                                break;
                            }
                        }

                        int roundNum = numbers[0];
                        if (valid && roundNum != 0 && !roundNumbers.Contains(roundNum))
                        {
                            roundNumbers.Add(roundNum);
                            savedRounds.Add(line);
                            RoundListBox.Items.Add($"Round {roundNum}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rounds: " + ex.Message);
            }
        }

        // Saves the current round to the log file
        void SaveRound()
        {
            if (throwCount != 3 || !roundStarted)
            {
                return;
            }

            string roundData = $"{roundNumber}";

            for (int i = 0; i < 3; i++)
            {
                roundData += $",{dartPositions[i].X},{dartPositions[i].Y}";
            }

            try
            {
                // Check that the round number has not been saved
                if (roundNumber < GetNextRound())
                {
                    MessageBox.Show("This round is already saved.");
                    roundStarted = false;
                    return;
                }

                File.AppendAllText(logFile, roundData + Environment.NewLine);

                roundStarted = false;

                MessageBox.Show($"Round {roundNumber} saved. Start a new round to keep playing.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving round: " + ex.Message +
                    "\nPress Spacebar to try saving again.");
            }
        }

        int GetNextRound()
        {
            int lastRound = 0;

            if (!File.Exists(logFile))
            {
                File.WriteAllText(logFile, "");
            }

            string[] lines = File.ReadAllLines(logFile);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 7)
                {
                    int savedNumber;

                    if (int.TryParse(parts[0], out savedNumber))
                    {
                        if (savedNumber > lastRound)
                        {
                            lastRound = savedNumber;
                        }
                    }
                }
            }

            return lastRound + 1;
        }


        //Event Handlers Below---------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                if (roundStarted)
                {
                    ThrowDart();
                }
                else
                {
                    MessageBox.Show("Start new round to throw a dart!");
                }

                return true;   // true = consumed, no control sees it
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewRoundButton_Click(object sender, EventArgs e)
        {
            // Leave Review mode first so the two modes never mix
            if (reviewMode)
            {
                ThrowMode();
            }

            if (!roundStarted)
            {
                try
                {
                    roundNumber = GetNextRound();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while starting the round: " + ex.Message);
                    return;
                }

                throwCount = 0;
                roundStarted = true;

                RoundLabel.Text = $"Round: {roundNumber}";
                ThrowLabel.Text = $"Darts: {throwCount} / 3";
                ModeLabel.Text = "Mode: Play";

                // Clears the old darts
                DartPictureBox.Invalidate();

                // Prevent focused buttons from receiving Spacebar
                this.ActiveControl = null;
            }
            else
            {
                MessageBox.Show("Finish the current round first.");
            }
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            if (roundStarted)
            {
                DialogResult result = MessageBox.Show(
                    "Discard the current round?",
                    "Confirm",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            if (reviewMode)
            {
                ThrowMode();
            }
            else
            {
                ReviewMode();
            }
        }

        private void RoundListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string roundData = savedRounds[RoundListBox.SelectedIndex];
                string[] parts = roundData.Split(',');

                roundNumber = int.Parse(parts[0]);

                for (int i = 0; i < 3; i++)
                {
                    int x = int.Parse(parts[i * 2 + 1]);
                    int y = int.Parse(parts[i * 2 + 2]);

                    dartPositions[i] = new Point(x, y);
                }

                throwCount = 3;

                RoundLabel.Text = $"Round: {roundNumber}";
                ThrowLabel.Text = "Darts: 3 / 3";

                DartPictureBox.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not show that round: " + ex.Message);
            }
        }
    }
}
