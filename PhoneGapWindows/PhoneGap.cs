using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace PhoneGapWindows
{
    public partial class PhoneGap : Form
    {
        private CommandManager commandManager;

        public PhoneGap()
        {
            InitializeComponent();

            this.commandManager = new CommandManager();

            //this.browser.DocumentStream = (WebKit.Interop.IStream)getEmbeddedResource(url);

            //this.browser.DocumentText = new StreamReader(getEmbeddedResource(url), Encoding.GetEncoding("UTF-8")).ReadToEnd();
            this.browser.DocumentTitleChanged += new EventHandler(browser_DocumentTitleChanged);
            this.browser.Navigate("file:///" + Application.StartupPath.Replace("\\", "/") + "/www/index.html");
        }

        void browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            if (this.browser.DocumentTitle.StartsWith("gap://"))
            {
                String title = this.browser.DocumentTitle.Replace("gap://", "");
                String command = title.Split('?')[0];
                String[] args = new String[0];
                String response = this.commandManager.ProcessInstruction(command, args);
                this.browser.InvokeScript(response);
            }
        }

        private Stream getEmbeddedResource(string url)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            // Hacky, because assembly.GetName().Name raises an 'InvalidProgramException'. wtf
            string assName = assembly.FullName.Substring(0, assembly.FullName.IndexOf(','));
            string path = assName + ".www." + (url.StartsWith("/www/") ? url.Substring(5) : url).Replace("/", ".");
            return assembly.GetManifestResourceStream(path);
        }
    }
}
