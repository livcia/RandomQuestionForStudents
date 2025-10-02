using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LosowaniePytan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KoloPytania(9);
            KoloUczniowie(4);
        }

        private void KoloPytania(int sectors)
        {
            int polowa = sectors / 2;
            WheelCanvas.Children.Clear();
            double centerX = WheelCanvas.Width / 2;
            double centerY = WheelCanvas.Height / 2;
            double radius = WheelCanvas.Width / 2;
            double angleStep = 360.0 / sectors;

            for (int i = 0; i < sectors; i++)
            {
                double startAngle = i * angleStep;
                WheelSectorDrawer.DrawSectorWithText(
                    WheelCanvas,
                    centerX,
                    centerY,
                    radius,
                    startAngle,
                    angleStep,
                    Brushes.Aqua,
                    Brushes.Black,
                    2,
                    "Czy funkcja w każdym uruchomieniu zachowuje się dokładnie tak samo?",
                    i,
                    sectors
                );
            }

        }

        private void KoloUczniowie(int sectors)
        {
            WheelCanvas_Kopiuj.Children.Clear();
            double centerX = WheelCanvas_Kopiuj.Width / 2;
            double centerY = WheelCanvas_Kopiuj.Height / 2;
            double radius = WheelCanvas_Kopiuj.Width / 2;
            double angleStep = 360.0 / sectors;

            for (int i = 0; i < sectors; i++)
            {
                double startAngle = i * angleStep;
                WheelSectorDrawer.DrawSectorWithText(
                    WheelCanvas_Kopiuj,
                    centerX,
                    centerY,
                    radius,
                    startAngle,
                    angleStep,
                    Brushes.Aqua,
                    Brushes.Black,
                    2,
                    "Ania ?",
                    i,
                    sectors,
                    fontSize: 30
                );
            }

        }



    }
}