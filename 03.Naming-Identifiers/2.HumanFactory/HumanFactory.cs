namespace HumanFactory
{
    using System;

    internal class HumanFactory
    {
        internal enum Gender
        {
            Male,
            Female
        }

        internal class Human
        {
            public Gender Gender { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }
        }

        internal void CreateHuman(int age)
        {
            Human human = new Human();

            human.Age = age;

            if (age % 2 == 0)
            {
                human.Name = "Some male name";
                human.Gender = Gender.Male;
            }
            else
            {
                human.Name = "Some female name";
                human.Gender = Gender.Female;
            }
        }
    }
}
