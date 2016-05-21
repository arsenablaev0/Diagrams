using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Diagrams
{
    //диаграмма
    [Serializable]
    public class Diagram
    {

        //список фигур диаграммы
        public List<Figure> figures = new List<Figure>();
        //public List<List<string>> TaskList = new List<List<string>>();

        // сохранение связей
        public List<List<Figure>> communication = new List<List<Figure>>();

        //сохранение диаграммы в файл
        public void Save(string fileName)
        {
            //StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create));

            //foreach (var figure in figures)
            //{
            //    sw.Write(figure.ToString() + " ");
            //}

            //sw.Close();

            //BinaryFormatter bf = new BinaryFormatter();
            //using(FileStream fs = new FileStream(fileName, FileMode.Create))
            //{
            //    bf.Serialize(fs, figures);////******************************************!!!!! эта хуйня не работает
            //}




        }

        //чтение диаграммы из файла

        public static List<Figure> Load(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            // return (Diagram)new BinaryFormatter().Deserialize(fs);
            {
                return (List<Figure>)new BinaryFormatter().Deserialize(fs);


            }
        }
    }

    //фигура
    [Serializable]
    public abstract class Figure
    {
        //линии фигуры

        private GraphicsPath serializablePath = new GraphicsPath();


        public GraphicsPath Path { get { return serializablePath; } }

        //карандаш отрисовки линий

        Color _penColor = Color.CornflowerBlue;
        public float _penWidth = 1;

        public string Name;
        [NonSerialized]
        protected Pen _pen;

        public virtual Pen pen
        {
            get
            {
                if (_pen == null)
                    _pen = new Pen(_penColor, _penWidth);
                return _pen;
            }
        }

        public Color penColor
        {
            get { return _penColor; }
            set { _penColor = value; _pen = null; }
        }

        public float penWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; _pen = null; }
        }

        //точка находится внутри фигуры?
        public abstract bool IsInsidePoint(PointF p);

        //отрисовка фигуры
        public abstract void Draw(Graphics gr);

        //получение маркеров
        public abstract IEnumerable<Marker> GetMarkers(Diagram diagram);

        public virtual Figure Clone()
        {
            return (Figure)MemberwiseClone();
        }
    }



    //многоугольник с текстом внутри
    [Serializable]
    public abstract class SolidFigure : Figure
    {
        //размер новой фигуры, по умолчанию
        public static int defaultSize = 40;
        //заливка фигуры
        Color _color = Color.CornflowerBlue;
        //местоположение центра фигуры
        public PointF location;
        //прямоугольник, в котором расположен текст
        protected RectangleF textRect;
        //текст
        public string text = null;
        //
        [NonSerialized]
        public Brush _brush;

        public Color color
        {
            get { return _color; }
            set { _color = value; _brush = null; }
        }

        public virtual Brush brush
        {
            get
            {
                if (_brush == null)
                    _brush = new SolidBrush(_color);
                return _brush;
            }
        }


        public SolidFigure()
        {

        }

        public virtual void ZOrderChange(Diagram diagram, int d)
        {
            int i = diagram.figures.IndexOf(this);

            if (d < 0 && i > 0)
            {
                diagram.figures.RemoveAt(i);
                diagram.figures.Insert(i - 1, this);
            }
            if (d > 0 && i < diagram.figures.Count - 1)
            {
                diagram.figures.RemoveAt(i);
                diagram.figures.Insert(i + 1, this);
            }
        }

        //настройки вывода текста
        protected virtual StringFormat StringFormat
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }

        //находится ли точка внутри контура?
        public override bool IsInsidePoint(PointF p)
        {
            return Path.IsVisible(p.X - location.X, p.Y - location.Y);

        }

        //прямоугольник вокруг фигуры (в абсолютных координатах)
        public virtual RectangleF Bounds
        {
            get
            {
                RectangleF bounds = Path.GetBounds();
                return new RectangleF(bounds.Left + location.X, bounds.Top + location.Y, bounds.Width, bounds.Height);
            }
        }

        //прямоугольник текста (в абсолютных координатах)
        public Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int)(textRect.Left + location.X), (int)(textRect.Top + location.Y), (int)textRect.Width, (int)textRect.Height);
            }
        }

        //размер прямоугольника вокруг фигуры
        public SizeF Size
        {
            get { return Path.GetBounds().Size; }
            set
            {
                SizeF oldSize = Path.GetBounds().Size;
                SizeF newSize = new SizeF(Math.Max(1, value.Width), Math.Max(1, value.Height));
                //коэффициент шкалировани по x
                float kx = newSize.Width / oldSize.Width;
                //коэффициент шкалировани по y
                float ky = newSize.Height / oldSize.Height;
                Scale(kx, ky);
            }
        }

        //изменение масштаба фигуры
        public virtual void Scale(float scaleX, float scaleY)
        {
            //масштабируем линии
            Matrix m = new Matrix();
            m.Scale(scaleX, scaleY);
            Path.Transform(m);
            //масштабируем прямоугльник текста
            textRect = new RectangleF(textRect.Left * scaleX, textRect.Top * scaleY, textRect.Width * scaleX, textRect.Height * scaleY);
        }

        //сдвиг местоположения фигуры
        public virtual void Offset(float dx, float dy)
        {
            location = location.Offset(dx, dy);
            if (location.X < 0)
                location.X = 0;
            if (location.Y < 0)
                location.Y = 0;
        }

        //отрисовка фигуры
        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(location.X, location.Y);
            gr.FillPath(brush, Path);
            gr.DrawPath(pen, Path);
            if (!string.IsNullOrEmpty(text))
                gr.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, textRect, StringFormat);
            gr.Restore(transState);
        }

        //создание маркера для изменения размера
        public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            Marker m = new SizeMarker();
            m.targetFigure = this;
            yield return m;

            ZOrderMarker m1 = new ZOrderMarker(diagram);
            m1.targetFigure = this;
            yield return m1;
        }
    }

    //прямоугольник
    [Serializable]
    public class RectFigure : SolidFigure
    {
        public string Name = "Выполнение операции";

        public RectFigure()
        {
            base.Name = Name;

            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2, 2 * defaultSize, defaultSize));
            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);

        }

        public override int GetHashCode()
        {
            return 0;

        }
        public override bool Equals(object obj)
        {
            var other = obj as RectFigure;
            return other != null;
        }
    }


    //ромб
    [Serializable]
    public class RhombFigure : SolidFigure
    {
        public string Name = "Ветвлений";
        public RhombFigure()
        {
            base.Name = Name;
            Path.AddPolygon(new PointF[]{
                new PointF(-defaultSize, 0),
                new PointF(0, -defaultSize/2),
                new PointF(defaultSize, 0),
                new PointF(0, defaultSize/2)
            });
            textRect = new RectangleF(-defaultSize / 2, -defaultSize / 4, defaultSize, defaultSize / 2);
        }
        public override int GetHashCode()
        {
            return 1;

        }
        public override bool Equals(object obj)
        {
            var other = obj as RhombFigure;
            return other != null;
        }
    }

    //паралелограмм
    [Serializable]
    public class ParalelogrammFigure : SolidFigure
    {
        public string Name = "Ввод и вывод данных";
        public ParalelogrammFigure()
        {
            base.Name = Name;
            float shift = 8f;
            Path.AddPolygon(new PointF[]{
                new PointF(-defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize - shift/2, defaultSize/2),
                new PointF(-defaultSize - shift/2, defaultSize/2),
            });
            textRect = new RectangleF(-defaultSize + shift / 2, -defaultSize / 2 + 2, 2 * defaultSize - shift, defaultSize - 4);
        }
        public override int GetHashCode()
        {
            return 2;

        }
        public override bool Equals(object obj)
        {
            var other = obj as ParalelogrammFigure;
            return other != null;
        }
    }

    //эллипс
    [Serializable]
    public class EllipseFigure : SolidFigure
    {
        public string Name = "Начало и конец";
        public EllipseFigure()
        {
            base.Name = Name;
            // Path.AddEllipse(new RectangleF(-defaultSize, -defaultSize / 2, defaultSize * 2, defaultSize));
            textRect = new RectangleF(-defaultSize / 1.4f, -defaultSize / 2 / 1.4f, 2 * defaultSize / 1.4f, defaultSize / 1.4f);

            Path.AddArc(-defaultSize, -defaultSize / 4, defaultSize / 2, defaultSize / 1.7F, 90, 180);

            Path.AddRectangle(new RectangleF(-defaultSize + 10, -defaultSize / 4, defaultSize + 20, defaultSize / 1.7F));

            Path.AddArc(-defaultSize + 60, -defaultSize / 4, defaultSize / 2, defaultSize / 1.7F, 90, -180);
        }
        public override int GetHashCode()
        {
            return 3;

        }
        public override bool Equals(object obj)
        {
            var other = obj as EllipseFigure;
            return other != null;
        }
    }

    //стопка прямоугольников
    [Serializable]
    public class StackFigure : SolidFigure
    {
        public StackFigure()
        {

            float shift = 4f;
            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2, defaultSize * 2, defaultSize));
            Path.AddLines(new PointF[]{
                new PointF(-defaultSize + shift, defaultSize / 2),
                new PointF(-defaultSize + shift, defaultSize / 2 + shift),
                new PointF(defaultSize + shift, defaultSize / 2 + shift),
                new PointF(defaultSize + shift, -defaultSize / 2 + shift),
                new PointF(defaultSize, -defaultSize / 2 + shift),
                new PointF(defaultSize, defaultSize / 2)
            });

            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);
        }
        public override int GetHashCode()
        {
            return 4;

        }
        public override bool Equals(object obj)
        {
            var other = obj as StackFigure;
            return other != null;
        }
    }

    //рамка
    [Serializable]
    public class FrameFigure : SolidFigure
    {
        static Pen clickPen = new Pen(Color.Transparent, 3);

        protected override StringFormat StringFormat
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                return stringFormat;
            }
        }

        public FrameFigure()
        {
            Path.AddRectangle(new RectangleF(0, -defaultSize, defaultSize * 4, defaultSize * 2));
            textRect = new RectangleF(0, -defaultSize, defaultSize * 4, defaultSize * 2);
        }

        public override bool IsInsidePoint(PointF p)
        {
            return Path.IsOutlineVisible(p.X - location.X, p.Y - location.Y, clickPen);
        }

        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(location.X, location.Y);
            gr.DrawPath(pen, Path);
            if (!string.IsNullOrEmpty(text))
                gr.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, textRect, StringFormat.GenericDefault);
            gr.Restore(transState);
        }
        public override int GetHashCode()
        {
            return 5;

        }
        public override bool Equals(object obj)
        {
            var other = obj as FrameFigure;
            return other != null;
        }
    }

    //картинка
    [Serializable]
    public class PictureFigure : SolidFigure
    {
        string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; image = null; }
        }

        [NonSerialized]
        Image image;

        public PictureFigure()
            : this("")
        {
        }

        public PictureFigure(string fileName)
        {
            this.fileName = fileName;
            Path.AddRectangle(new RectangleF(-defaultSize * 2, -defaultSize, 4 * defaultSize, 2 * defaultSize));
        }

        public override void Draw(Graphics gr)
        {
            if (image == null)
                if (File.Exists(fileName))
                    image = Image.FromFile(fileName);
                else
                    image = new Bitmap(1, 1);
            gr.DrawImage(image, this.Bounds);
        }

        public override void Offset(float dx, float dy)
        {
            location = location.Offset(dx, dy);
        }
        public override int GetHashCode()
        {
            return 6;

        }
        public override bool Equals(object obj)
        {
            var other = obj as PictureFigure;
            return other != null;
        }
    }

    public class CycleStartFigure : SolidFigure
    {
        public string Name = "Начало цикла";
        public CycleStartFigure()
        {
            base.Name = Name;
            float shift = 8f;
            Path.AddPolygon(new PointF[]{
               
                new PointF(-30, -defaultSize/2),
                new PointF(30, -defaultSize/2),
                
                new PointF(defaultSize, -defaultSize/6),
                new PointF(defaultSize, defaultSize/2),
               
                new PointF(-defaultSize, defaultSize/2),
                new PointF(-defaultSize, -defaultSize/6),
               });

            textRect = new RectangleF(-defaultSize + shift / 2, -defaultSize / 2 + 2, 2 * defaultSize - shift, defaultSize - 4);
        }
        public override int GetHashCode()
        {
            return 7;

        }
        public override bool Equals(object obj)
        {
            var other = obj as CycleStartFigure;
            return other != null;
        }

    }

    public class CycleEndFigure : SolidFigure
    {
        public string Name = "Конец цикла";

        public CycleEndFigure()
        {
            base.Name = Name;
            float shift = 8f;
            Path.AddPolygon(new PointF[]
            {
                new PointF(-defaultSize, -defaultSize/2),
                new PointF(defaultSize, -defaultSize/2),

                new PointF(defaultSize, defaultSize/6),
                new PointF(30, defaultSize/2),

                new PointF(-30, defaultSize/2),
                new PointF(-defaultSize, defaultSize/6)
            });
            textRect = new RectangleF(-defaultSize + shift / 2, -defaultSize / 2 + 2, 2 * defaultSize - shift, defaultSize - 4);
        }
        public override int GetHashCode()
        {
            return 8;

        }
        public override bool Equals(object obj)
        {
            var other = obj as CycleEndFigure;
            return other != null;
        }
    }
    //соединительная линия
    [Serializable]
    public class LineFigure : Figure
    {


        public SolidFigure From;
        public SolidFigure To;
        static Pen clickPen = new Pen(Color.Transparent, 3);

        public override void Draw(Graphics gr)
        {
            if (From == null || To == null)
                return;

            RecalcPath();
            gr.DrawPath(pen, Path);
        }

        public override bool IsInsidePoint(PointF p)
        {
            if (From == null || To == null)
                return false;

            RecalcPath();
            return Path.IsOutlineVisible(p, clickPen);
        }

        protected virtual void RecalcPath()
        {
            PointF[] points = null;
            if (Path.PointCount > 0)
                points = Path.PathPoints;
            if (Path.PointCount != 2 || points[0] != From.location || points[1] != To.location)
            {
                Path.Reset();
                Path.AddLine(From.location, To.location);


            }

        }


        public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            EndLineMarker m1 = new EndLineMarker(diagram, 0);
            m1.targetFigure = this;
            yield return m1;

            EndLineMarker m2 = new EndLineMarker(diagram, 1);
            m2.targetFigure = this;
            yield return m2;
        }

        public override int GetHashCode()
        {
            return 9;

        }
        public override bool Equals(object obj)
        {
            var other = obj as LineFigure;
            return other != null;
        }
    }

    //линия с "переломом"
    [Serializable]
    public class LedgeLineFigure : LineFigure
    {
        public string Name = "Связей";
        Diagram diagran = new Diagram();
        //координата X точки "перелома"
        internal float ledgePositionX = -1;

        public LedgeLineFigure()
        {
            base.Name = Name;
        }
        protected override void RecalcPath()
        {
            PointF[] points = null;

            if (ledgePositionX < 0)
                ledgePositionX = (From.location.X + To.location.X) / 2;

            if (Path.PointCount > 0)
                points = Path.PathPoints;
            if (Path.PointCount != 4 || points[0] != From.location || points[3] != To.location ||
                points[1].X != ledgePositionX)
            {
                Path.Reset();
                Path.AddLines(new PointF[]{
                    From.location,
                    new PointF(ledgePositionX, From.location.Y),
                    new PointF(ledgePositionX, To.location.Y),
                    To.location
                    });


            }
        }

        public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            RecalcPath();
            EndLineMarker m1 = new EndLineMarker(diagram, 0);
            m1.targetFigure = this;
            yield return m1;

            EndLineMarker m2 = new EndLineMarker(diagram, 1);
            m2.targetFigure = this;
            yield return m2;

            LedgeMarker m3 = new LedgeMarker();
            m3.targetFigure = this;
            m3.UpdateLocation();
            yield return m3;
        }

        public override int GetHashCode()
        {
            return 10;

        }
        public override bool Equals(object obj)
        {
            var other = obj as LedgeLineFigure;
            return other != null;
        }
    }



    public abstract class Marker : SolidFigure
    {
        protected static new int defaultSize = 2;
        public Figure targetFigure;


        public Marker()
        {
            color = Color.Red;
        }

        public virtual string ToolTip
        {
            get { return ToString(); }
        }

        public virtual System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return System.Windows.Forms.Cursors.SizeAll;
            }
        }

        public override bool IsInsidePoint(PointF p)
        {
            if (p.X < location.X - defaultSize || p.X > location.X + defaultSize)
                return false;
            if (p.Y < location.Y - defaultSize || p.Y > location.Y + defaultSize)
                return false;

            return true;
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawRectangle(Pens.Black, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
            gr.FillRectangle(brush, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
        }

        public abstract void UpdateLocation();
    }

    public class ZOrderMarker : Marker
    {
        Diagram diagram;

        public ZOrderMarker(Diagram diagram)
        {
            color = Color.Gray;
            this.diagram = diagram;
        }

        public override void UpdateLocation()
        {
            RectangleF rect = (targetFigure as SolidFigure).Bounds;
            location = rect.Location.Offset(-5, -5);
        }

        public override void Offset(float dx, float dy)
        {
            float d = dy * 2;
            if (d == 0) return;

            (targetFigure as SolidFigure).ZOrderChange(diagram, -(int)d);

            UpdateLocation();
        }

        public override Cursor Cursor
        {
            get
            {
                return Cursors.SizeNS;
            }
        }

        public override string ToolTip
        {
            get
            {
                return "Change Z-Order";
            }
        }
    }

    public class SizeMarker : Marker
    {
        public override void UpdateLocation()
        {
            RectangleF bounds = (targetFigure as SolidFigure).Bounds;
            location = new PointF(bounds.Right + defaultSize / 2, bounds.Bottom + defaultSize / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            (targetFigure as SolidFigure).Size =
                SizeF.Add((targetFigure as SolidFigure).Size, new SizeF(dx * 2, dy * 2));
        }
    }

    [Serializable]
    public class EndLineMarker : Marker
    {
        int pointIndex;
        Diagram diagram;

        public EndLineMarker(Diagram diagram, int pointIndex)
        {
            this.diagram = diagram;
            this.pointIndex = pointIndex;
        }

        public override void UpdateLocation()
        {
            LineFigure line = (targetFigure as LineFigure);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            SolidFigure figure = pointIndex == 0 ? line.From : line.To;
            location = figure.location;
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);

            //ищем фигуру под маркером
            SolidFigure figure = null;
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is SolidFigure && diagram.figures[i].IsInsidePoint(location))
                {
                    figure = (SolidFigure)diagram.figures[i];
                    break;
                }

            LineFigure line = (targetFigure as LineFigure);
            if (figure == null)
                figure = this;//если под маркером нет фигуры, то просто коннектим линию к самому маркеру

            //не позволяем конектится самому к себе
            if (line.From == figure || line.To == figure)
                return;
            //обновляем конекторы линии
            if (pointIndex == 0)
                line.From = figure;
            else
                line.To = figure;

        }
    }

    [Serializable]
    public class LedgeMarker : Marker
    {
        public override void UpdateLocation()
        {
            LedgeLineFigure line = (targetFigure as LedgeLineFigure);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            location = new PointF(line.ledgePositionX, (line.From.location.Y + line.To.location.Y) / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, 0);
            (targetFigure as LedgeLineFigure).ledgePositionX += dx;
        }
    }

    public static class GraphicsPathHelper
    {
        public static void Transform(this GraphicsPath path, Func<PointF, PointF> func, bool accuracy)
        {
            //для более точных рассчетов, можно сделать Flatten
            if (accuracy)
                path.Flatten();
            //получаем точки изображения
            var data = path.PathData;
            //выполняем преобразование над каждой точкой
            for (int i = 0; i < data.Points.Length; i++)
                data.Points[i] = func.Invoke(data.Points[i]);
            //очищаем исходный контур
            path.Reset();
            //создаем новый конутр и присоединяем к исходному
            path.AddPath(new GraphicsPath(data.Points, data.Types), false);
        }

        public static void Transform(this GraphicsPath path, Func<PointF, PointF> func)
        {
            Transform(path, func, false);
        }
    }

    public static class PointHelper
    {
        public static PointF Offset(this PointF p, float x, float y)
        {
            p.X = p.X + x;
            p.Y = p.Y + y;
            return p;
        }

        public static float Length(this PointF p)
        {
            return (float)Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }

        public static PointF Sub(this PointF p, PointF p1)
        {
            return new PointF(p.X - p1.X, p.Y - p1.Y);
        }

        public static PointF Mult(this PointF p, float k)
        {
            return new PointF(k * p.X, k * p.Y);
        }

        public static PointF Mult(this PointF p, float kx, float ky)
        {
            return new PointF(kx * p.X, ky * p.Y);
        }

        public static PointF Add(this PointF p, PointF p1)
        {
            return new PointF(p.X + p1.X, p.Y + p1.Y);
        }

        public static float FromTo(this float k, float a, float b)
        {
            return (a * (1 - k) + b * k);
        }

        public static PointF FromTo(this float k, PointF a, PointF b)
        {
            return new PointF(k.FromTo(a.X, b.X), k.FromTo(a.Y, b.Y));
        }

        public static string FirstCharUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            if (s.Length == 1)
                return s.ToUpper();

            return char.ToUpper(s[0]) + s.Substring(1);
        }


        public static float Angle(this PointF A, PointF B)
        {
            return (float)(180f * (Math.Atan2(A.Y, A.X) - Math.Atan2(B.Y, B.X)) / Math.PI);
        }

        public static PointF[] FlipByX(this PointF[] points)
        {
            Array.Reverse(points);
            for (int i = 0; i < points.Length; i++)
                points[i].X *= -1f;
            return points;
        }


    }
}
