using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagrams
{
    public class Compare
    {
        private int _taskNumber;
        private List<List<string>> _standartList;
        private List<Figure> _testList;
        private Dictionary<int, string> _excessFiguresInTestFlowchart;
        private Dictionary<int, string> _missingFiguresInTestFlowchart; 


        public Compare(int taskNumber, List<List<string>> standartList, List<Figure> testList)
        {
            _taskNumber = taskNumber;
            _standartList = standartList;
            _testList = testList;

        }

        public void CompareWithStandart() //Сравнение со ЭТАЛОНОМ
        {
            var rectCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.RectFigure");
            var rhombCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.RhombFigure");
            var paralelogrammCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.ParalelogrammFigure");
            var ellipseCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.EllipseFigure");
            var cycleStartCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.CycleStartFigure");
            var cycleEndCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.CycleEndFigure");
            var lineCountInStandart = _standartList.Count(x => x[_taskNumber] == "Diagrams.LedgeLineFigure");

            var rectCountInTest = _testList.Count(x => x is RectFigure);
            var rhombCountInTest = _testList.Count(x => x is RhombFigure);
            var paralelogrammCountInTest = _testList.Count(x => x is ParalelogrammFigure);
            var ellipseCountInTest = _testList.Count(x => x is EllipseFigure);
            var cycleStartInTest = _testList.Count(x => x is CycleStartFigure);
            var cycleEndInTest = _testList.Count(x => x is CycleEndFigure);
            var lineCountInTest = _testList.Count(x => x is LineFigure);


            //if (_standartList[_taskNumber] != null)
            //{
            //    for (int i = 0; i < _standartList[_taskNumber].Count; i++)
            //    {
            //        switch (_standartList[_taskNumber][i])
            //        {
            //            case "Diagrams.RectFigure":
            //                //rectCountInStandart++;
            //                break;
            //            case "Diagrams.RhombFigure":
            //                rhombCountInStandart++;
            //                break;
            //            case "Diagrams.ParalelogrammFigure":
            //                paralelogrammCountInStandart++;
            //                break;
            //            case "Diagrams.EllipseFigure":
            //                ellipseCountInStandart++;
            //                break;
            //            case "Diagrams.CycleStartFigure":
            //                cycleStartCountInStandart++;
            //                break;
            //            case "Diagrams.CycleEndFigure":
            //                cycleEndCountInStandart++;
            //                break;
            //            case "Diagrams.LedgeLineFigure":
            //                lineCountInStandart++;
            //                break;
            //        }
            //    }
            //}
            //if (_testList == null) return;
            //foreach (var t in _testList)
            //{
            //    if (t is RectFigure)
            //    {
            //        //rectCountInTest++;
            //    }
            //    if (t is RhombFigure)
            //    {
            //        rhombCountInTest++;
            //    }
            //    if (t is ParalelogrammFigure)
            //    {
            //        paralelogrammCountInTest++;
            //    }
            //    if (t is EllipseFigure)
            //    {
            //        ellipseCountInTest++;
            //    }
            //    if (t is CycleStartFigure)
            //    {
            //        cycleStartInTest++;
            //    }
            //    if (t is CycleEndFigure)
            //    {
            //        cycleEndInTest++;
            //    }
            //    if (t is LineFigure)
            //    {
            //        lineCountInTest++;
            //    }
            //}
     
            
            //MessageBox.Show(
            //     string.Format(
            //         "Не хватает блоков: \n {0} 'Начало и конец' \n {1} 'Ветвлений' \n {2} 'Ввод и вывод данных' \n {3} 'Выполнение операции' \n {4} 'Начало цикла' \n {5} 'Конец цикла' \n {6} 'Связей'",
            //         rectCountInStandart - rectCountInTest, rhombCountInStandart - rhombCountInTest, paralelogrammCountInStandart - paralelogrammCountInTest,
            //         ellipseCountInStandart - ellipseCountInTest, cycleStartCountInStandart - cycleStartInTest, cycleEndCountInStandart - cycleEndInTest, lineCountInStandart - lineCountInTest));
            
           

        }


    }
}
