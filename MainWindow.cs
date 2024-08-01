using System.Text;
using System.Text.RegularExpressions;

namespace UefiBootLogProcessor
{
    public partial class MainWindow : Form
    {
        Dictionary<string, string> guidNameMap = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
            tbBootLogFilePath.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbBootLogFilePath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            PrepareGuidToNameMap();
        }

        private void PrepareGuidToNameMap()
        {
            try
            {
                string guidNamesFile = @"guids.txt";
                string[] guidLines = File.ReadAllLines(guidNamesFile);

                foreach (string line in guidLines)
                {
                    string name = line.Split("=")[0];
                    string guid = line.Split("=")[1];

                    if (!guidNameMap.ContainsKey(guid))
                    {
                        guidNameMap[guid] = name;
                    }
                }
            }
            catch
            {
                tbOutput.Text = "Unable to locate guids.txt file. It should be next to the executable.";
            }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt|Log files (*.log)|*.log";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    // Display file path in TextBox
                    tbBootLogFilePath.Text = filePath;
                }
            }
        }

        private void bConvert_Click(object sender, EventArgs e)
        {
            Convert();
        }

        private void tbBootLogFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Convert();
            }
        }

        private void Convert()
        {
            try
            {
                string bootLogFileName = tbBootLogFilePath.Text;
                string[] bootLogFileLines = File.ReadAllLines(bootLogFileName);
                Regex regex = new Regex("([\\d\\w]{8}-[\\d\\w]{4}-[\\d\\w]{4}-[\\d\\w]{4}-[\\d\\w]{12})");
                StringBuilder stringBuilder = new StringBuilder();
                int i = 0;
                if (bootLogFileName.EndsWith("BUILDLOG_QemuQ35Pkg_Run.txt"))
                {
                    for (i = 0; i < bootLogFileLines.Length; i++)
                    {
                        string line = bootLogFileLines[i];
                        if (line.StartsWith("INFO - CPU model: qemu64")) break;
                    }
                }
                for (; i < bootLogFileLines.Length; i++)
                {
                    string line = bootLogFileLines[i];
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        if (!guidNameMap.ContainsKey(match.Value.ToUpper()))
                        {
                            stringBuilder.Append(line);
                            stringBuilder.Append(Environment.NewLine);
                            stringBuilder.Append($"[UefiBootLogProcessor] Name not found guid:{match.Value}");
                            stringBuilder.Append(Environment.NewLine);
                        }
                        else
                        {
                            stringBuilder.Append(line.Replace(match.Value, guidNameMap[match.Value.ToUpper()]));
                            stringBuilder.Append(Environment.NewLine);
                        }
                    }
                    else
                    {
                        stringBuilder.Append(line);
                        stringBuilder.Append(Environment.NewLine);
                    }
                }

                tbOutput.Text = stringBuilder.ToString();
            }
            catch (Exception e)
            {
                tbOutput.Text = e.ToString();
            }
        }
    }
}
