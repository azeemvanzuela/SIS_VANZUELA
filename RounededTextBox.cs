using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox : TextBox
{
    private int borderRadius = 15; // adjust roundness
    private Color borderColor = Color.MediumPurple; // border color
    private int borderSize = 2;

    public RoundedTextBox()
    {
        BorderStyle = BorderStyle.None;
        Padding = new Padding(10, 7, 10, 7);
        Multiline = false;
        BackColor = Color.White;
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        UpdateRegion();
    }

    private void UpdateRegion()
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
        path.AddArc(Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
        path.AddArc(Width - borderRadius, Height - borderRadius, borderRadius, borderRadius, 0, 90);
        path.AddArc(0, Height - borderRadius, borderRadius, borderRadius, 90, 90);
        path.CloseFigure();
        this.Region = new Region(path);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        UpdateRegion();
    }
}
