namespace _1.Chef
{
    using System;

    class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl;
            bowl = GetBowl();

            bowl.Add(potato);
            bowl.Add(carrot);
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }
        private static void Peel(Vegetable vegatable)
        {
            Console.WriteLine("Peeled");
        }

        private void Cut(Vegetable potato)
        {
        }
    }
}
