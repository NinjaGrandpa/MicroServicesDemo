namespace Domain.Common.Interfaces.DataAccess;

// Interface som beskriver minsta möjliga som alla våra typer ska ha
// Best practice att ange om den generiska typen är en in eller out typ

public interface IEntity<out T>
{
    T Id { get; }
}