using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Printing;

namespace Diagrams
{
    public partial class DiagramBox : UserControl
    {
        Diagram diagram;
        //выделенная фигура
        Figure selectedFigure = null;
        //фигура или маркер, который тащится мышью
        Figure draggedFigure = null;

        List<Marker> markers = new List<Marker>();
        Pen selectRectPen;

        public DiagramBox()
        {
            InitializeComponent();

            AutoScroll = true;

            DoubleBuffered = true;
            ResizeRedraw = true;

            selectRectPen = new Pen(Color.Red, 1);
            selectRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

        }

        public event EventHandler SelectedChanged;

        public Figure SelectedFigure
        {
            get { return selectedFigure; }
            set
            {
                selectedFigure = value;
                CreateMarkers();
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }


        //диаграмма, отображаемая компонентом
        public Diagram Diagram
        {
            get { return diagram; }
            set
            {
                diagram = value;
                selectedFigure = null;
                draggedFigure = null;
                markers.Clear();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics gr)
        {
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            if (diagram != null)
            {
                //сначала рисуем соединительные линии
                foreach (Figure f in diagram.figures)
                    if (f is LineFigure)
                        f.Draw(gr);
                //затем рисуем плоские фигуры
                foreach (Figure f in diagram.figures)
                    if (f is SolidFigure)
                        f.Draw(gr);
            }

            //рисуем прямоугольник выделенной фигуры
            if (selectedFigure is SolidFigure)
            {
                SolidFigure figure = selectedFigure as SolidFigure;
                RectangleF bounds = figure.Bounds;
                gr.DrawRectangle(selectRectPen, bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
            }
            //рисуем маркеры
            foreach (Marker m in markers)
                try
                {
                    m.Draw(gr);
                }
                catch { }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point location = e.Location;
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);

            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                draggedFigure = FindFigureByPoint(location);
                if (!(draggedFigure is Marker))
                {
                    selectedFigure = draggedFigure;
                    CreateMarkers();
                }
                else
                {
                    Cursor.Hide();
                }

                startDragPoint = location;
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }

        public void CreateMarkers()
        {
            markers = new List<Marker>();
            if (selectedFigure != null)
            {
                foreach (Marker m in selectedFigure.GetMarkers(diagram))
                    markers.Add(m);
                UpdateMarkers();
            }
        }

        private void UpdateMarkers()
        {
            foreach (Marker m in markers)
                if (draggedFigure != m)//маркер который тащится, обновляется сам
                    m.UpdateLocation();
        }

        Point startDragPoint;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point location = e.Location;
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (draggedFigure != null && (draggedFigure is SolidFigure))
                {
                    (draggedFigure as SolidFigure).Offset(location.X - startDragPoint.X, location.Y - startDragPoint.Y);
                    UpdateMarkers();
                    Invalidate();
                    CalcAutoScrollPosition();
                }
            }
            else
            {
                Figure figure = FindFigureByPoint(location);
                if (figure is Marker)
                {
                    Cursor = (figure as Marker).Cursor;
                    if (toolTip1.GetToolTip(this) != (figure as Marker).ToolTip)
                        toolTip1.SetToolTip(this, (figure as Marker).ToolTip);
                }
                else
                {
                    if (figure != null)
                        Cursor = Cursors.Hand;
                    else
                        Cursor = Cursors.Default;

                    if (toolTip1.GetToolTip(this) != null)
                        toolTip1.SetToolTip(this, null);
                }
            }

            startDragPoint = location;
        }

        private void CalcAutoScrollPosition()
        {
            RectangleF r = new RectangleF(0, 0, 0, 0);
            //перебираем все фигуры, ищем максимальные координаты
            foreach (Figure f in diagram.figures)
                if (f != null && f is SolidFigure)
                    r = RectangleF.Union(r, (f as SolidFigure).Bounds);

            Size size = new Size((int)r.Width, (int)r.Height);
            if (size != AutoScrollMinSize)
                AutoScrollMinSize = size;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor.Show();
            draggedFigure = null;
            UpdateMarkers();
            Invalidate();
        }

        //поиск фигуры, по данной точке
        public Figure FindFigureByPoint(Point p)
        {
            //ищем среди маркеров
            for (int i = markers.Count - 1; i >= 0; i--)
                if (markers[i].IsInsidePoint(p))
                    return markers[i];
            //затем ищем среди плоских фигур
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is SolidFigure && diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            //затем ищем среди линий
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is LineFigure && diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            return null;
        }

        public void AddFigure<FigureType>(PointF location) where FigureType : SolidFigure, new()
        {
            FigureType figure = new FigureType();
            figure.location = location;
            if (diagram != null)
                diagram.figures.Add(figure);
            Invalidate();
        }

        public void SelectedBringToFront()
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Add(selectedFigure);
                Invalidate();
            }
        }


        public void SelectedSendToBack()
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Insert(0, selectedFigure);
                Invalidate();
            }
        }

        public void SelectedBeginEditText()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                SolidFigure figure = (selectedFigure as SolidFigure);
                TextBox textBox = new TextBox();
                textBox.Parent = this;
                textBox.SetBounds(figure.TextBounds.Left, figure.TextBounds.Top, figure.TextBounds.Width, figure.TextBounds.Height);
                textBox.Text = figure.text;
                textBox.Multiline = true;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Focus();
                textBox.LostFocus += new EventHandler(textBox_LostFocus);
            }
        }

        void textBox_LostFocus(object sender, EventArgs e)
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                (selectedFigure as SolidFigure).text = (sender as TextBox).Text;
            }
            Controls.Remove((Control)sender);
        }

        public void SelectedAddLine()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                LineFigure line = new LineFigure();
                line.From = (selectedFigure as SolidFigure);
                EndLineMarker marker = new EndLineMarker(diagram, 1);
                marker.location = line.From.location;
                marker.location = marker.location.Offset(0, line.From.Size.Height / 2 + 10);
                line.To = marker;
                diagram.figures.Add(line);
                selectedFigure = line;
                CreateMarkers();

                Invalidate();
            }
        }

        public void SelectedAddLedgeLine()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                LedgeLineFigure line = new LedgeLineFigure();
                line.From = (selectedFigure as SolidFigure);
                EndLineMarker marker = new EndLineMarker(diagram, 1);
                marker.location = line.From.location;
                marker.location = marker.location.Offset(0, line.From.Size.Height / 2 + 10);
                line.To = marker;
                diagram.figures.Add(line);
                selectedFigure = line;
                CreateMarkers();

                //добавление объектов связи
                diagram.communication.Add(new List<Figure>() { line.From, line.To });
                Invalidate();
            }
        }

        public void SelectedDelete()
        {
            if (selectedFigure != null)
            {
                //удалем фигуру
                diagram.figures.Remove(selectedFigure);

                //удялаем также все линии, ведущие к данной фигуре
                for (int i = diagram.figures.Count - 1; i >= 0; i--)
                    if (diagram.figures[i] is LineFigure)
                    {
                        LineFigure line = (diagram.figures[i] as LineFigure);
                        if (line.To == selectedFigure || line.From == selectedFigure)
                            diagram.figures.RemoveAt(i);
                    }

                selectedFigure = null;
                draggedFigure = null;
                CreateMarkers();

                Invalidate();
            }
        }

        //преобразуем в картинку
        public Bitmap GetImage()
        {
            selectedFigure = null;
            draggedFigure = null;
            CreateMarkers();

            Bitmap bmp = new Bitmap(Bounds.Width, Bounds.Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            return bmp;
        }


        //сохраняем как метафайл
        public void SaveAsMetafile(string fileName)
        {
            selectedFigure = null;
            draggedFigure = null;
            CreateMarkers();

            Metafile curMetafile = null;
            Graphics g = this.CreateGraphics();
            IntPtr hdc = g.GetHdc();
            Rectangle rect = new Rectangle(0, 0, 200, 200);
            try
            {
                curMetafile =
                    new Metafile(fileName, hdc, System.Drawing.Imaging.EmfType.EmfOnly);
            }
            catch
            {
                g.ReleaseHdc(hdc);
                g.Dispose();
                throw;
            }

            Graphics gr = Graphics.FromImage(curMetafile);
            //отрисовываем диаграмму
            Draw(gr);

            g.ReleaseHdc(hdc);
            gr.Dispose();
            g.Dispose();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (SelectedFigure == null || !(SelectedFigure is SolidFigure))
                return;
            int dx = 0;
            int dy = 0;
            if (e.KeyData == Keys.Right)
                dx = +1;
            if (e.KeyData == Keys.Left)
                dx = -1;
            if (e.KeyData == Keys.Up)
                dy = -1;
            if (e.KeyData == Keys.Down)
                dy = +1;

            if (e.KeyData == (Keys.Right | Keys.Shift))
                dx = +15;
            if (e.KeyData == (Keys.Left | Keys.Shift))
                dx = -15;
            if (e.KeyData == (Keys.Up | Keys.Shift))
                dy = -15;
            if (e.KeyData == (Keys.Down | Keys.Shift))
                dy = +15;

            if (dx != 0 || dy != 0)
            {
                (SelectedFigure as SolidFigure).Offset(dx, dy);
                UpdateMarkers();
                CalcAutoScrollPosition();
                Invalidate();
            }
        }
    }
}
