using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Resources;


namespace Diagrams
{

    public partial class Form1 : Form
    {

        private SerializableObject serializableObjectFigure;
        private readonly MySerializer serializer;
        private int _taskNumber;
        private Random _rnd;
        private bool IsSelectATask = false;
        private string _taskText;
        public Form1()
        {
            serializableObjectFigure = new SerializableObject();
            serializer = new MySerializer();
            _rnd = new Random();
            FileCheck(File.Exists("Task.txt"));

            InitializeComponent();
            textBox2.Text = serializableObjectFigure.Figures.Count.ToString();

            miNewDiagram_Click(null, null);


            #region //генернируем случайные фигуры и линии

            //генернируем случайные фигуры и линии
            //Random rnd = new Random();
            //for (int i = 0; i < 30; i++)
            //{
            //    SolidFigure figure = null;
            //    switch (rnd.Next(6))
            //    {
            //        case 0: figure = new RectFigure(); break;

            //        case 1: figure = new EllipseFigure(); break;
            //        case 2: figure = new RhombFigure(); break;
            //        case 3: figure = new StackFigure(); break;
            //        case 5: figure = new ParalelogrammFigure(); break;
            //    }
            //    if (figure != null)
            //    {
            //        figure.location = new Point(rnd.Next(400), rnd.Next(300));
            //        figure.text = figure.ToString() + i.ToString();
            //        dbDiagram.Diagram.figures.Add(figure);
            //    }
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    LineFigure line = new LineFigure();
            //    line.From = dbDiagram.Diagram.figures[rnd.Next(20)] as SolidFigure;
            //    line.To = dbDiagram.Diagram.figures[rnd.Next(20)] as SolidFigure;
            //    dbDiagram.Diagram.figures.Add(line);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //  LedgeLineFigure line = new LedgeLineFigure();

            //    line.From = dbDiagram.Diagram.figures[rnd.Next(20)] as SolidFigure;
            //    line.To = dbDiagram.Diagram.figures[rnd.Next(20)] as SolidFigure;
            //    dbDiagram.Diagram.figures.Add(line);
            //}

            #endregion

        }

        public void FileCheck(bool IsExsist)
        {
            if (IsExsist)
            {
                serializableObjectFigure = serializer.DeserializeObject("Task.txt");
            }
        }



        private void button1_Click(object sender, EventArgs e) //сохранить фигуры в файл
        {
            if (tb_password.Text == "11111")
            {
                if (dbDiagram.Diagram.figures.Count != 0)
                {
                    foreach (var t in dbDiagram.Diagram.figures)
                    {
                        serializableObjectFigure.OneFigure.Add(t.ToString());
                    }
                    serializableObjectFigure.Figures.Add((new List<string>(serializableObjectFigure.OneFigure)));
                    serializableObjectFigure.OneFigure.Clear();


                    serializer.SerializeObject("Task.txt", serializableObjectFigure);

                }
                else
                {
                    MessageBox.Show("На поле нет ни одного блока");
                }
            }
            else
            {
                MessageBox.Show("Пароль неверный");
                //  Console.WriteLine(serializableObjectFigure.Figures.Count);
            }
            // добавление фигур в новый список для сериализации.


            textBox2.Text = serializableObjectFigure.Figures.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //удаление последней эталонной блок схемы из файла
        {
            textBox2.Text = null;


            if (tb_password.Text == "11111")
            {
                serializableObjectFigure.Figures.RemoveAt(serializableObjectFigure.Figures.Count - 1);
                serializer.SerializeObject("Task.txt", serializableObjectFigure);
            }
            else
            {
                MessageBox.Show("Пароль неверный");
            }

            textBox2.Text = serializableObjectFigure.Figures.Count.ToString();
        }

        private void selectTask_Click(object sender, EventArgs e) //выбрать задание
        {
            IsSelectATask = true;
            var taskForm = new TaskForm();
            taskForm.ShowDialog();

            _taskNumber = taskForm.TaskNumber;
            _taskText = taskForm.TaskText;

            if (_taskText != null)
            {
                lblTask.Text = _taskText;
            }
        }

        private void button3_Click(object sender, EventArgs e) // проверка фигур
        {
            if (!IsSelectATask)
            {
                MessageBox.Show("Задание не выбрано!", "Выбор задания", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dbDiagram.Diagram.figures.Count != 0)
            {
                var compare = new Compare(_taskNumber, serializableObjectFigure.Figures, dbDiagram.Diagram.figures);
                compare.CompareWithStandart();
            }
            else
            {
                MessageBox.Show("На поле нет ни одной фигуры!", "Нет фигур", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void btnRectAdd_Click_1(object sender, EventArgs e) // событие по нажатию добавления фигур
        {
            AddFigures((((Button)sender).Tag).ToString());
        }

        private void AddFigures(string figure) //добавление фигур на поле
        {
            switch (figure)
            {
                case "Rectangle":
                    dbDiagram.AddFigure<RectFigure>(new PointF(_rnd.Next(200, 500), _rnd.Next(80, 300)));
                    break;
                case "Rhomb":
                    dbDiagram.AddFigure<RhombFigure>(new PointF(_rnd.Next(200, 500), _rnd.Next(80, 300)));
                    break;
                case "Paralelogramm":
                    dbDiagram.AddFigure<ParalelogrammFigure>(new PointF(_rnd.Next(200, 500), _rnd.Next(80, 300)));
                    break;
                case "StartEnd":
                    dbDiagram.AddFigure<EllipseFigure>(new PointF(_rnd.Next(200, 500), _rnd.Next(80, 300)));
                    break;
                case "CycleStart":
                    dbDiagram.AddFigure<CycleStartFigure>(new PointF(_rnd.Next(200, 500), _rnd.Next(80, 300)));
                    break;
                case "CycleEnd":
                    dbDiagram.AddFigure<CycleEndFigure>(new PointF(_rnd.Next(200, 500), _rnd.Next(80, 300)));
                    break;

            }
        }

        private void btnClearAll_Click(object sender, EventArgs e) //ОЧИСТКА ПОЛЯ
        {

            if (dbDiagram.Diagram.figures.Count == 0)
            {
                MessageBox.Show("Поле и так пустое");
            }

            else
            {
                var ask = MessageBox.Show("Очистить поле", "Вы уверены, что хотите очистить поле?",
                    MessageBoxButtons.YesNo);
                if (ask == DialogResult.Yes)
                {
                    dbDiagram.Diagram = new Diagram();
                    dbDiagram.Diagram = dbDiagram.Diagram;
                }
            }

        }

        #region КОНЕТЕЛЬ

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miNewDiagram_Click(object sender, EventArgs e)
        {
            dbDiagram.Diagram = new Diagram();
            dbDiagram.Diagram = dbDiagram.Diagram;

        }

      
        private void miExport_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                if (sfdImage.FilterIndex == 1)
                    dbDiagram.GetImage().Save(sfdImage.FileName);
                if (sfdImage.FilterIndex == 2)
                    dbDiagram.SaveAsMetafile(sfdImage.FileName);
            }
        }

        private void dbDiagram_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dbDiagram.SelectedBeginEditText();
        }


        private Point startDragPoint;

     private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedBringToFront();
        }

        private void miAddLedgeLine_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedAddLedgeLine();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedDelete();
        }

       

        private void editTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedBeginEditText();
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedSendToBack();
        }

        private void dbDiagram_MouseUp(object sender, MouseEventArgs e)
        {
            startDragPoint = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dbDiagram.SelectedFigure != null) 
                 cmSelectedFigure.Show(dbDiagram.PointToScreen(e.Location));
            }
        }

        private void dbDiagram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                dbDiagram.SelectedDelete();
        }

        #endregion

    


    }
}
