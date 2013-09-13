using System;
using System.Threading.Tasks;

namespace Quader
{
   class Quader
   {
      public int[] Edges = new int[(int) Edge.Items];
      private int _sum;

      public static int[,] Surfaces = 
      { 
         { (int)Edge.A, (int)Edge.B, (int)Edge.C, (int)Edge.D },
         { (int)Edge.A, (int)Edge.E, (int)Edge.F, (int)Edge.I },
         { (int)Edge.B, (int)Edge.G, (int)Edge.F, (int)Edge.J },
         { (int)Edge.H, (int)Edge.C, (int)Edge.G, (int)Edge.K },
         { (int)Edge.D, (int)Edge.E, (int)Edge.L, (int)Edge.H },
         { (int)Edge.I, (int)Edge.J, (int)Edge.K, (int)Edge.L },
      };

      public enum Edge { A = 0, B, C, D, E, F, G, H, I, J, K, L, Items };

      static Quader()
      {
#if DEBUG
         if ((int) Edge.Items != 12) throw new Exception("Ein Quader hat immer 12 Kanten.");
#endif
      }

      public Quader(int sum)
      {
         _sum = sum;
      }

      public Quader(Quader that)
      {
         Array.Copy(that.Edges, this.Edges, (int) Edge.Items);
         this._sum = that._sum;
      }

      public override string ToString()
      {
         return "a = " + Edges[(int) Edge.A].ToString().PadLeft(2, (char) 0x2007)
            + ", b = " + Edges[(int) Edge.B].ToString().PadLeft(2, (char) 0x2007)
            + ", c = " + Edges[(int) Edge.C].ToString().PadLeft(2, (char) 0x2007)
            + ", d = " + Edges[(int) Edge.D].ToString().PadLeft(2, (char) 0x2007)
            + ", e = " + Edges[(int) Edge.E].ToString().PadLeft(2, (char) 0x2007)
            + ", f = " + Edges[(int) Edge.F].ToString().PadLeft(2, (char) 0x2007)
            + ", g = " + Edges[(int) Edge.G].ToString().PadLeft(2, (char) 0x2007)
            + ", h = " + Edges[(int) Edge.H].ToString().PadLeft(2, (char) 0x2007)
            + ", i = " + Edges[(int) Edge.I].ToString().PadLeft(2, (char) 0x2007)
            + ", j = " + Edges[(int) Edge.J].ToString().PadLeft(2, (char) 0x2007)
            + ", k = " + Edges[(int) Edge.K].ToString().PadLeft(2, (char) 0x2007)
            + ", l = " + Edges[(int) Edge.L].ToString().PadLeft(2, (char) 0x2007);
      }

      public bool IsValid
      {
         get
         {
            if (SumSurface(0) > _sum) return false;
            if (SumSurface(1) > _sum) return false;
            if (SumSurface(2) > _sum) return false;
            if (SumSurface(3) > _sum) return false;
            if (SumSurface(4) > _sum) return false;
            if (SumSurface(5) > _sum) return false;

            if (IsSurfaceComplete(0) && (SumSurface(0) != _sum)) return false;
            if (IsSurfaceComplete(1) && (SumSurface(1) != _sum)) return false;
            if (IsSurfaceComplete(2) && (SumSurface(2) != _sum)) return false;
            if (IsSurfaceComplete(3) && (SumSurface(3) != _sum)) return false;
            if (IsSurfaceComplete(4) && (SumSurface(4) != _sum)) return false;
            if (IsSurfaceComplete(5) && (SumSurface(5) != _sum)) return false;

            return true;
         }
      }

      public bool IsSolved
      {
         get
         {
            return ((SumSurface(0) == _sum)
               && (SumSurface(1) == _sum)
               && (SumSurface(2) == _sum)
               && (SumSurface(3) == _sum)
               && (SumSurface(4) == _sum)
               && (SumSurface(5) == _sum));
         }
      }

      private int SumSurface(int n)
      {
         return Edges[Surfaces[n, 0]]
            + Edges[Surfaces[n, 1]]
            + Edges[Surfaces[n, 2]]
            + Edges[Surfaces[n, 3]];
      }

      private bool IsSurfaceComplete(int n)
      {
         return (Edges[Surfaces[n, 0]] != 0)
            && (Edges[Surfaces[n, 1]] != 0)
            && (Edges[Surfaces[n, 2]] != 0)
            && (Edges[Surfaces[n, 3]] != 0);
      }
   }
}
