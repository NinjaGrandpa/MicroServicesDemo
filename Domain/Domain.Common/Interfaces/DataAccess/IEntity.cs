namespace Domain.Common.Interfaces.DataAccess;

// Interface som beskriver minsta möjliga som alla var typer ska ha
public interface IEntity<T>
{
    T Id { get; set; }
}