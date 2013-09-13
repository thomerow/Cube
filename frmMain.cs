using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Collections.ObjectModel;


namespace Quader
{
   public partial class frmMain : Form
   {
      List<Quader> _solutions = new List<Quader>();

      // Die Rätsel-Rahmenbedingungen:
      ReadOnlyCollection<int> Numbers = new ReadOnlyCollection<int>(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24 });
      private const int Sum = 52;

      private Object _lockObjListAdd = new Object();
      private Object _lockObjDiscIncr = new Object();
      private int _discarded;

      public frmMain()
      {
         InitializeComponent();

#if DEBUG
         if (Numbers.Count != (int) Quader.Edge.Items) throw new Exception("Es müssen genau so viele Zahlen wie Quaderkanten zur Verfügung stehen.");
#endif
      }

      private void btnCalc_Click(object sender, EventArgs e)
      {
         _solutions.Clear();
         txtSolutions.Clear();
         _discarded = 0;

         Application.DoEvents();

         // foreach (int n in Numbers)
         Parallel.ForEach<int>(Numbers, n =>
            {
               Quader q = new Quader(Sum);
               q.Edges[(int) Quader.Edge.A] = n;
               List<int> numbersLeft = new List<int>(Numbers);
               numbersLeft.Remove(n);
               NextEdge(numbersLeft, q);
            }
         );

         PrintSolutions();
      }

      private void PrintSolutions()
      {
         StringBuilder sbSolutions = new StringBuilder();

         sbSolutions.AppendLine(_discarded.ToString() + " Belegungen verworfen.");
         sbSolutions.AppendLine(_solutions.Count.ToString() + " Lösung(en) gefunden:");
         sbSolutions.AppendLine();

         List<string> lstLines = new List<string>(_solutions.Count);

         _solutions.ForEach(q => lstLines.Add(q.ToString()));
         lstLines.Sort();
         lstLines.ForEach(ln => sbSolutions.AppendLine(ln));

         txtSolutions.Text = sbSolutions.ToString();
      }

      private void NextEdge(List<int> numbers, Quader quader)
      {
         if (!quader.IsValid)
         {
            lock (_lockObjDiscIncr) ++_discarded;
            return;
         }

         if (numbers.Count == 0)
         {
            if (quader.IsSolved) lock (_lockObjListAdd) _solutions.Add(quader);    // List<T>.Add is not thread save
            return;
         }

         for (int i = 0; i < (int) Quader.Edge.Items; ++i)
         {
            if (quader.Edges[i] != 0) continue;

            foreach (int j in numbers)
            {
               Quader q = new Quader(quader);
               q.Edges[i] = j;
               List<int> numbersLeft = new List<int>(numbers);
               numbersLeft.Remove(j);
               NextEdge(numbersLeft, q);
            }

            break;
         }
      }
   }
}
