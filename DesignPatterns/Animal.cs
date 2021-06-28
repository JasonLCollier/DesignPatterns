using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{

    /// The 'AbstractFactory' abstract class
    abstract class SpeciesFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }


    /// The 'ConcreteFactory1' class

    class DogFactory : SpeciesFactory

    {
        public override Herbivore CreateHerbivore()
        {
            return new Poodle();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }


    /// The 'ConcreteFactory2' class

    class CatFactory : SpeciesFactory

    {
        public override Herbivore CreateHerbivore()
        {
            return new Siamese();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }


    /// The 'AbstractProductA' abstract class

    abstract class Herbivore

    {
    }


    /// The 'AbstractProductB' abstract class

    abstract class Carnivore

    {
        public abstract void Eat(Herbivore h);
    }


    /// The 'ProductA1' class

    class Poodle : Herbivore

    {
    }

    /// The 'ProductB1' class

    class Wolf : Carnivore

    {
        public override void Eat(Herbivore h)
        {
            // Eat Poodle

            System.Console.WriteLine(this.GetType().Name +
                                     " eats " + h.GetType().Name);
        }
    }

    /// The 'ProductA2' class

    class Siamese : Herbivore

    {
    }


    /// The 'ProductB2' class

    class Lion : Carnivore

    {
        public override void Eat(Herbivore h)
        {
            // Eat Siamese

            System.Console.WriteLine(this.GetType().Name +
                                     " eats " + h.GetType().Name);
        }
    }

    /// The 'Client' class 

    class AnimalWorld

    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        // Constructor

        public AnimalWorld(SpeciesFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}

//read all (Java and C#)
//2. Builder pattern: build sounds / traits
//3. Abstract Factory: validate (abstract)
