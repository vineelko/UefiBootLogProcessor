using Microsoft.Web.WebView2.WinForms;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace UefiBootLogProcessor
{
    public partial class MainWindow : Form
    {
        Dictionary<string, string> guidNameMap = new Dictionary<string, string>();
        private WebView2 webView;

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        public MainWindow()
        {
            InitializeComponent();
            InitializeWebView();
            //AllocConsole(); // Attach a console to the application

            tbBootLogFilePath.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbBootLogFilePath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            PrepareGuidToNameMap();
            tbBootLogFilePath.Text = @"C:\r\tool_work\Build\BUILDLOG_QemuQ35Pkg_Run.txt";
        }
        private async void InitializeWebView()
        {
            // Create WebView2 instance
            webView = new WebView2
            {
                Dock = DockStyle.Fill // Make it fill the form
            };

            // Add WebView2 to the form
            this.pOutput.Controls.Add(webView);

            // Ensure WebView2 is initialized
            await webView.EnsureCoreWebView2Async();

            // Load the Monaco Editor HTML file
            string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "monaco.html");
            webView.Source = new Uri(htmlPath);
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
                _ = SetTextAsync("Unable to locate guids.txt file. It should be next to the executable.");
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

                _ = SetTextAsync(stringBuilder.ToString());
            }
            catch (Exception e)
            {
                _ = SetTextAsync(e.ToString());
            }
        }

        private async Task SetTextAsync(string text)
        {
            try
            {
                string escapedText = System.Text.Json.JsonSerializer.Serialize(text); // Properly escape text
                string result = await webView.CoreWebView2.ExecuteScriptAsync($"setEditorText({escapedText});");

                Console.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing script: " + ex.Message);
            }
        }

        private string getText()
        {
            return webView.CoreWebView2.ExecuteScriptAsync("getEditorText();").Result;
        }
    }
}
