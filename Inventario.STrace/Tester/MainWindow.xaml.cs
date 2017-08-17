using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Inventario.STrace;
using Inventario.STrace.Base;
using Microsoft.Win32;

namespace Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tracer tracer = new Tracer();
            OpenFileDialog aDialog = new OpenFileDialog();
            aDialog.ShowDialog();
            tracer.Trace(new TraceBitmap(new Bitmap(aDialog.FileName)));
        }
    }
}
