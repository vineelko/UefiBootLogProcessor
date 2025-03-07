namespace UefiBootLogProcessor
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            lUefiBootLogPath = new Label();
            tbBootLogFilePath = new TextBox();
            bBrowse = new Button();
            bConvert = new Button();
            lLinkLabel = new LinkLabel();
            pTopPanel = new Panel();
            pButtons = new Panel();
            pOutput = new Panel();
            pBottom = new Panel();
            lLabelGithub = new LinkLabel();
            pTopPanel.SuspendLayout();
            pButtons.SuspendLayout();
            pBottom.SuspendLayout();
            SuspendLayout();
            // 
            // lUefiBootLogPath
            // 
            lUefiBootLogPath.AutoSize = true;
            lUefiBootLogPath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lUefiBootLogPath.Location = new Point(5, 30);
            lUefiBootLogPath.Margin = new Padding(2, 0, 2, 0);
            lUefiBootLogPath.Name = "lUefiBootLogPath";
            lUefiBootLogPath.Size = new Size(115, 15);
            lUefiBootLogPath.TabIndex = 0;
            lUefiBootLogPath.Text = "Uefi Boot Log Path:";
            // 
            // tbBootLogFilePath
            // 
            tbBootLogFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbBootLogFilePath.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbBootLogFilePath.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tbBootLogFilePath.Location = new Point(157, 27);
            tbBootLogFilePath.Name = "tbBootLogFilePath";
            tbBootLogFilePath.Size = new Size(564, 23);
            tbBootLogFilePath.TabIndex = 1;
            tbBootLogFilePath.Text = "C:\\r\\mu_tiano_platforms\\Build\\BUILDLOG_QemuQ35Pkg_Run.txt";
            tbBootLogFilePath.KeyDown += tbBootLogFilePath_KeyDown;
            // 
            // bBrowse
            // 
            bBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bBrowse.Location = new Point(3, 7);
            bBrowse.Name = "bBrowse";
            bBrowse.Size = new Size(78, 67);
            bBrowse.TabIndex = 0;
            bBrowse.Text = "Browse";
            bBrowse.UseVisualStyleBackColor = true;
            bBrowse.Click += bBrowse_Click;
            // 
            // bConvert
            // 
            bConvert.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bConvert.Location = new Point(85, 7);
            bConvert.Name = "bConvert";
            bConvert.Size = new Size(88, 67);
            bConvert.TabIndex = 1;
            bConvert.Text = "Convert";
            bConvert.UseVisualStyleBackColor = true;
            bConvert.Click += bConvert_Click;
            // 
            // lLinkLabel
            // 
            lLinkLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lLinkLabel.AutoSize = true;
            lLinkLabel.Location = new Point(662, 16);
            lLinkLabel.Name = "lLinkLabel";
            lLinkLabel.Size = new Size(231, 15);
            lLinkLabel.TabIndex = 5;
            lLinkLabel.TabStop = true;
            lLinkLabel.Text = "https://icons8.com/icon/13120/binoculars";
            // 
            // pTopPanel
            // 
            pTopPanel.Controls.Add(pButtons);
            pTopPanel.Controls.Add(tbBootLogFilePath);
            pTopPanel.Controls.Add(lUefiBootLogPath);
            pTopPanel.Dock = DockStyle.Top;
            pTopPanel.Location = new Point(0, 0);
            pTopPanel.Name = "pTopPanel";
            pTopPanel.Size = new Size(905, 80);
            pTopPanel.TabIndex = 0;
            // 
            // pButtons
            // 
            pButtons.Controls.Add(bConvert);
            pButtons.Controls.Add(bBrowse);
            pButtons.Dock = DockStyle.Right;
            pButtons.Location = new Point(727, 0);
            pButtons.Name = "pButtons";
            pButtons.Size = new Size(178, 80);
            pButtons.TabIndex = 2;
            // 
            // pOutput
            // 
            pOutput.Dock = DockStyle.Fill;
            pOutput.Location = new Point(0, 80);
            pOutput.Name = "pOutput";
            pOutput.Padding = new Padding(5);
            pOutput.Size = new Size(905, 882);
            pOutput.TabIndex = 7;
            // 
            // pBottom
            // 
            pBottom.Controls.Add(lLabelGithub);
            pBottom.Controls.Add(lLinkLabel);
            pBottom.Dock = DockStyle.Bottom;
            pBottom.Location = new Point(0, 922);
            pBottom.Name = "pBottom";
            pBottom.Size = new Size(905, 40);
            pBottom.TabIndex = 6;
            // 
            // lLabelGithub
            // 
            lLabelGithub.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lLabelGithub.AutoSize = true;
            lLabelGithub.Location = new Point(8, 16);
            lLabelGithub.Name = "lLabelGithub";
            lLabelGithub.Size = new Size(280, 15);
            lLabelGithub.TabIndex = 6;
            lLabelGithub.TabStop = true;
            lLabelGithub.Text = "https://github.com/vineelko/UefiBootLogProcessor";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 962);
            Controls.Add(pBottom);
            Controls.Add(pOutput);
            Controls.Add(pTopPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "MainWindow";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "UefiBootLogProcessor - Convert guids to names in UEFI boot log";
            pTopPanel.ResumeLayout(false);
            pTopPanel.PerformLayout();
            pButtons.ResumeLayout(false);
            pBottom.ResumeLayout(false);
            pBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lUefiBootLogPath;
        private TextBox tbBootLogFilePath;
        private Button bBrowse;
        private Button bConvert;
        private LinkLabel lLinkLabel;
        private Panel pTopPanel;
        private Panel pButtons;
        private Panel pOutput;
        private Panel pBottom;
        private LinkLabel lLabelGithub;
    }
}
