using SmartFactory.Application.DTOs;
using SmartFactory.Application.Interfaces;
using SmartFactory.Domain;

namespace SmartFactory.Application.Services;

public class MachineService
{
    private readonly IMachineRepository _machineRepository;

    public MachineService(IMachineRepository machineRepository)
    {
        _machineRepository = machineRepository;
    }

    public Machine CreateMachine(CreateMachineRequest request)
    {
        var machine = new Machine(
            request.Name,
            request.Type);

        _machineRepository.Add(machine);

        return machine;
    }
}