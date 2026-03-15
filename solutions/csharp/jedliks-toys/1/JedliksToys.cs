class RemoteControlCar
{
    private RemoteControlCar _rc;
    private int _howMuchDriven;
    private bool _flag;
    public RemoteControlCar(int howMuchDriven = 0, bool flag = false)
    {
        _howMuchDriven = howMuchDriven;
        _flag = flag;
    }
    public RemoteControlCar()
    {

    }
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar(0, false);
    }

    public string DistanceDisplay()
    {
        if (_howMuchDriven > 2000)
            _howMuchDriven = 2000;
            
        return new string ($"Driven {_howMuchDriven} meters");
    }

    public string BatteryDisplay()
    {
        int percentage = 100 -  (_howMuchDriven / 20);
        if (percentage <= 0)
            return new string("Battery empty");

        return new string($"Battery at {percentage}%");
    }

    public void Drive()
    {
        _howMuchDriven += 20;
    }
}
