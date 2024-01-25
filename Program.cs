namespace zadaca_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarPicker picker = new CarPicker("Toyota");
            
        }
    }

    public class CarShop
    {

   
     
        public void GetCar(CarFactory factory)
        {
            Car car = factory.CreateCar();
            car.Drive();
        }

    }

    public class CarPicker
    {
        
         
        CarShop shop=new CarShop();
       
        public CarPicker(string name)

        {
            
            if (name =="Toyota") {
                shop.GetCar(new ToyotaFactory());
               
            }
            if (name == "Ford")
            {
                shop.GetCar(new FordFactory());
            }
        }
        

    }

    public abstract class Car
    {
        public abstract void Drive();
    }

    public class Ford : Car
    {
        public override void Drive() { Console.WriteLine("Vozim ford"); }
    }

    public class Toyota : Car
    {
        public override void Drive()
        {
            Console.WriteLine("vozim toyotu");
        }
    }

    public abstract class CarFactory
    {
        public abstract Car CreateCar();
    }

    public class ToyotaFactory : CarFactory {

        public override Car CreateCar()
        {
            return new Toyota();
        }

    }

    public class FordFactory : CarFactory
    {
        public override Car CreateCar()
        {
            return new Ford();
        }
    }
        

}

