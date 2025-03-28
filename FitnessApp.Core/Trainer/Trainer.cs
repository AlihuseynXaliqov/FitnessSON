﻿using FitnessApp.Core.Base;
using FitnessApp.Core.Class;

namespace FitnessApp.Core.Trainer;

public class Trainer:BaseEntity
{
    public string FirstName { get; set; }  
    public string LastName { get; set; } 
    public string ImageUrl { get; set; }   
    public string Biography { get; set; }
    public int Experience { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public int PositionId { get; set; }
    public TrainerPosition Position { get; set; }
    public ICollection<TrainersClasses> TrainersClasses { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
    
}
