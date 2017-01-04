using PrimeraValdivia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraValdivia.DataModels
{
    public class MesAsistencia : ViewModelBase
    {
        private String _nombreMes;
        public String nombreMes
        {
            get { return _nombreMes; }
            set
            {
                _nombreMes = value;
                OnPropertyChanged("nombreMes");
            }
        }
        private int _LL;
        public int LL
        {
            get { return _LL; }
            set
            {
                _LL = value;
                OnPropertyChanged("LL");
            }
        }
        private int _A;
        public int A
        {
            get { return _A; }
            set
            {
                _A = value;
                OnPropertyChanged("A");
            }
        }
        private int _F;
        public int F
        {
            get { return _F; }
            set
            {
                _F = value;
                OnPropertyChanged("F");
            }
        }
        public MesAsistencia(String nombreMes, int LL, int A, int F)
        {
            this.nombreMes = nombreMes;
            this.LL = LL;
            this.A = A;
            this.F = F;
        }
        public MesAsistencia()
        {

        }
    }
}
