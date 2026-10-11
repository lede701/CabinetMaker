using CabinetMaker.DAL.Repositories;

namespace CabinetMaker.DAL;

// Scans the DAL assembly once at startup and maps entity types to their concrete repository types.
// Only types that directly or indirectly extend BaseRepository<TEntity> are included.
public class RepositoryTypeMap
{
    public IReadOnlyDictionary<Type, Type> Map { get; }

    public RepositoryTypeMap()
    {
        Map = BuildMap();
    }

    private static IReadOnlyDictionary<Type, Type> BuildMap()
    {
        var map = new Dictionary<Type, Type>();

        foreach (var type in typeof(RepositoryTypeMap).Assembly.GetTypes())
        {
            if (type.IsAbstract || type.IsGenericTypeDefinition) continue;
            var entityType = ResolveEntityType(type);
            if (entityType != null)
                map[entityType] = type;
        }

        return map;
    }

    private static Type? ResolveEntityType(Type repoType)
    {
        var current = repoType.BaseType;
        while (current != null)
        {
            if (current.IsGenericType && current.GetGenericTypeDefinition() == typeof(BaseRepository<>))
                return current.GetGenericArguments()[0];
            current = current.BaseType;
        }
        return null;
    }
}
