using System;
using System.Windows.Forms;
using NationalInstruments.Visa;
using System.Threading;


namespace NationalInstruments.Examples.SimpleReadWrite
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private MessageBasedSession mbSession;
        private string lastResourceString = null;
        private System.Windows.Forms.TextBox writeTextBox;
        private System.Windows.Forms.TextBox readTextBox;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button openSessionButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button closeSessionButton;
        private System.Windows.Forms.Label stringToWriteLabel;
        private System.Windows.Forms.Label stringToReadLabel;
        private Button button1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            SetupControlState(false);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(mbSession != null)
                {
                    mbSession.Dispose();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.queryButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.openSessionButton = new System.Windows.Forms.Button();
            this.writeTextBox = new System.Windows.Forms.TextBox();
            this.readTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.closeSessionButton = new System.Windows.Forms.Button();
            this.stringToWriteLabel = new System.Windows.Forms.Label();
            this.stringToReadLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(5, 83);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(74, 23);
            this.queryButton.TabIndex = 3;
            this.queryButton.Text = "Query";
            this.queryButton.Click += new System.EventHandler(this.query_Click);
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(79, 83);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(74, 23);
            this.writeButton.TabIndex = 4;
            this.writeButton.Text = "Write";
            this.writeButton.Click += new System.EventHandler(this.write_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(153, 83);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(74, 23);
            this.readButton.TabIndex = 5;
            this.readButton.Text = "Read";
            this.readButton.Click += new System.EventHandler(this.read_Click);
            // 
            // openSessionButton
            // 
            this.openSessionButton.Location = new System.Drawing.Point(5, 5);
            this.openSessionButton.Name = "openSessionButton";
            this.openSessionButton.Size = new System.Drawing.Size(92, 22);
            this.openSessionButton.TabIndex = 0;
            this.openSessionButton.Text = "Open Session";
            this.openSessionButton.Click += new System.EventHandler(this.openSession_Click);
            // 
            // writeTextBox
            // 
            this.writeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.writeTextBox.Location = new System.Drawing.Point(5, 54);
            this.writeTextBox.Name = "writeTextBox";
            this.writeTextBox.Size = new System.Drawing.Size(472, 20);
            this.writeTextBox.TabIndex = 2;
            this.writeTextBox.Text = "*IDN?\\n";
            this.writeTextBox.TextChanged += new System.EventHandler(this.writeTextBox_TextChanged);
            // 
            // readTextBox
            // 
            this.readTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readTextBox.Location = new System.Drawing.Point(5, 136);
            this.readTextBox.Multiline = true;
            this.readTextBox.Name = "readTextBox";
            this.readTextBox.ReadOnly = true;
            this.readTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.readTextBox.Size = new System.Drawing.Size(472, 119);
            this.readTextBox.TabIndex = 6;
            this.readTextBox.TabStop = false;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(6, 257);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(472, 24);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clear_Click);
            // 
            // closeSessionButton
            // 
            this.closeSessionButton.Location = new System.Drawing.Point(97, 5);
            this.closeSessionButton.Name = "closeSessionButton";
            this.closeSessionButton.Size = new System.Drawing.Size(92, 22);
            this.closeSessionButton.TabIndex = 1;
            this.closeSessionButton.Text = "Close Session";
            this.closeSessionButton.Click += new System.EventHandler(this.closeSession_Click);
            // 
            // stringToWriteLabel
            // 
            this.stringToWriteLabel.Location = new System.Drawing.Point(5, 34);
            this.stringToWriteLabel.Name = "stringToWriteLabel";
            this.stringToWriteLabel.Size = new System.Drawing.Size(91, 14);
            this.stringToWriteLabel.TabIndex = 8;
            this.stringToWriteLabel.Text = "String to Write:";
            // 
            // stringToReadLabel
            // 
            this.stringToReadLabel.Location = new System.Drawing.Point(5, 117);
            this.stringToReadLabel.Name = "stringToReadLabel";
            this.stringToReadLabel.Size = new System.Drawing.Size(101, 15);
            this.stringToReadLabel.TabIndex = 9;
            this.stringToReadLabel.Text = "String Read:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(484, 289);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stringToReadLabel);
            this.Controls.Add(this.stringToWriteLabel);
            this.Controls.Add(this.closeSessionButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.readTextBox);
            this.Controls.Add(this.writeTextBox);
            this.Controls.Add(this.openSessionButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.queryButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(295, 316);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Read/Write";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        private void openSession_Click(object sender, System.EventArgs e)
        {
            using (SelectResource sr = new SelectResource())
            {
                if(lastResourceString != null)
                {
                    sr.ResourceName = lastResourceString;
                }
                DialogResult result = sr.ShowDialog(this);
                if(result == DialogResult.OK)
                {
                    lastResourceString = sr.ResourceName;
                    Cursor.Current = Cursors.WaitCursor;
                    using (var rmSession = new ResourceManager())
                    {
                        try
                        {
                            mbSession = (MessageBasedSession)rmSession.Open(sr.ResourceName);
                            SetupControlState(true);
                        }
                        catch (InvalidCastException)
                        {
                            MessageBox.Show("Resource selected must be a message-based session");
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void closeSession_Click(object sender, System.EventArgs e)
        {
            SetupControlState(false);
            mbSession.Dispose();
        }

        private void query_Click(object sender, System.EventArgs e)
        {
            readTextBox.Text = String.Empty;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string textToWrite = ReplaceCommonEscapeSequences(writeTextBox.Text);
                mbSession.RawIO.Write(textToWrite);
                readTextBox.Text = InsertCommonEscapeSequences(mbSession.RawIO.ReadString());
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void write_Click(object sender, System.EventArgs e)
        {
            try
            {
               
               string textToWrite = ReplaceCommonEscapeSequences(writeTextBox.Text);
              
                mbSession.RawIO.Write(textToWrite);
     


            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void read_Click(object sender, System.EventArgs e)
        {
            readTextBox.Text = String.Empty;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                readTextBox.Text = InsertCommonEscapeSequences(mbSession.RawIO.ReadString());
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void clear_Click(object sender, System.EventArgs e)
        {
            readTextBox.Text = String.Empty;
        }

        private void SetupControlState(bool isSessionOpen)
        {
            openSessionButton.Enabled = !isSessionOpen;
            closeSessionButton.Enabled = isSessionOpen;
            queryButton.Enabled = isSessionOpen;
            writeButton.Enabled = isSessionOpen;
            readButton.Enabled = isSessionOpen;
            writeTextBox.Enabled = isSessionOpen;
            clearButton.Enabled = isSessionOpen;
            if(isSessionOpen)
            {
                readTextBox.Text = String.Empty;
                writeTextBox.Focus();
            }
        }

        private string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        private void writeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int voltage = 12;
                string textToWrite = "DISP:CHAN 1";
                mbSession.RawIO.Write(textToWrite);
                Thread.Sleep(1000);
                mbSession.RawIO.Write("SOUR1:VOLT " + voltage);
                Thread.Sleep(1000);
                mbSession.RawIO.Write("SENS1:CURR:RANG:AUTO ON");
                Thread.Sleep(500);
                mbSession.RawIO.Write("SOUR2:CURR 200e-3");
                Thread.Sleep(500);
                mbSession.RawIO.Write("OUTP2 ON");
                Thread.Sleep(500);
                mbSession.RawIO.Write("SENS:FUNC 'CURR'");
                Thread.Sleep(500);
                //mbSession.RawIO.Write("READ ?");
                //readTextBox.Text = InsertCommonEscapeSequences(mbSession.RawIO.ReadString());

                string ABC = ReplaceCommonEscapeSequences("READ?");
                mbSession.RawIO.Write(ABC);
                readTextBox.Text = InsertCommonEscapeSequences(mbSession.RawIO.ReadString());


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
