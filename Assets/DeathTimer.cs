using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathTimer
{    
    DateTime deathDate;
    DateTime birthDate;

    public TimeSpan TimeLeft {get {return (deathDate - DateTime.Now).Duration();}}
    public double PercentLived {get {return 100 - (TimeLeft.Duration().TotalSeconds / (deathDate - birthDate).Duration().TotalSeconds) * 100;}}

    public DeathTimer(int lifeExpectancyYears, DateTime birthDate){
        this.birthDate = birthDate;
        deathDate = new DateTime(birthDate.Year + lifeExpectancyYears, birthDate.Month, birthDate.Day);
    }    
}
