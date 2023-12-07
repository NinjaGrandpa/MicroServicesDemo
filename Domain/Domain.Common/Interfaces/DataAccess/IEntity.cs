namespace Domain.Common.Interfaces.DataAccess;

// Interface som beskriver minsta m�jliga som alla v�ra typer ska ha
// Best practice att ange om den generiska typen �r en in eller out typ

public interface IEntity<out T>
{
    T Id { get; }
}