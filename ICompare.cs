namespace Projekt
{
    interface ICompare<in T>
    {
        int CheckOutcome(T m1, T m2);
    }
}