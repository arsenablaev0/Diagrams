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
            //asasd

           
        }


    }
}
