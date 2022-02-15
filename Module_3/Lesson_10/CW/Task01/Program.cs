using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class A { }
    class B : A { }
    class C : B { }
    interface IInv<T>
    {
        T GetT(T t);
    }
    class ClassInv<T> : IInv<T>
    {
        public T GetT(T t) => t;
    }
    interface IContr<in T>
    {
        void GetT(T t);
    }
    class ClassContr<T> : IContr<T>
    {
        public void GetT(T t) { }
    }
    interface ICov<out T>
    {
        T GetT();
    }
    class ClassCov<T> : ICov<T>
    {
        public T GetT() { return default(T); }
    }
    class Program
    {
        public static void Main()
        {
            IInv<B> inv1 = new ClassInv<B>();
            //IInv<B> inv2 = new ClassInv<A>();
            //IInv<B> inv3 = new ClassInv<C>();
            IContr<B> cont1 = new ClassContr<B>();
            IContr<B> cont2 = new ClassContr<A>();
            //IContr<B> cont3 = new ClassContr<C>();
            ICov<B> cov1 = new ClassCov<B>();
            //ICov<B> cov2 = new ClassCov<A>();
            ICov<B> cov3 = new ClassCov<C>();
            Func<B, B, B> func;
            Action<B> action;
            Comparison<int> comparison;
            Predicate<int> predicate;
        }
    }
}