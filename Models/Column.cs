using System;
public class Column
{
    public long id { get; set; }
    public string building_type {get; set; }
    public long? number_of_floors_served {get; set; }
    public string status { get; set; }
    public string information { get; set; }
    public string notes { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public long? battery_id { get; set; }
}