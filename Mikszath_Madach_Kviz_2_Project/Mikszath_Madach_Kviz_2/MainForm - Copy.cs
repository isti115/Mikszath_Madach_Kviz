using System;//
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Mikszath_Madach_Kviz_2
{
    public partial class MainForm : Form
    {
        const int HORIZONTAL = 0, VERTICAL = 1;

        static int xCount, yCount;
        static int outerXCount, outerYCount;
        static int xStart, yStart;
        static int xMargin, yMargin;

        static int xAvgSize, yAvgSize;
        static int[] xSizes;
        //static int[] xSize, ySize;

        static string[,] answers;
        string[] horizontal, vertical;

        Bitmap grid_bm = new Bitmap(1, 1);
        Graphics grid_g;
        Pen thin = new Pen(Color.Black, 1);
        Pen thick = new Pen(Color.Black, 3);

        Font borderFont = new Font("Verdana", 17, FontStyle.Bold);

        Timer timer = new Timer();
        Stopwatch stopwatch = new Stopwatch();
        static bool animation_in_progress = false;

        int hintCount = 0, submitCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            #region file_input

            #region settings

            List<Setting> settings = new List<Setting>();

            StreamReader settingsReader = new StreamReader("settings.ini");

            do
            {
                string[] input = settingsReader.ReadLine().Split('=');

                settings.Add(new Setting(input[0], input[1]));
            }
            while (!settingsReader.EndOfStream);


            xCount = (int)ToNumeric(Setting.getValue(settings, "xCount"));
            yCount = (int)ToNumeric(Setting.getValue(settings, "yCount"));

            outerXCount = (int)ToNumeric(Setting.getValue(settings, "outerXCount"));
            outerYCount = (int)ToNumeric(Setting.getValue(settings, "outerYCount"));

            xStart = (int)ToNumeric(Setting.getValue(settings, "xStart"));
            yStart = (int)ToNumeric(Setting.getValue(settings, "yStart"));

            xMargin = (int)ToNumeric(Setting.getValue(settings, "xMargin"));
            yMargin = (int)ToNumeric(Setting.getValue(settings, "yMargin"));


            string[] xSize_splitted = Setting.getValue(settings, "xSizes").Split(',');
            decimal[] xSize_ratios = new decimal[xSize_splitted.Length];

            xAvgSize = this.Width / (xCount + outerXCount);

            decimal xSize_ratios_sum = 0;

            for (int i = 0; i < xSize_splitted.Length; i++)
            {
                xSize_ratios[i] = ToNumeric(xSize_splitted[i]);
                xSize_ratios_sum += xSize_ratios[i];
            }

            xSizes = new int[xSize_ratios.Length];

            for (int i = 0; i < xSize_ratios.Length; i++)
            {
                xSizes[i] = (int)(((decimal)xSize_ratios[i] / (decimal)xSize_ratios_sum) * ((decimal)xAvgSize * (decimal)xCount));
                hintLabel.Text += xSizes[i].ToString();
            }

            yAvgSize = this.Height / (yCount + outerYCount);

            answers = new string[xCount - 1, yCount - 1];

            timer.Interval = 1000;

            #endregion

            #region data

            SkippableStreamReader dataReader = new SkippableStreamReader("data.txt", Encoding.Default);

            headerLabel.Text = dataReader.ReadLine();
            headerLabel.Location = new Point((this.Width - headerLabel.Width) / 2, 10);

            dataReader.SkipLines(1);

            horizontal = dataReader.ReadLine().Split(';');

            dataReader.SkipLines(1);

            vertical = dataReader.ReadLine().Split(';');

            dataReader.SkipLines(1);

            for (int y = 0; y < answers.GetLength(VERTICAL); y++)
            {
                string[] splitted = dataReader.ReadLine().Split(';');

                if (splitted.Length != 3)
                {
                    MessageBox.Show("Hibás adatfile!");
                    Environment.Exit(38);
                }

                for (int x = 0; x < answers.GetLength(HORIZONTAL); x++)
                {
                    answers[x, y] = splitted[x];
                }
            }

            dataReader.Close();

            #endregion

            #endregion

            #region grid

            grid_bm = new Bitmap(xAvgSize * xCount, yAvgSize * yCount);

            grid_g = Graphics.FromImage(grid_bm);
            grid_g.Clear(Color.White);

            for (int x = 0; x < answers.GetLength(HORIZONTAL) + 2; x++)
            {
                grid_g.DrawLine(thick, xSum(x), yAvgSize * 0, xSum(x), yAvgSize * yCount);
            }

            for (int y = 0; y < answers.GetLength(VERTICAL) + 2; y++)
            {
                grid_g.DrawLine(thick, xAvgSize * 0, yAvgSize * y, xAvgSize * xCount, yAvgSize * y);
            }

            for (int x = 0; x < horizontal.Length; x++)
            {
                int currWidth = TextRenderer.MeasureText(horizontal[x], borderFont).Width;
                int currHeight = TextRenderer.MeasureText(horizontal[x], borderFont).Height;

                int xPos = (xSum(x)) + ((xSizes[x] - currWidth) / 2);
                int yPos = 0 + ((yAvgSize - currHeight) / 2);

                grid_g.DrawString(horizontal[x], borderFont, Brushes.Black, xPos, yPos);
            }

            for (int y = 0; y < vertical.Length; y++)
            {
                int currWidth = TextRenderer.MeasureText(vertical[y], borderFont).Width;
                int currHeight = TextRenderer.MeasureText(vertical[y], borderFont).Height;

                int xPos = 0 + ((xSizes[0] - currWidth) / 2);
                int yPos = (yAvgSize * (y + 1)) + ((yAvgSize - currHeight) / 2);

                grid_g.DrawString(vertical[y], borderFont, Brushes.Black, xPos, yPos);
            }

            #endregion

            #region answers

            Random rand = new Random(DateTime.Now.Millisecond);

            for (int y = 0; y < answers.GetLength(VERTICAL); y++)
            {
                for (int x = 0; x < answers.GetLength(HORIZONTAL); x++)
                {
                    DraggableLabel currLabel = new DraggableLabel(answers[x, y]);

                    currLabel.Name = "answerLabel_" + x.ToString() + "_" + y.ToString();

                    currLabel.Size = new Size(xSizes[1 + x] - xMargin, yAvgSize - yMargin);

                    currLabel.Location = new Point(
                        x * (this.Width / answers.GetLength(HORIZONTAL)) + rand.Next(0, this.Width / answers.GetLength(HORIZONTAL) - xSizes[1 + x]),
                        rand.Next(((yStart + yCount) * yAvgSize), this.Height - yAvgSize)
                        );

                    currLabel.BackColor = Color.FromArgb(x * 25 + 50, Color.Black);

                    currLabel.TextAlign = ContentAlignment.MiddleCenter;

                    Controls.Add(currLabel);
                }
            }

            #endregion

            timer.Start();
            timer.Tick += timer_Tick;
            stopwatch.Start();
        }

        public static int xSum(int count)
        {
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += xSizes[i];
            }

            return sum;
        }

        public decimal ToNumeric(string input)
        {
            char[] chars = input.ToCharArray();

            foreach (char curr_char in chars)
            {
                if (!(Char.IsNumber(curr_char) || curr_char == '.'))
                {
                    MessageBox.Show("Hibás beállítások! (" + input + ")");
                    Environment.Exit(37);
                }
            }

            return Convert.ToDecimal(input);
        }

        static decimal DistanceBetween(Point a, Point b)
        {
            int xDist = (int)Math.Pow(a.X - b.X, 2);
            int yDist = (int)Math.Pow(a.Y - b.Y, 2);

            return (decimal)Math.Sqrt(xDist + yDist);
        }

        static decimal Distance(int a, int b)
        {
            return Math.Abs(a - b);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string minutes = ((stopwatch.ElapsedMilliseconds / 1000) / 60).ToString();

            string seconds = ((stopwatch.ElapsedMilliseconds / 1000) % 60).ToString();

            if (minutes.Length == 1)
            { minutes = "0" + minutes; }

            if (seconds.Length == 1)
            { seconds = "0" + seconds; }

            timerLabel.Text = minutes + ":" + seconds;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }

        private void hintButton_Click(object sender, EventArgs e)
        {
            if (animation_in_progress)
            {
                return;
            }

            animation_in_progress = true;

            Random rand = new Random(DateTime.Now.Millisecond);

            int xOffset = rand.Next();
            int yOffset = rand.Next();

            bool correct = true, allcorrect = false;
            int i = 0;

            DraggableLabel currLabel = new DraggableLabel(String.Empty);

            int x = -1, y = -1;
            int neutralX = -1, neutralY = -1;

            while (correct && i < (answers.GetLength(HORIZONTAL) * answers.GetLength(VERTICAL)))
            {
                y = ((i / answers.GetLength(HORIZONTAL)) + yOffset) % answers.GetLength(VERTICAL);
                x = ((i % answers.GetLength(HORIZONTAL)) + xOffset) % answers.GetLength(HORIZONTAL);

                int index = Controls.IndexOfKey("answerLabel_" + x.ToString() + "_" + y.ToString());

                currLabel = (DraggableLabel)Controls[index];

                Point location = currLabel.Location;

                int xPos = -1;
                for (int xTry = 0; xTry < xCount - 1; xTry++)
                {
                    int curr_x = (xStart * xAvgSize) + xSum(1 + x) + (xMargin / 2);
                    
                    if (curr_x == location.X)
                    {
                        xPos = xTry;
                    }
                }

                int yPos = -1;
                for (int yTry = 0; yTry < yCount - 1; yTry++)
                {
                    int curr_y = (yStart + 1 + neutralY) * yAvgSize + (yMargin / 2);
                    
                    if (curr_y == location.Y)
                    {
                        yPos = yTry;
                    }
                }

                if (xPos != -1 && yPos != -1)
                {
                    if (currLabel.Text == answers[xPos, yPos])
                    {
                        correct = true;
                    }

                    else
                    {
                        correct = false;
                        MessageBox.Show(currLabel.Text + ":" + answers[xPos, yPos]);
                    }
                }

                else
                {
                    neutralX = x;
                    neutralY = y;
                }

                i++;
            }

            if (correct)
            {
                if (neutralX == -1 && neutralY == -1)
                {
                    allcorrect = true;
                    MessageBox.Show("Minek segítséget kérni, ha már kész? :)");

                    animation_in_progress = false;
                }

                else
                {
                    int index = Controls.IndexOfKey("answerLabel_" + neutralX.ToString() + "_" + neutralY.ToString());
                    currLabel = (DraggableLabel)Controls[index];
                    currLabel.MoveTo(new Point((xStart * xAvgSize) + xSum(1 + neutralX) + (xMargin / 2), (yStart + 1 + neutralY) * yAvgSize + (yMargin / 2)));
                }
            }

            else
            {
                currLabel.MoveTo(new Point((xStart * xAvgSize) + xSum(1 + x) + (xMargin / 2), (yStart + 1 + y) * yAvgSize + (yMargin / 2)));
            }

            if (!allcorrect)
            {
                hintCount++;
                hintLabel.Text = Properties.Resources.hintCountString + hintCount.ToString();
            }
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            timerLabel.Text = "00:00";

            stopwatch.Reset();
            stopwatch.Start();

            hintCount = 0;
            hintLabel.Text = Properties.Resources.hintCountString + hintCount.ToString();
            submitCount = 0;
            submitLabel.Text = Properties.Resources.submitCountString + submitCount.ToString();

            Random rand = new Random(DateTime.Now.Millisecond);

            for (int y = 0; y < answers.GetLength(VERTICAL); y++)
            {
                for (int x = 0; x < answers.GetLength(HORIZONTAL); x++)
                {
                    int index = Controls.IndexOfKey("answerLabel_" + x.ToString() + "_" + y.ToString());

                    DraggableLabel currLabel = (DraggableLabel)Controls[index];

                    currLabel.Location = new Point(
                        x * (this.Width / answers.GetLength(HORIZONTAL)) + rand.Next(0, this.Width / answers.GetLength(HORIZONTAL) - xAvgSize),
                        rand.Next(((yStart + yCount) * yAvgSize), this.Height - yAvgSize)
                        );

                    currLabel.BackColor = Color.FromArgb(x * 25 + 50, Color.Black);
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < answers.GetLength(VERTICAL); y++)
            {
                for (int x = 0; x < answers.GetLength(HORIZONTAL); x++)
                {
                    int index = Controls.IndexOfKey("answerLabel_" + x.ToString() + "_" + y.ToString());

                    DraggableLabel currLabel = (DraggableLabel)Controls[index];

                    Point location = currLabel.Location;

                    int xPos = (location.X - (xMargin / 2)) / xAvgSize - (xStart + 1);
                    int yPos = (location.Y - (yMargin / 2)) / yAvgSize - (yStart + 1);

                    if ((xPos >= 0 && xPos < answers.GetLength(HORIZONTAL)) && (yPos >= 0 && yPos < answers.GetLength(VERTICAL)))
                    {
                        if (currLabel.Text == answers[xPos, yPos])
                        {
                            currLabel.BackColor = Color.Green;
                        }

                        else
                        {
                            currLabel.BackColor = Color.Red;
                        }
                    }

                    else
                    {
                        currLabel.BackColor = Color.Blue;
                    }
                }
            }

            submitCount++;
            submitLabel.Text = Properties.Resources.submitCountString + submitCount.ToString();
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(grid_bm, xAvgSize * xStart, yAvgSize * yStart);
        }

        private void footerLabel_DoubleClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
        }

        struct Setting
        {
            public string name, value;

            public Setting(string name, string value)
            {
                this.name = name;
                this.value = value;
            }

            public static string getValue(List<Setting> settings, string name)
            { 
                return settings.Find(setting => setting.name == name).value;
            }
        }

        class SkippableStreamReader : StreamReader
        {
            public SkippableStreamReader(string path, Encoding encoding) : base(path) { }

            public void SkipLines(int linecount)
            {
                for (int i = 0; i < linecount; i++)
                {
                    this.ReadLine();
                }
            }
        }

        class DraggableLabel : Label
        {
            Point offset;

            Point origin;
            Point destination;
            Timer animation_timer = new Timer();

            decimal dx = 0, dy = 0;
            int count = 0;

            public DraggableLabel(string text)
            {
                this.Text = text;
                animation_timer.Tick += animation_timer_Tick;
            }

            protected override void OnMouseDown(MouseEventArgs e)
            {
                offset = this.PointToClient(Cursor.Position);

                this.BringToFront();
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point mouse_pos = Cursor.Position;

                    int xPos = mouse_pos.X;
                    int yPos = mouse_pos.Y;

                    this.Location = new Point(xPos - offset.X, yPos - offset.Y);
                }
            }

            protected override void OnMouseUp(MouseEventArgs e)
            {
                Point location = this.Location;
                Point closest = new Point();

                for (int y = 0; y < answers.GetLength(VERTICAL); y++)
                {
                    for (int x = 0; x < answers.GetLength(HORIZONTAL); x++)
                    {
                        Point currPoint = new Point();

                        currPoint.X = (xStart * xAvgSize) + xSum(1 + x) + (xMargin / 2);
                        currPoint.Y = (yStart + 1 + y) * yAvgSize + (yMargin / 2);

                        //MessageBox.Show(currPoint.X.ToString() + ":" + currPoint.Y.ToString());

                        if (DistanceBetween(location, currPoint) < DistanceBetween(location, closest))
                        {
                            closest = currPoint;
                        }
                    }
                }

                if (Distance(location.X, closest.X) <= (xAvgSize / 2) && Distance(location.Y, closest.Y) <= (yAvgSize / 2))
                {
                    this.Location = closest;
                }

                //MessageBox.Show(distanceBetween(location, closest).ToString());
            }

            public void MoveTo(Point destination)
            {
                this.origin = this.Location;
                this.destination = destination;

                dx = (decimal)(destination.X - this.Location.X) / 100;
                dy = (decimal)(destination.Y - this.Location.Y) / 100;

                count = 0;

                animation_timer.Interval = 10;
                animation_timer.Start();
            }

            private void animation_timer_Tick(object sender, EventArgs e)
            {
                Point temp_dest = new Point();

                temp_dest.X = this.origin.X + (int)Math.Ceiling(count * dx);
                temp_dest.Y = this.origin.Y + (int)Math.Ceiling(count * dy);

                this.Location = temp_dest;

                count++;

                if (this.Location == destination)
                {
                    animation_timer.Stop();
                    animation_in_progress = false;
                }
            }
        }
    }
}