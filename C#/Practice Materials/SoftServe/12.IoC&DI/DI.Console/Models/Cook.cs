namespace DI.ConsoleApplication
{
    class Cook
    {
        public void Cooking(ICookware cookware)
        {
            cookware.Cook();
        }
    }
}
