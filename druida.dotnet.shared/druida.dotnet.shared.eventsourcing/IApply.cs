namespace druida.dotnet.shared.eventsourcing;

public interface IApply<T>
{
    void Apply(T ev);
}