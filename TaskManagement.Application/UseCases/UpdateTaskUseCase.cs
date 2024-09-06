using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.UseCases;

public class UpdateTaskUseCase
{
    private readonly ITaskRepository _taskRepository;
    private readonly ITaskHistoryRepository _taskHistoryRepository;

    public UpdateTaskUseCase(ITaskRepository taskRepository, ITaskHistoryRepository taskHistoryRepository)
    {
        _taskRepository = taskRepository;
        _taskHistoryRepository = taskHistoryRepository;
    }

    public async Task ExecuteAsync(Guid taskId, TaskStatus status, string updatedBy)
    {
        var task = await _taskRepository.GetByIdAsync(taskId);

        if (task == null)
            throw new InvalidOperationException("Task not found.");

        var previousStatus = task.Status;
        task.Status = status;
        task.UpdatedBy = updatedBy;
        task.UpdatedAt = DateTime.UtcNow;

        await _taskRepository.UpdateAsync(task);

        var history = new TaskHistory
        {
            Id = Guid.NewGuid(),
            TaskId = taskId,
            Change = $"Status changed from {previousStatus} to {status}",
            ChangedBy = updatedBy,
            ChangedAt = DateTime.UtcNow
        };

        await _taskHistoryRepository.CreateAsync(history);
    }
}