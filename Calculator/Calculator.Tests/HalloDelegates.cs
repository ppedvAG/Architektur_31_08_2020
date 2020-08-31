using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Tests
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitParameter(string text);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegates
    {
        public HalloDelegates()
        {
            EinfacherDelegate meinDele;
            meinDele = EinfacheMethode;
            meinDele.Invoke();
            Action myAction = EinfacheMethode;
            Action myActionAno = delegate () { Console.WriteLine("AALT"); }; //bis .net 2.0
            Action myActionAno2 = () => { Console.WriteLine("Lambda"); }; //ab .net 3
            Action myActionAno3 = () => Console.WriteLine("Lambda");

            DelegateMitParameter deleMitPara = MethodeMitParameter;
            Action<string> actionMitPara = MethodeMitParameter;
            Action<string> actionMitParaAno = (string name) => { Console.WriteLine("Hallo " + name); };
            Action<string> actionMitParaAno2 = (name) => Console.WriteLine("Hallo " + name);
            Action<string> actionMitParaAno3 = x => Console.WriteLine("Hallo " + x);  //nur bei 1 parameter

            CalcDelegate calcDele = Minus;
            long result = calcDele.Invoke(45, 67);
            Func<int, int, long> calcAsFunc = Sum;

            Func<int, int, long> calcAsFuncAno = (int a, int b) => { return a + b; };
            Func<int, int, long> calcAsFuncAno2 = (a, b) => { return a + b; };
            Func<int, int, long> calcAsFuncAno3 = (a, b) => a + b;

            List<string> texte = new List<string>();
            var resultB = texte.Where(x => x.StartsWith("b")); //<--

            var resultB2 = texte.Where(Filter);
        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b") ==true)
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        void EinfacheMethode()
        {
            System.Console.WriteLine("Hallo");
        }
        void MethodeMitParameter(string msg)
        {
            System.Console.WriteLine(msg);
        }

    }
}
