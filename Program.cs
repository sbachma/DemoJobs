using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Job : IComparable
{
    private string description;
    public string MyDescription
    {
        get
        {
            return description;
        }
        set
        {
            if (value != null && value != "")
            {
                description = value;
            }
        }
    }
    private double hours;
    public double MyHours
    {
        get
        {
            return hours;
        }
        set
        {
            if (value > 0)
            {
                hours = value;
            }
        }
    }
    private double rate;
    public double MyRate
    {
        get
        {
            return rate;
        }
        set
        {
            if (value > 0)
            {
                rate = value;
            }
        }
    }
    public override string ToString()
    {
        return "\nDescription: " + MyDescription + "\nHours: " + MyHours + "\nRate: " + MyRate;
    }



    public int CompareTo(object obj)
    {
        Job job = (Job)obj;
        return CalcFee().CompareTo(job.CalcFee());
    }

    public static Job operator+(Job a, Job b)
    {
        Job job = new Job();
        job.description = a.description + " and " + b.description;
        job.hours = a.hours + b.hours;
        job.rate = a.rate + b.rate / 2;
        return job;
    }

    public double CalcFee()
    {
        return hours * rate;
    }

    public Job()
    {
        description = "mow yard";
        hours = 1;
        rate = 10;
    }
    public Job(string desc)
    {
        if(desc != "")
        {
            description = desc;
        }
        else
        {
            description = "mow yard";
        }
        hours = 1;
        rate = 10;
    }
    public Job(string desc, double h, double r)
    {
        if (desc != "")
        {
            description = desc;
        }
        else
        {
            description = "mow yard";
        }
        if(!(h <= 0))
        {
            hours = h;
        }
        else
        {
            hours = 1;
        }
        if (!(r <= 0))
        {
            rate = r;
        }
        else
        {
            rate = 10;
        }
    }
}
