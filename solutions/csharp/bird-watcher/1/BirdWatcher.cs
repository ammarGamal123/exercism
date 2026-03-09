using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        // throw new NotImplementedException("Please implement the BirdCount.Today() method");
        return birdsPerDay[^ 1];
    }

    public void IncrementTodaysCount()
    {
        //throw new NotImplementedException("Please implement the BirdCount.IncrementTodaysCount() method");
        ++ birdsPerDay[^ 1];
    }

    public bool HasDayWithoutBirds()
    {
        bool flag = false;
        for (int i = 0;i < birdsPerDay.Length; i++)
        {
            if (birdsPerDay[i] == 0)
            {
                flag = true;
                break;
            }
        }
        return flag;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int ans = 0;

        for (int i = 0;i < numberOfDays; i++)
        {
            ans += birdsPerDay[i];
        }
        return ans;
    }

    public int BusyDays()
    {
        int busy = 0;
        for (int i = 0;i < birdsPerDay.Length;i++)
        {
            if (birdsPerDay[i] >= 5)
            ++ busy;
        }
        return busy;
    }
}
