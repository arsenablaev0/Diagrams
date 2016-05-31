using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Diagrams
{
    public class Compare
    {
        private int _taskNumber;
        private List<List<string>> _standartList;
        private List<Figure> _testList;
        private Dictionary<Figure, int> _testFlowchartDictionary;
        private Dictionary<string, int> _standartFlowchartDictionary;
        //private Dictionary<string, int> _missingFiguresInTestFlowchart;
        //private Dictionary<Figure, int> _excessFiguresInTestFlowchart;


        public Compare(int taskNumber, List<List<string>> standartList, List<Figure> testList)
        {
            _taskNumber = taskNumber;
            _standartList = standartList;
            _testList = testList;
            _testFlowchartDictionary = new Dictionary<Figure, int>();
            _standartFlowchartDictionary = new Dictionary<string, int>();
        }

        public void CompareWithStandart() //Сравнение со ЭТАЛОНОМ
        {

            //var rectCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.RectFigure");
            //var rhombCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.RhombFigure");
            //var paralelogrammCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.ParalelogrammFigure");
            //var ellipseCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.EllipseFigure");
            //var cycleStartCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.CycleStartFigure");
            //var cycleEndCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.CycleEndFigure");
            //var lineCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.LedgeLineFigure");

            //var rectCountInTest = _testList.Count(x => x is RectFigure);
            //var rhombCountInTest = _testList.Count(x => x is RhombFigure);
            //var paralelogrammCountInTest = _testList.Count(x => x is ParalelogrammFigure);
            //var ellipseCountInTest = _testList.Count(x => x is EllipseFigure);
            //var cycleStartInTest = _testList.Count(x => x is CycleStartFigure);
            //var cycleEndInTest = _testList.Count(x => x is CycleEndFigure);
            //var lineCountInTest = _testList.Count(x => x is LineFigure);

            for (int i = 0; i < _testList.Count; i++)
            {
                var item = _testList[i];

                if (!_testFlowchartDictionary.ContainsKey(item))
                {
                    _testFlowchartDictionary.Add(item, 1);
                }
                else
                {
                    _testFlowchartDictionary[item]++;
                }
            }
            for (int i = 0; i < _standartList[_taskNumber].Count; i++)
            {
                var item = _standartList[_taskNumber][i];

                if (!_standartFlowchartDictionary.ContainsKey(item))
                {
                    _standartFlowchartDictionary.Add(item, 1);
                }
                else
                {
                    _standartFlowchartDictionary[item]++;
                }
            }

            ShowFinalMessage();
            // MessageBox.Show(
            //string.Format(
            //    "Ваша блок-схема состоит из: \n {0} 'Начало и конец' \n {1} 'Ветвлений' " +
            //    "\n {2} 'Ввод и вывод данных' \n {3} 'Выполнение операции' \n {4} 'Начало цикла' \n {5} 'Конец цикла" +
            //    " \n {6} 'Связей' " +
            //    "Эталонная блок-схема состоит из: \n {7} 'Начало и конец' \n {8} 'Ветвлений' " +
            //    "\n {9} 'Ввод и вывод данных' \n {10} 'Выполнение операции' \n {11} 'Начало цикла' \n {12} 'Конец цикла" +
            //    " \n {13} 'Связей'",
            //    _testFlowchartDictionary[new EllipseFigure()] ?? 0,
            //    _testFlowchartDictionary[new RhombFigure()],
            //    _testFlowchartDictionary[new ParalelogrammFigure()],
            //    _testFlowchartDictionary[new RectFigure()],
            //    _testFlowchartDictionary[new CycleStartFigure()],
            //    _testFlowchartDictionary[new CycleEndFigure()],
            //    _testFlowchartDictionary[new LedgeLineFigure()],
            //    _standartFlowchartDictionary["Diagrams.EllipseFigure"],
            //    _standartFlowchartDictionary["Diagrams.RhombFigure"],
            //    _standartFlowchartDictionary["Diagrams.ParalelogrammFigure"],
            //    _standartFlowchartDictionary["Diagrams.RectFigure"],
            //    _standartFlowchartDictionary["Diagrams.CycleStartFigure"],
            //    _standartFlowchartDictionary["Diagrams.CycleEndFigure"],
            //    _standartFlowchartDictionary["Diagrams.LedgeLineFigure"]
            //    )

            //);

            //var rectCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.RectFigure");
            //var rhombCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.RhombFigure");
            //var paralelogrammCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.ParalelogrammFigure");
            //var ellipseCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.EllipseFigure");
            //var cycleStartCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.CycleStartFigure");
            //var cycleEndCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.CycleEndFigure");
            //var lineCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.LedgeLineFigure");



        }

        public void ShowFinalMessage()
        {

            var sbTestFlowchartCount = new StringBuilder();
            var sbStandartFlowchartCount = new StringBuilder();

            for (int i = 0; i < _testFlowchartDictionary.Count; i++)
            {

                sbTestFlowchartCount.Append("\n" + " " + _testFlowchartDictionary.ElementAt(i).Value +
                    " " + _testFlowchartDictionary.ElementAt(i).Key.Name + " ");
            }
            for (int i = 0; i < _standartFlowchartDictionary.Count; i++)
            {
                sbStandartFlowchartCount.Append("\n" + " " + _standartFlowchartDictionary.ElementAt(i).Value +
                    " " + _standartFlowchartDictionary.ElementAt(i).Key + " ");


            }
            

            MessageBox.Show(@"Ваша блок-схема состоит из:" + sbTestFlowchartCount + "\n" +
                @"Эталонная блок-схема состоит из:" + sbStandartFlowchartCount);
        }


    }


}
