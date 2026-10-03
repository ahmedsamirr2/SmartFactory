using SmartFactory.Domain;

namespace SmartFactory.Tests;

public class MachineTests
{
    [Fact]
    public void CreateMachine_ShouldHaveStoppedStatus()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        var status = machine.Status;

        // Assert
        Assert.Equal(Machine.MachineStatus.Stopped, status);
    }

    [Fact]
    public void StartMachine_ShouldHaveRunningStatus()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        machine.Start();
        var status = machine.Status;

        // Assert
        Assert.Equal(Machine.MachineStatus.Running, status);
    }

    [Fact]
    public void StartMachine_WhenMaintenanceRequired_ShouldThrowException()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        machine.RequireMaintenance();

        //Assert
        Assert.Throws<InvalidOperationException>(() => machine.Start());
    }

    [Fact]
    public void StopMachine_ShouldHaveStoppedStatus()
    {
        //Arrange 
        var machine = new Machine("CNC MACHINE", "CNC");

        //Act
        machine.Start();
        machine.Stop();
        var status = machine.Status;

        //Assert
        Assert.Equal(Machine.MachineStatus.Stopped, status);
    }
    [Fact]
    public void StopMachine_WhenAlreadyStopped_ShouldThrowException()
    {
        // Arrange
        var machine = new Machine("CNC MACHINE", "CNC");

        // Act
        machine.Start();
        machine.Stop();

        // Assert
        Assert.Throws<InvalidOperationException>(() => machine.Stop());
    }
    [Fact]
    public void UpdateTemperature_ShouldChangeStatusToWarning()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Temperature);

        machine.AddSensor(sensor);

        // Act
        sensor.UpdateReading(120);
        machine.EvaluateStatus();

        // Assert
        Assert.Equal(Machine.MachineStatus.Warning, machine.Status);
    }

    [Fact]
    public void UpdateEfficiency_ShouldChangeStatusToWarning()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        machine.UpdateEfficiency(49);
        var status = machine.Status;

        // Assert
        Assert.Equal(Machine.MachineStatus.Warning, status);
    }

    [Fact]
    public void EvaluateStatus_WhenNoSensorReadings_ShouldHaveStoppedStatus()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        machine.EvaluateStatus();
        var status = machine.Status;

        // Assert
        Assert.Equal(Machine.MachineStatus.Stopped, status);
    }
    [Fact]
    public void CreateSensor_ShouldHaveEmptyReadings()
    {
        // Arrange
        var sensor = new Sensor(Sensor.SensorType.Temperature);

        // Act
        var readings = sensor.Readings;

        // Assert
        Assert.Empty(readings);
    }
    [Fact]
    public void UpdateReading_ShouldUpdateValue()
    {
        // Arrange
        var sensor = new Sensor(Sensor.SensorType.Temperature);

        // Act
        sensor.UpdateReading(80);

        // Assert
        Assert.Equal(80, sensor.Value);
    }
    [Fact]
    public void AddSensor_ShouldAddSensorToMachine()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Temperature);

        // Act
        machine.AddSensor(sensor);

        // Assert
        Assert.Contains(sensor, machine.Sensors);
    }
    [Fact]
    public void GetTemperature_ShouldReturnSensorValue()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Temperature);

        machine.AddSensor(sensor);
        sensor.UpdateReading(85);

        // Act
        var temperature = machine.GetTemperature();

        // Assert
        Assert.Equal(85, temperature);
    }
    [Fact]
    public void GetTemperature_WhenSensorNotFound_ShouldReturnNull()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        var temperature = machine.GetTemperature();

        // Assert
        Assert.Null(temperature);
    }
    [Fact]
    public void GetPressure_ShouldReturnSensorValue()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Pressure);

        machine.AddSensor(sensor);
        sensor.UpdateReading(100);

        // Act
        var pressure = machine.GetPressure();

        // Assert
        Assert.Equal(100, pressure);
    }
    [Fact]
    public void GetPressure_WhenSensorNotFound_ShouldReturnNull()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        var pressure = machine.GetPressure();

        // Assert
        Assert.Null(pressure);
    }
    [Fact]
    public void GetVibration_ShouldReturnSensorValue()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Vibration);

        machine.AddSensor(sensor);
        sensor.UpdateReading(0.5);

        // Act
        var vibration = machine.GetVibration();

        // Assert
        Assert.Equal(0.5, vibration);
    }
    [Fact]
    public void GetVibration_WhenSensorNotFound_ShouldReturnNull()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");

        // Act
        var vibration = machine.GetVibration();

        // Assert
        Assert.Null(vibration);
    }
    [Fact]
    public void UpdatePressure_ShouldChangeStatusToWarning()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Pressure);

        machine.AddSensor(sensor);

        // Act
        machine.UpdatePressure(120);

        // Assert
        Assert.Equal(Machine.MachineStatus.Warning, machine.Status);
    }
    [Fact]
    public void UpdateVibration_ShouldChangeStatusToWarning()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Vibration);

        machine.AddSensor(sensor);

        // Act
        machine.UpdateVibration(6);

        // Assert
        Assert.Equal(Machine.MachineStatus.Warning, machine.Status);
    }
    [Fact]
    public void UpdateTemperature_WithNormalValue_ShouldKeepMachineRunning()
    {
        // Arrange
        var machine = new Machine("CNC Machine", "CNC");
        var sensor = new Sensor(Sensor.SensorType.Temperature);

        machine.AddSensor(sensor);

        // Act
        machine.UpdateTemperature(70);

        // Assert
        Assert.Equal(Machine.MachineStatus.Running, machine.Status);
    }
    [Fact]
    public void UpdateReading_ShouldAddValueToReadings()
    {
        // Arrange
        var sensor = new Sensor(Sensor.SensorType.Temperature);

        // Act
        sensor.UpdateReading(70);
        sensor.UpdateReading(75);
        sensor.UpdateReading(80);


        // Assert
        Assert.Equal(new List<double> { 70, 75, 80 }, sensor.Readings);
    }

}