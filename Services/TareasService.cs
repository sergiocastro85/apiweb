using webapi.Models;

namespace webapi.Services;


public class TareasService:ITareaService
{
    TareasContext context;

    public TareasService(TareasContext dbcontext)
    {
        context=dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var TareaaActual=context.Tareas.Find(id);

        if (TareaaActual !=null)
        {
            TareaaActual.Titulo=tarea.Titulo;
            TareaaActual.Descripcion=tarea.Descripcion;
            TareaaActual.PrioridadTarea=tarea.PrioridadTarea;
            TareaaActual.FechaCreacion=tarea.FechaCreacion;
            TareaaActual.Categoria=tarea.Categoria;
            TareaaActual.Resumen=tarea.Resumen;

            await context.SaveChangesAsync();
        }



    }
    
    public async Task Delete(Guid id)
    {
        var TareaaActual =context.Tareas.Find(id);

        if (TareaaActual !=null)
        {
            context.Remove(TareaaActual);
            await context.SaveChangesAsync();
        }

    }

}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Update(Guid id, Tarea tarea);
    Task Save(Tarea tarea);

    Task Delete(Guid id);

}