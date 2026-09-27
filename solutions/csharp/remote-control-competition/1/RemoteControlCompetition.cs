// TODO implement the IRemoteControlCar interface

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar? other)
    {
        if (this.NumberOfVictories > other?.NumberOfVictories)
            return 1;
        else if (this.NumberOfVictories < other?.NumberOfVictories)
            return -1;
        else return 0;
    }


    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}
public interface IRemoteControlCar
{
    public int DistanceTravelled { get; }

    public void Drive();
}
public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var cars = new List<ProductionRemoteControlCar>();
        cars.Add(prc1);
        cars.Add(prc2);

        cars.Sort();

        return cars;
    }
}
