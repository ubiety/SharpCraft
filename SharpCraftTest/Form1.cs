using System;
using System.IO;
using System.Windows.Forms;
using SharpCraft;
using YamlDotNet.RepresentationModel.Serialization;

namespace SharpCraftTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{
			string settingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SharpCraft");
			string settingsFile = Path.Combine(settingsFolder, "settings.yml");

			if(!Directory.Exists(settingsFolder))
				Directory.CreateDirectory(settingsFolder);

			var s = new YamlSerializer<Settings>();
			var r = new Settings {Port = 25575, WorldName = "world"};

			var sw = new StreamWriter(settingsFile);
			s.Serialize(sw, r);
			sw.Flush();
			sw.Close();
		}
	}
}