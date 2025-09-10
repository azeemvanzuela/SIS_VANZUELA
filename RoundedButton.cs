using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class RoundedButton : Button
{
    public int BorderRadius { get; set; } = 20;
    public Color BorderColor { get; set; } = Color.MediumPurple;
    public int BorderSize { get; set; } = 2;

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Graphics g = pevent.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectSurface = this.ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderSize, -BorderSize);

        int radius = BorderRadius;

        using (GraphicsPath pathSurface = GetFigurePath(rectSurface, radius))
        using (GraphicsPath pathBorder = GetFigurePath(rectBorder, radius - 1))
        using (Pen penSurface = new Pen(this.Parent.BackColor, BorderSize))
        using (Pen penBorder = new Pen(BorderColor, BorderSize))
        {
            // surface
            this.Region = new Region(pathSurface);
            g.DrawPath(penSurface, pathSurface);

            // border
            if (BorderSize >= 1)
                g.DrawPath(penBorder, pathBorder);
        }
    }

    private GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
        float r = radius * 2F;
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(rect.X, rect.Y, r, r, 180, 90);
        path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
        path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
        path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
        path.CloseFigure();
        return path;
    }
}
