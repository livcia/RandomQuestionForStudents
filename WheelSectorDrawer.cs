using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace LosowaniePytan
{
    public static class WheelSectorDrawer
    {
        public static void DrawSectorWithText(
            Canvas canvas,
            double centerX,
            double centerY,
            double radius,
            double startAngle,
            double angleStep,
            Brush fill,
            Brush stroke,
            double strokeThickness,
            string text,
            int sectorIndex,
            int sectorsCount,
            double fontSize = 14 
            )
        {
            double endAngle = startAngle + angleStep;

            Point p1 = new Point(
                centerX + radius * Math.Cos(startAngle * Math.PI / 180),
                centerY + radius * Math.Sin(startAngle * Math.PI / 180)
            );

            Point p2 = new Point(
                centerX + radius * Math.Cos(endAngle * Math.PI / 180),
                centerY + radius * Math.Sin(endAngle * Math.PI / 180)
            );

            PathFigure figure = new PathFigure { StartPoint = new Point(centerX, centerY) };
            figure.Segments.Add(new LineSegment(p1, true));
            figure.Segments.Add(new ArcSegment
            {
                Point = p2,
                Size = new Size(radius, radius),
                SweepDirection = SweepDirection.Clockwise,
                IsLargeArc = angleStep > 180
            });
            figure.Segments.Add(new LineSegment(new Point(centerX, centerY), true));

            PathGeometry geometry = new PathGeometry();
            geometry.Figures.Add(figure);

            Path path = new Path
            {
                Fill = fill,
                Stroke = stroke,
                StrokeThickness = strokeThickness,
                Data = geometry
            };

            canvas.Children.Add(path);

            // Tekst
            double midAngle = startAngle + angleStep / 2;
            double textRadius = radius * 0.60;
            double textX = centerX + textRadius * Math.Cos(midAngle * Math.PI / 180);
            double textY = centerY + textRadius * Math.Sin(midAngle * Math.PI / 180);

            double sectorArcLength = 2 * Math.PI * textRadius * (angleStep / 360.0);
            double maxTextWidth = sectorArcLength * 1.4;

            TextBlock textBlock = new TextBlock
            {
                Text = text,
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                FontSize = fontSize,
                Width = maxTextWidth,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };

            textBlock.Measure(new Size(maxTextWidth, double.PositiveInfinity));
            double textHeight = textBlock.DesiredSize.Height;

            double polowa = sectorsCount / 2.0;
            double angle = midAngle;
            if (sectorIndex >= 3 && sectorIndex < 6)
            {
                angle += 180;
            }
            textBlock.RenderTransform = new RotateTransform(angle, maxTextWidth / 2, textHeight / 2);

            Canvas.SetLeft(textBlock, textX - maxTextWidth / 2);
            Canvas.SetTop(textBlock, textY - textHeight / 2);

            canvas.Children.Add(textBlock);
        }
    }
}
