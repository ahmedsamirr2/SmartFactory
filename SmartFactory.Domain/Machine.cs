namespace SmartFactory.Domain;

public class Machine
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public MachineStatus Status { get; set; }
    public double? Efficiency { get; set; }
    public DateTime LastMaintenance { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Sensor> Sensors { get; private set; }

    private const double WarningTemperature = 80.0;
    private const double WarningEfficiency = 50.0;
    private const double WarningPressure = 100.0;
    private const double WarningVibration = 5.0;

    public enum MachineStatus
    {
        Stopped,
        Running,
        Warning,
        MaintenanceRequired
    }

    public Machine(string name, string type)
    {
        Name = name;
        Type = type;
        Status = MachineStatus.Stopped;
        // Efficiency = 100;
        CreatedAt = DateTime.Now;
        Sensors = new List<Sensor>();
    }

    public void Start()
    {
        if (Status == MachineStatus.MaintenanceRequired)
        {
            throw new InvalidOperationException("Cannot start machine. Maintenance is required.");

        }

        Status = MachineStatus.Running;
    }

    public void Stop()
    {
        if (Status == MachineStatus.Stopped)
        {
            throw new InvalidOperationException("Machine is already stopped.");
        }

        Status = MachineStatus.Stopped;
    }

    public void UpdateTemperature(double temperature)
    {
        var sensor = Sensors.FirstOrDefault(
            s => s.Type == Sensor.SensorType.Temperature);

        if (sensor == null)
        {
            return;
        }

        sensor.UpdateReading(temperature);
        EvaluateStatus();
    }
    public void UpdatePressure(double pressure)
    {
        var sensor = Sensors.FirstOrDefault(
            s => s.Type == Sensor.SensorType.Pressure);

        if (sensor == null)
        {
            return;
        }

        sensor.UpdateReading(pressure);
        EvaluateStatus();
    }
    public void UpdateVibration(double vibration)
    {
        var sensor = Sensors.FirstOrDefault(
            s => s.Type == Sensor.SensorType.Vibration);

        if (sensor == null)
        {
            return;
        }

        sensor.UpdateReading(vibration);
        EvaluateStatus();
    }

    public void UpdateEfficiency(double efficiency)
    {
        Efficiency = efficiency;
        EvaluateStatus();
    }

    public void EvaluateStatus()
    {
        var temperature = GetTemperature();
        var pressure = GetPressure();
        var vibration = GetVibration();
        if (Status == MachineStatus.MaintenanceRequired)
        {
            return;
        }

        if (!temperature.HasValue && !pressure.HasValue && !vibration.HasValue && !Efficiency.HasValue)
        {
            Status = MachineStatus.Stopped;
            return;
        }

        if ((temperature.HasValue && temperature > WarningTemperature) ||
            (pressure.HasValue && pressure > WarningPressure) ||
            (vibration.HasValue && vibration > WarningVibration) ||
            (Efficiency.HasValue && Efficiency < WarningEfficiency))
        {
            Status = MachineStatus.Warning;
        }
        else
        {
            Status = MachineStatus.Running;
        }
    }

    public void RequireMaintenance()
    {
        Status = MachineStatus.MaintenanceRequired;
    }

    public void CompleteMaintenance()
    {
        Status = MachineStatus.Stopped;
        LastMaintenance = DateTime.Now;
    }
    public void AddSensor(Sensor sensor)
    {
        Sensors.Add(sensor);
    }

    // public double? GetTemperature()
    // {
    //     foreach (var sensor in Sensors)
    //     {
    //         if (sensor.Type == Sensor.SensorType.Temperature)
    //         {
    //             return sensor.Value;
    //         }
    //     }

    //     return null;
    // }

    public double? GetTemperature()
    {
        var sensor = Sensors.FirstOrDefault(
            s => s.Type == Sensor.SensorType.Temperature);

        return sensor?.Value;
    }

    public double? GetPressure()
    {
        var sensor = Sensors.FirstOrDefault(
            s => s.Type == Sensor.SensorType.Pressure);

        return sensor?.Value;
    }

    public double? GetVibration()
    {
        var sensor = Sensors.FirstOrDefault(
            s => s.Type == Sensor.SensorType.Vibration);

        return sensor?.Value;
    }


}