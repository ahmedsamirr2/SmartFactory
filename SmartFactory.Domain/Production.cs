namespace SmartFactory.Domain;

public class Production
{
    public int Id { get; private set; }
    public int MachineId { get; private set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public ProductionStatus Status { get; private set; }

    public enum ProductionStatus
    {
        Planned,
        InProgress,
        Completed,
        Cancelled
    }

    public Production(int machineId, string productName, int quantity)
    {
        MachineId = machineId;
        ProductName = productName;
        Quantity = quantity;
        Status = ProductionStatus.Planned;
    }

    public void StartProduction()
    {
        if (Status != ProductionStatus.Planned)
        {
            throw new InvalidOperationException(
                "Production cannot be started.");
        }

        Status = ProductionStatus.InProgress;
        StartTime = DateTime.Now;
    }
    public void CompleteProduction()
    {
        if (Status != ProductionStatus.InProgress)
        {
            throw new InvalidOperationException(
                "Production cannot be completed.");
        }

        Status = ProductionStatus.Completed;
        EndTime = DateTime.Now;
    }
    public void CancelProduction()
    {
        if (Status == ProductionStatus.Completed ||
            Status == ProductionStatus.Cancelled)
        {
            throw new InvalidOperationException(
                "Production cannot be cancelled.");
        }

        Status = ProductionStatus.Cancelled;
        EndTime = DateTime.Now;
    }

}