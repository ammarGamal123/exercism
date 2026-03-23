class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    private int _speed;
    private int _batteryDrained;
    private int _currentBattery;
    private int _distanceDriven;

    public RemoteControlCar(int speed, int batterDrained)
    {
        _speed = speed;
        _batteryDrained = batterDrained;
        _currentBattery = 100;
        _distanceDriven = 0;
    }
    public bool BatteryDrained()
    {
        // if (_batteryDrained <= 100)
        //     return true;
        
        // else return true;


        return _currentBattery < _batteryDrained;
    }

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _distanceDriven += _speed;
            _currentBattery -= _batteryDrained;
        }
    }

    public static RemoteControlCar Nitro()
    {
       return new RemoteControlCar(50, 4);
    }

    public int GetBatterDrive()
    {
        return _batteryDrained;
    }
    public int GetSpeed()
    {
        return _speed;
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class

    private int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }
    public bool TryFinishTrack(RemoteControlCar car)
    {
        int maxDrive = 100 / car.GetBatterDrive();
        int maxDistance = maxDrive * car.GetSpeed();

        return maxDistance >= _distance;
    }
}