using SmartFactory.Application.DTOs;
using SmartFactory.Application.Services;
using SmartFactory.Domain;

namespace SmartFactory.Tests;

// public class MachineServiceTests
// {
//     [Fact]
//     public void CreateMachine_ShouldCreateMachine()
//     {
//         // Arrange
//         var service = new MachineService();

//         var request = new CreateMachineRequest
//         {
//             Name = "CNC Machine",
//             Type = "CNC"
//         };

//         // Act
//         var machine = service.CreateMachine(request);

//         // Assert
//         Assert.Equal("CNC Machine", machine.Name);
//         Assert.Equal("CNC", machine.Type);
//         Assert.Equal(
//             Machine.MachineStatus.Stopped,
//             machine.Status);
//     }
// }
