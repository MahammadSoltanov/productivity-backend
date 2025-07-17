using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;
using Productivity.Domain.WorkspaceAggregate.Enumerations;

namespace Productivity.Domain.WorkspaceAggregate.ValueObjects;
public sealed class WorkspacePermissionMatrix : ValueObject
{
    private readonly Dictionary<WorkspaceRole, IReadOnlySet<WorkspaceAction>> _map;

    public WorkspacePermissionMatrix(
      IDictionary<WorkspaceRole, IEnumerable<WorkspaceAction>> map)
    {
        foreach (WorkspaceRole r in Enum.GetValues(typeof(WorkspaceRole)))
        {
            if (!map.ContainsKey(r))
            {
                throw new DomainException($"Missing permissions for role {r}.");
            }
        }

        _map = map.ToDictionary(
          kvp => kvp.Key,
          kvp => (IReadOnlySet<WorkspaceAction>)new HashSet<WorkspaceAction>(kvp.Value)
        );
    }

    public bool IsAllowed(WorkspaceRole role, WorkspaceAction action)
      => _map.TryGetValue(role, out var allowed) && allowed.Contains(action);

    public override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var kvp in _map.OrderBy(k => k.Key))
        {
            yield return kvp.Key;
            foreach (var act in kvp.Value.OrderBy(a => a))
            {
                yield return act;
            }
        }
    }
}
