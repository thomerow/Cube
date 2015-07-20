using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Collections.ObjectModel;


namespace Quader {

   public partial class frmMain : Form {

      List<Quader> _solutions = new List<Quader>();

      // Die Rätsel-Rahmenbedingungen:
      ReadOnlyCollection<int> Numbers 
         = new ReadOnlyCollection<int>(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24 });
      private const int Sum = 52;

      private Object _lockListAdd = new Object();
      private int _discarded;


      public frmMain() {
         InitializeComponent();

#if DEBUG
         if (Numbers.Count != (int) Quader.Edge.Items) throw new Exception("Es müssen genau so viele Zahlen wie Quaderkanten zur Verfügung stehen.");
#endif
      } // frmMain


      private void BtnCalc_Click(object sender, EventArgs e) {
         _solutions.Clear();
         _txtSolutions.Clear();
         _discarded = 0;

         Application.DoEvents();

         // foreach (int n in Numbers)
         Parallel.ForEach(Numbers, n => {
            var q = new Quader(Sum);
            NextEdge(new List<int>(Numbers), (int) Quader.Edge.A, n, q);
         });

         PrintSolutions();
      } // BtnCalc_Click


      private void PrintSolutions() {
         var sbSolutions = new StringBuilder();

         sbSolutions.AppendLine(_discarded.ToString() + " Belegungen verworfen.");
         sbSolutions.AppendLine(_solutions.Count.ToString() + " Lösung(en) gefunden:");
         sbSolutions.AppendLine();

         var lines = new List<string>(_solutions.Count);

         _solutions.ForEach(q => lines.Add(q.ToString()));
         lines.Sort();
         lines.ForEach(ln => sbSolutions.AppendLine(ln));

         _txtSolutions.Text = sbSolutions.ToString();
      } // PrintSolutions


      private void NextEdge(List<int> numbers, Quader quader) {
         if (!quader.IsValid) {
            Interlocked.Increment(ref _discarded);
            return;
         }

         if (numbers.Count == 0) {
            if (quader.IsSolved) lock (_lockListAdd) _solutions.Add(quader);    // List<T>.Add is not thread save
            return;
         }

         for (int i = 0; i < (int) Quader.Edge.Items; ++i) {
            if (quader.Edges[i] != 0) continue;

            foreach (int j in numbers) {
               var q = new Quader(quader);
               NextEdge(numbers, i, j, q);
            }

            break;
         }
      } // NextEdge


      private void NextEdge(List<int> numbers, int nEdge, int nEdgeVal, Quader q) {
         q.Edges[nEdge] = nEdgeVal;
         var numbersLeft = new List<int>(numbers);
         numbersLeft.Remove(nEdgeVal);
         NextEdge(numbersLeft, q);
      } // NextEdge
   }
}
