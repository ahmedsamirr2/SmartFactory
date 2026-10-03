
namespace SmartFactory.Domain;

public class Sensor
{
    public int Id { get; private set; }
    public SensorType Type { get; private set; }
    public double Value { get; private set; }
    public List<double> Readings { get; private set; }

    public enum SensorType
    {
        Temperature,
        Pressure,
        Vibration
    }

    public Sensor(SensorType type)
    {
        Type = type;
        Readings = new List<double>();
    }

    public void UpdateReading(double value)
    {
        Value = value;
        Readings.Add(value);
    }




}