using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace DesktopApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Size screeSize = Screen.PrimaryScreen.Bounds.Size;

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public static void SetWallpaper(string path, int style, int tile)
        {
            
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue("WallpaperStyle", style.ToString());
            key.SetValue("TileWallpaper", tile.ToString());
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Ставить чорний фон на робочий стіл
            //SetWallpaper("blackfon.png", 1, 0);
            Size = new Size(screeSize.Width, screeSize.Height);
            Location = new Point((screeSize.Width / 2) - (Size.Width / 2),
                (screeSize.Height / 2) - (Size.Height / 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
