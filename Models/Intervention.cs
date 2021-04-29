using System;
public class Intervention
{
    public long id { get; set; }
    public long author { get; set; }
    public long customer_id { get; set; }
    public long building_id { get; set; }
    public long? battery_id { get; set; }
    public long? column_id { get; set; }
    public long? elevator_id { get; set; }
    public long? employee_id { get; set; }

    public DateTime? start_of_intervention { get; set; }

    public DateTime? end_of_intervention { get; set; }

    public string result { get; set; }
    public string report { get; set; }
    public string status { get; set; }

    // public virtual Employees Author { get; set; }
    // public virtual Batteries Battery { get; set; }
    // public virtual Buildings Building { get; set; }
    // public virtual Columns Column { get; set; }
    // public virtual Customers Customer { get; set; }
    // public virtual Elevators Elevator { get; set; }
    // public virtual Employees Employee { get; set; }
}